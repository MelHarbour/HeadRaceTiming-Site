using CsvHelper;
using HeadRaceTimingSite.Api.Resources;
using HeadRaceTimingSite.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Formatters
{
    public class CsvOutputFormatter : OutputFormatter
    {
        public string ContentType { get; private set; }

        public CsvOutputFormatter()
        {
            ContentType = "text/csv";
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/csv"));
        }

        public async override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;

            StringWriter sw = new StringWriter();

            using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {

                csv.WriteField("Name");
                csv.WriteField("Start Number");
                csv.WriteField("Max CRI");
                csv.WriteField("Barnes");
                csv.WriteField("Hammersmith");
                csv.WriteField("Overall");
                csv.NextRecord();

                foreach (Crew result in (IList<Crew>)context.Object)
                {
                    csv.WriteField(result.Name);
                    csv.WriteField(result.StartNumber);
                    csv.WriteField(result.CriMax);
                    csv.WriteField(result.Results[1]?.RunTime);
                    csv.WriteField(result.Results[2]?.RunTime);
                    csv.WriteField(result.OverallTime);
                    csv.NextRecord();
                }
            }

            response.Headers.Add("content-disposition", "attachment; filename=\"export.csv\"");
            var streamWriter = new StreamWriter(response.Body);
            await streamWriter.WriteAsync(sw.ToString());
            await streamWriter.FlushAsync();
        }
    }
}
