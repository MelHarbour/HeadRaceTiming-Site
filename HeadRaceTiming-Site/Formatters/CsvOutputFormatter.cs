using CsvHelper;
using HeadRaceTimingSite.ViewModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
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

            var csv = new CsvWriter(sw);

            csv.WriteField("Name");
            csv.WriteField("Start Number");
            csv.WriteField("Intermediate 1");
            csv.WriteField("Intermediate 2");
            csv.WriteField("Overall");
            csv.NextRecord();

            foreach (Result result in (IList<Result>)context.Object)
            {
                csv.WriteField(result.Name);
                csv.WriteField(result.StartNumber);
                csv.WriteField(result.FirstIntermediateTime);
                csv.WriteField(result.SecondIntermediateTime);
                csv.WriteField(result.OverallTime);
                csv.NextRecord();
            }

            response.Headers.Add("content-disposition", "attachment; filename=\"export.csv\"");
            var streamWriter = new StreamWriter(response.Body);
            await streamWriter.WriteAsync(sw.ToString());
            await streamWriter.FlushAsync();
        }
    }
}
