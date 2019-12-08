using Fumbbl.Ffb.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Fumbbl
{
    internal class FfbDialogConverter : JsonConverter<FfbDialog>
    {
        private static ReflectedFactory<FfbDialog, string> DialogFactory = new ReflectedFactory<FfbDialog, string>();
        private JsonSerializer Serializer;
        public FfbDialogConverter() : base()
        {
            Serializer = new JsonSerializer();

            Serializer.Converters.Add(new EnumerationConverter());

        }

        public override FfbDialog ReadJson(JsonReader reader, Type objectType, FfbDialog existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);

            if (token == null || !token.HasValues)
            {
                return null;
            }

            try
            {
                string dialogName = token["dialogId"]?.ToString();

                if (!string.IsNullOrEmpty(dialogName))
                {
                    Type dialogType = DialogFactory.GetReflectedClass(dialogName);

                    if (dialogType != null)
                    {
                        FfbDialog result = (FfbDialog)token.ToObject(dialogType, Serializer);
                        return result;
                    }
                }
            } catch (Exception e)
            {

            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, FfbDialog value, JsonSerializer serializer)
        {
            //writer.WriteValue(value.key);
        }
    }
}