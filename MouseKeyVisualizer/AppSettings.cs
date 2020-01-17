using System;
using System.IO;
using System.Text;
using System.Windows.Documents;
using Newtonsoft.Json;

namespace MouseKeyVisualizer
{
    public class AppSettings
    {
        public CanvasSection CanvasSection { get; set; } = new CanvasSection();

        private static AppSettings _default;
        public static AppSettings Default => _default ?? (_default = ReadConfig());

        private AppSettings() { }

        public void Save()
        {
            var path = Path.Combine(AppPath.CurrentDir, "appsettings.json");
            ConcurrentFile.WriteAllText(path, JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            }));
        }

        private static AppSettings ReadConfig()
        {
            var path = Path.Combine(AppPath.CurrentDir, "appsettings.json");
            if (File.Exists(path))
            {
                var allText = ReadAllTextWithoutCrLf(path);
                if (!string.IsNullOrWhiteSpace(allText))
                {
                    try
                    {
                        var settings = JsonConvert.DeserializeObject<AppSettings>(allText,
                            new JsonSerializerSettings
                            {
                                TypeNameHandling = TypeNameHandling.Auto,
                                ObjectCreationHandling = ObjectCreationHandling.Replace
                            });
                        settings.Save();
                        return settings;
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }
            }

            var config = new AppSettings();
            config.Save();
            return config;
        }

        private static string ReadAllTextWithoutCrLf(string path)
        {
            var sb = new StringBuilder();
            using (var sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    var c = (char)sr.Read();
                    if (c == '\r' || c == '\n') continue;
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public static void SaveDefault()
        {
            Default.Save();
        }
    }
}
