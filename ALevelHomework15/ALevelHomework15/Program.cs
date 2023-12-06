using System;
using System.IO;
using System.Threading.Tasks;

namespace ALevelHomework15
{
    class Program
    {
        public static async Task<string> HelloFile()
        {
            Console.WriteLine("Hello");
            using (var reader = new StreamReader("Hello.txt"))
            {
                string content = await reader.ReadToEndAsync();
                Console.WriteLine("Hello: " + content);
                return content;
            }
        }

        public static async Task<string> WorldFile()
        {
            Console.WriteLine("World");
            using (var reader = new StreamReader("World.txt"))
            {
                string data = await reader.ReadToEndAsync();
                Console.WriteLine("World: " + data);
                return data;
            }
        }

        public static async Task<string> TextExtracting()
        {
            Console.WriteLine();

            Task<string> helloFile = HelloFile();
            Task<string> worldFile = WorldFile();

            await Task.WhenAll(helloFile, worldFile);

            string concatenatedText = helloFile.Result + worldFile.Result;
            return concatenatedText;
        }

        public static void SynchronMethod()
        {
            string result = TextExtracting().Result;
            Console.WriteLine("Result of concatenation: " + result);
        }

        public static async Task AsynchronMethod()
        {
            await TextExtracting();
            Console.WriteLine("Concatenation executed.");
        }
    }
}
