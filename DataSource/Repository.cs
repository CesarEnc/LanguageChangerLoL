using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LanguageChangerLoL.DataSource
{
    public static class Repository
    {
        public static List<string> Languages { get; set; }
        public static void LoadRepository()
        {
            using (StreamReader reader = new StreamReader(@"Data\Languages.json"))
            {
                Languages = JsonSerializer.Deserialize<List<string>>(reader.ReadToEnd());
            }
        }

    }
}
