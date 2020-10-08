using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ImageConverter
{
    class Initializer
    {
        public Dictionary<string, string> Data { get; private set; }

        public bool IsInitialized { get; private set; }
    
        public Initializer(string path)
        {
            if (File.Exists(path))
            {
                IsInitialized = true;
            }
            else
            {
                IsInitialized = false;
            }
        }

        public T ReadFile<T>(string path)
        {
            string str = string.Empty, line;

            using (var sr = new StreamReader(path))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    str += line;
                }
            }

            return JsonConvert.DeserializeObject<T>(str);
        }

        public void UpdateRecords(Dictionary<string, string> data, string path)
        {
            var str = JsonConvert.SerializeObject(data, Formatting.Indented);

            File.Create(path);
           
            using(var sw = new StreamWriter(path))
            {
                sw.Write(str);
            }
        }

        public void UpdateRecords<T>(T data, string path)
        {
            var str = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(str);

            using (var sw = new StreamWriter(path))
            {
                sw.Write(str);
            }
        }
    }
}
