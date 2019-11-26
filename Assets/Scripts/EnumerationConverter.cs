using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Fumbbl
{
    internal class EnumerationConverter : JsonConverter<FFBEnumeration>
    {
        public override FFBEnumeration ReadJson(JsonReader reader, Type objectType, FFBEnumeration existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return new FFBEnumeration() { key = s };
        }

        public override void WriteJson(JsonWriter writer, FFBEnumeration value, JsonSerializer serializer)
        {
            writer.WriteValue(value.key);
        }
    }
}