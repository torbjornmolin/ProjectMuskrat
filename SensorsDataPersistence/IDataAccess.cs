using System;

namespace SensorsDataPersistence
{
    public interface IDataAccess
    {
        void SaveSensorData(SensorData sensorsData);
        SensorData GetSensorData(Guid guid);
    }
}