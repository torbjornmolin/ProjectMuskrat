using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SensorsDataPersistence
{
    public class DataAccess<T> : IDataAccess<T> where T : IDataEntry
    {
        private static List<T> data = null;

        readonly string fileName;

        public DataAccess(string fileName)
        {
            if (data == null) data = new List<T>();
            this.fileName = fileName;
            if (System.IO.File.Exists(@fileName))
            {
                LoadDataFromDisc();
            }
        }
        public T GetData(Guid guid)
        {
            var returnData = data.Where(d => d.Identifier == guid).FirstOrDefault();
            return returnData;
        }
        public void SaveData(T entrie)
        {
            data.Add(entrie);
            SaveDataToDisc();
        }

        public IEnumerable<T> GetAllData()
        {
            return data;
        }

        private void SaveDataToDisc()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            using (StreamWriter streamWriter = new StreamWriter(@fileName))
            using (JsonWriter writer = new JsonTextWriter(streamWriter))
            {
                serializer.Serialize(writer, data);
            }
        }
        private void LoadDataFromDisc()
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamReader streamReader = new StreamReader(@fileName))
            using (JsonReader jsonReader = new JsonTextReader(streamReader))
            {
                data = serializer.Deserialize(jsonReader, typeof(List<T>)) as List<T>;
            }
        }
    }
}
