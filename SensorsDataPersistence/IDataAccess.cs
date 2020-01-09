using System;
using System.Collections.Generic;

namespace SensorsDataPersistence
{
    public interface IDataAccess<T> where T : IDataEntry
    {
        void SaveData(T entrie);
        T GetData(Guid guid);
        IEnumerable<T> GetAllData();
    }
}