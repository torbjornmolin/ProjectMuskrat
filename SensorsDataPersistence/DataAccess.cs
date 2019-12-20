using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SensorsDataPersistence
{
    public class DataAccess : IDataAccess
    {
        private static List<SensorData> data = null;
        public string Path { get; set; }

        readonly string fileName;
        public DataAccess(string fileName)
        {
            if (data == null) data = new List<SensorData>();
            this.fileName = fileName;
            if (System.IO.File.Exists(@fileName))
            {
                LoadDataFromDisc();
            }
        }
        public SensorData GetSensorData(Guid guid)
        {
            var returnData = data.Where(d => d.Identifier == guid).FirstOrDefault();
            return returnData;
        }
        public void SaveSensorData(SensorData sensorsData)
        {
            data.Add(sensorsData);
            SaveDataToDisc();
        }

        public IEnumerable<SensorData> GetAllData()
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
                data = serializer.Deserialize(jsonReader) as List<SensorData>;
            }
        }
    }
}
