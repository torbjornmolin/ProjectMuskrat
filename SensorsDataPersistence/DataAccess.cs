using System;
using System.Collections.Generic;
using System.Linq;

namespace SensorsDataPersistence
{
    public class DataAccess : IDataAccess
    {
        private static List<SensorData> data = null;
        public string Path { get; set; }

        public DataAccess()
        {
            if (data == null) data = new List<SensorData>();
        }
        public SensorData GetSensorData(Guid guid)
        {
            var returnData = data.Where(d => d.Identifier == guid).FirstOrDefault();
            return returnData;
            //new SensorData() { Identifier = Guid.NewGuid(), SensorId = 1, SavedAt = DateTime.UtcNow, Value = 23, ValueType = SensorValueType.DegreesCelsius };
        }
        public void SaveSensorData(SensorData sensorsData)
        {
            data.Add(sensorsData);
        }

        public IEnumerable<SensorData> GetAllData()
        {
            return data;
        }
    }
}
