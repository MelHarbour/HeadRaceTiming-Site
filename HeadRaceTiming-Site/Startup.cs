using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using HeadRaceTimingSite.Models;
using HeadRaceTimingSite.Formatters;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.ResponseCompression;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using HeadRaceTimingSite.Handlers;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using HeadRaceTimingSite.Helpers;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Hosting;

namespace HeadRaceTimingSite
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            if (env is null)
                throw new ArgumentNullException(nameof(env));

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("connectionStrings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("authentication.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            // Add framework services.
            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter());
                options.FormatterMappings.SetMediaTypeMappingForFormat("csv", MediaTypeHeaderValue.Parse("text/csv"));
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new TimeSpanConverter());
            });

            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddDebug();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "HeadRaceTimingSite.xml");
                c.IncludeXmlComments(filePath);
                c.EnableAnnotations();
            });

            services.AddDbContext<TimingSiteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TimingSiteDatabase")));

            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //.AddCookie()
            //.AddOpenIdConnect("Auth0", options => {
            //    // Set the authority to your Auth0 domain
            //    options.Authority = $"https://{Configuration["Auth0:Domain"]}";

            //    // Configure the Auth0 Client ID and Client Secret
            //    options.ClientId = Configuration["Auth0:ClientId"];
            //    options.ClientSecret = Configuration["Auth0:ClientSecret"];

            //    // Set response type to code
            //    options.ResponseType = "code";

            //    options.SaveTokens = true;

            //    // Configure the scope
            //    options.Scope.Clear();
            //    options.Scope.Add("openid");
            //    options.Scope.Add("profile");
 
            //    options.CallbackPath = new PathString("/signin-auth0");

            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = "name"
            //    };

            //    // Configure the Claims Issuer to be Auth0
            //    options.ClaimsIssuer = "Auth0";
                
            //    options.Events = new OpenIdConnectEvents
            //    {
            //        // handle the logout redirection 
            //        OnRedirectToIdentityProviderForSignOut = (context) =>
            //        {
            //            var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

            //            var postLogoutUri = context.Properties.RedirectUri;
            //            if (!string.IsNullOrEmpty(postLogoutUri))
            //            {
            //                if (postLogoutUri.StartsWith("/", StringComparison.CurrentCulture))
            //                {
            //                    // transform to absolute
            //                    var request = context.Request;
            //                    postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
            //                }
            //                logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
            //            }

            //            context.Response.Redirect(logoutUri);
            //            context.HandleResponse();

            //            return Task.CompletedTask;
            //        }
            //    };
            //});

            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanAdminCompetition", policy => policy.Requirements.Add(new CompetitionAdminRequirement()));
            });

            services.AddApplicationInsightsTelemetry();

            services.AddSingleton<IAuthorizationHandler, CompetitionAdminAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AdminAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHelper, AuthorizationHelper>();

            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Built in")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            
            app.UseAuthentication();

            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Timing API v1");
            });

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Crew, Api.Resources.Crew>()
                .ForSourceMember(s => s.CrewId, y => y.DoNotValidate())
                .ForSourceMember(s => s.Results, y => y.DoNotValidate())
                .ForMember(d => d.Results, y => y.Ignore())
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.BroeCrewId))
                .ForMember(d => d.IsStarted, opt => opt.MapFrom(s => s.Results.Count > 0))
                .ForMember(d => d.IsFinished, opt => opt.MapFrom(s => s.OverallTime.HasValue))
                .ForMember(d => d.Rank, opt => opt.Ignore())
                .ForMember(d => d.LastUpdate, opt => opt.MapFrom(s => s.Results.Select(x => x.TimeOfDay).Last()))
                .ForMember(d => d.LastUpdate, opt => opt.Ignore())
                .ForMember(d => d.HasPenalty, opt => opt.MapFrom(s => s.Penalties.Count > 0));
            CreateMap<Api.Resources.Crew, Crew>()
                .ForPath(d => d.OverallTime, opt => opt.Ignore())
                .ForMember(d => d.BroeCrewId, opt => opt.MapFrom(s => s.Id));
            CreateMap<Result, Api.Resources.Result>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.TimingPointId))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.TimingPoint.Name))
                .ReverseMap()
                .ForMember(d => d.TimingPoint, opt => opt.Ignore())
                .ForMember(d => d.TimingPointId, opt => opt.Ignore());
            CreateMap<CrewAthlete, Api.Resources.Athlete>()
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.Athlete.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.Athlete.LastName))
                .ForMember(d => d.MembershipNumber, opt => opt.MapFrom(s => s.Athlete.MembershipNumber))
                .ReverseMap();
            CreateMap<Penalty, Api.Resources.Penalty>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.PenaltyId))
                .ReverseMap();
            CreateMap<Award, Api.Resources.Award>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.AwardId))
                .ReverseMap();
            CreateMap<Competition, Api.Resources.Competition>()
                .ReverseMap()
                .ForMember(d => d.FirstIntermediateName, opt => opt.Ignore())
                .ForMember(d => d.SecondIntermediateName, opt => opt.Ignore())
                .ForMember(d => d.FirstIntermediateId, opt => opt.Ignore())
                .ForMember(d => d.SecondIntermediateId, opt => opt.Ignore());
        }
    }
}
