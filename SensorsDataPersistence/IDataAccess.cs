using System;

namespace SensorsDataPersistence
{
    public interface IDataAccess
    {
        void SaveSensorData(SensorsData sensorsData);
        SensorsData GetSensorsData(Guid guid);
    }
}