using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Eticaret.MVCUI.ExtensionMethods
{
    public static class SessionExtensionMethods
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            string obejctstring = JsonConvert.SerializeObject(value);
            session.SetString(key, obejctstring);
        }
        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            string objectstring = session.GetString(key);
            if (string.IsNullOrEmpty(objectstring))
            {
                return null;
            }
            T value = JsonConvert.DeserializeObject<T>(objectstring);
            return value;
        }
    }
}
