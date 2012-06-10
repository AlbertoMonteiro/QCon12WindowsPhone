using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QCon12.Mobile.Utils
{
    //Sun Jun 10 13:39:26 +0000 2012
    public class TwitterDateTimeConverter : DateTimeConverterBase
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {}
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = reader.Value.ToString();
            const string format = "ddd MMM dd HH:mm:ss +0000 yyyy";
            var dateTime = DateTime.ParseExact(value, format, new CultureInfo("en-US"));
            return dateTime.Subtract(TimeSpan.FromHours(3));
        }
    }
}
