using HeadRaceTimingSite.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace HeadRaceTimingSite.Tests.Formatters
{
    [TestClass]
    public class TimeSpanConverterTests
    {
        [TestMethod]
        public void WriteJson_GivenNullValue_ShouldReturnEmptyString()
        {
            TimeSpanConverter converter = new TimeSpanConverter();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();

                converter.WriteJson(writer, null, serializer);

                Assert.AreEqual("\"\"", sb.ToString());
            }
        }

        [TestMethod]
        public void WriteJson_GivenElapsedTime_ShouldReturnFormattedString()
        {
            TimeSpanConverter converter = new TimeSpanConverter();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();

                converter.WriteJson(writer, new TimeSpan(0, 0, 16, 54, 345), serializer);

                Assert.AreEqual("\"16:54.3\"", sb.ToString());
            }
        }

        [TestMethod]
        public void WriteJson_GivenTimeOfDay_ShouldReturnFormattedString()
        {
            TimeSpanConverter converter = new TimeSpanConverter();
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JsonSerializer serializer = new JsonSerializer();

                converter.WriteJson(writer, new TimeSpan(0, 10, 16, 54, 345), serializer);

                Assert.AreEqual("\"10:16:54.3\"", sb.ToString());
            }
        }
    }
}
