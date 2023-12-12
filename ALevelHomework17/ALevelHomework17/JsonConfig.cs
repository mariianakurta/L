using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ALevelHomework17
{
    public class JsonConfig
    {
        public int BackNumber { get; set; }

        public static JsonConfig Load(string filePath)
        {
            try
            {
                string jsonText = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<JsonConfig>(jsonText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
