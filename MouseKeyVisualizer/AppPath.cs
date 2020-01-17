using System;
using System.IO;

namespace MouseKeyVisualizer
{
    static class AppPath
    {
        static AppPath()
        {
            Type t = typeof(AppPath);
            var infos = t.GetProperties();
            foreach (var propInfo in infos)
            {
                if (!propInfo.Name.EndsWith("Dir")) continue;
                try
                {
                    string dir = (string)propInfo.GetValue(null, null);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                }
                catch (Exception)
                {
                    Console.WriteLine(@"未创建：" + propInfo.Name);
                }
            }
        }

        public static string CurrentDir { get; } = AppDomain.CurrentDomain.BaseDirectory;
    }
}
