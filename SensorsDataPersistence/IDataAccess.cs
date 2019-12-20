using System;
using System.Collections.Generic;

namespace SensorsDataPersistence
{
    public interface IDataAccess
    {
        void SaveSensorData(SensorData sensorsData);
        SensorData GetSensorData(Guid guid);
        IEnumerable<SensorData> GetAllData();
    }
}