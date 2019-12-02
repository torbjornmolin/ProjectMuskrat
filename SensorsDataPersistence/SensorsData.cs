using System;

namespace SensorsDataPersistence
{
    public class SensorsData
    {
        public Guid Identifier { get; set; }
        public int SensorId { get; set; }
        public DateTime SavedAt { get; set; }
        public double Value { get; set; }
        public SensorValueType ValueType { get; set; }
    }
}