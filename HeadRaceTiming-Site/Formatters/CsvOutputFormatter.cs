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
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;

            using (StringWriter sw = new StringWriter())
            {
                using (var csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords((IList<CsvCrewViewModel>)context.Object);
                }

                response.Headers.Add("content-disposition", "attachment; filename=\"export.csv\"");
                using (var streamWriter = new StreamWriter(response.Body))
                {
                    await streamWriter.WriteAsync(sw.ToString());
                    await streamWriter.FlushAsync();
                }
            }
        }
    }
}
