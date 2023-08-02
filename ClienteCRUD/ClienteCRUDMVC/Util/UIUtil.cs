using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClienteCRUDMVC.Util
{
    public static class UIUtil
    {
        public static List<T> ToList<T>(this JArray jsonArray)
        {
            var result = new List<T>();

            foreach (var json in jsonArray)
            {
                try
                {
                    result.Add(JsonConvert.DeserializeObject<T>(json.ToString()));
                }
                catch { }                
            }

            return result;
        }

        public static bool TryParseJson<T>(this string obj, out T result)
        {
            try
            {
                // Validate missing fields of object
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.MissingMemberHandling = MissingMemberHandling.Error;

                result = JsonConvert.DeserializeObject<T>(obj, settings);
                return true;
            }
            catch (Exception)
            {
                result = default(T);
                return false;
            }
        }
    }
}
