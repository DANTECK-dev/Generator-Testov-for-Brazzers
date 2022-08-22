using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Generator_Testov_for_Brazzers
{
    internal class Json
    {
        public static Data ReadJson()
        {
            string text = File.ReadAllText(MainWindow.Json_Path);
            if (text == "") text = "{}";
            return JsonSerializer.Deserialize<Data>(text);
        }
        public static void WriteJson(Data data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(MainWindow.Json_Path, json);
        }
    }
}
