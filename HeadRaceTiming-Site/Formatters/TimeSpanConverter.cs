using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Formatters
{
    public class TimeSpanConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? ReadJson(JsonReader reader, Type objectType, TimeSpan? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, TimeSpan? value, JsonSerializer serializer)
        {
            if (value == null)
                writer.WriteValue(String.Empty);
            else
                writer.WriteValue(String.Format(CultureInfo.CurrentCulture, "{0:mm\\:ss\\.f}", value));
        }
    }
}
