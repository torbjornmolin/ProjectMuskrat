using System;

namespace SensorsDataPersistence
{
    public class DeviceData : IDataEntry
    {
        public Guid Identifier { get; set; }
        public int DeviceID { get; set; }
        public DateTime SavedAt { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}