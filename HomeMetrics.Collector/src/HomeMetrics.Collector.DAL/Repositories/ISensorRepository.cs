using HomeMetrics.Collector.DAL.Models;

namespace HomeMetrics.Collector.DAL.Repositories
{
    public interface ISensorRepository
    {
        void Add(Sensor sensor);
    }
}