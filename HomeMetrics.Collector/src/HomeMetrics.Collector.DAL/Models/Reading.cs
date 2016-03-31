using System;

namespace HomeMetrics.Collector.DAL.Models
{
    public class Reading : IdModel
    {
        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }
        public float Data { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime CollectedDateTime { get; set; }
    }
}