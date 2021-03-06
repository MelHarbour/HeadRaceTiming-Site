﻿using Newtonsoft.Json;
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
            if (writer is null)
                throw new ArgumentNullException(nameof(writer));

            if (value is null)
                writer.WriteValue(String.Empty);
            else if (value > new TimeSpan(1, 0, 0))
                writer.WriteValue(String.Format(CultureInfo.CurrentCulture, "{0:hh\\:mm\\:ss\\.f}", value)); // Needed as TimeSpans are used for time of day as well
            else
                writer.WriteValue(String.Format(CultureInfo.CurrentCulture, "{0:m\\:ss\\.f}", value));
        }
    }
}
