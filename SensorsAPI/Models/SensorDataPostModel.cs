namespace SensorsAPI.Models
{
    public class SensorDataPostModel
    {
        public int SensorId { get; set; }
        public double Value { get; set; }
        public SensorValueType ValueType { get; set; }
    }
}