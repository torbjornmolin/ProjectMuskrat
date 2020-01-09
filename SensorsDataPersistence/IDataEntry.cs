using System;

namespace SensorsDataPersistence
{
    public interface IDataEntry
    {
        Guid Identifier { get; set; }
    }
}