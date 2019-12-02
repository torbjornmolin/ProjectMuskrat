using System;

namespace SensorsDataPersistence
{
    public class DataAccess : IDataAccess
    {
        public SensorsData GetSensorsData(Guid guid) => new SensorsData()
        {
            Identifier = Guid.NewGuid(),
            SensorId = 1,
            SavedAt = DateTime.UtcNow,
            Value = 23,
            ValueType = SensorValueType.DegreesCelsius
        };


        public void SaveSensorData(SensorsData sensorsData)
        {
            throw new NotImplementedException();
        }
    }
}
