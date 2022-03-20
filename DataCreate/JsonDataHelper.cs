using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DataCreate
{
    public class JsonDataHelper<T>
    {
        public List<T> ReadJsonFile(string jsonFileName)
        {
            using StreamReader reader = new StreamReader($"C:/Users/Barış/Desktop/Mongo/{jsonFileName}");

            string json = reader.ReadToEnd();
            var results = JsonConvert.DeserializeObject<List<T>>(json);
            return results;
        }

    }
}
