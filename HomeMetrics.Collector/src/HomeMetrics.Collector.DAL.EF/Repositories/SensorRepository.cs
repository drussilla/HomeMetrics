using HomeMetrics.Collector.DAL.Models;
using HomeMetrics.Collector.DAL.Repositories;

namespace HomeMetrics.Collector.DAL.EF.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        private readonly IDbContextProvider _db;

        public SensorRepository(IDbContextProvider db)
        {
            _db = db;
        }

        public void Add(Sensor sensor)
        {
            _db.Current.Sensors.Add(sensor);
        }
    }
}