using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace Lab6.Services
{
    public class SettingsService
    {
        private const string SettingsFile = "settings.json";

        public T LoadSettings<T>() where T : new()
        {
            if (File.Exists(SettingsFile))
            {
                string json = File.ReadAllText(SettingsFile);
                return JsonConvert.DeserializeObject<T>(json);
            }
            return new T();
        }

        public void SaveSettings<T>(T settings)
        {
            string json = JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(SettingsFile, json);
        }
    }
}