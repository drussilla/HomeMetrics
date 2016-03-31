using System.Collections.Generic;
using HomeMetrics.Collector.DAL.Models;

namespace HomeMetrics.Collector.DAL.Repositories
{
    public interface IReadingRepository
    {
        void Add(Reading reading);
        List<Reading> GetAll();
    }
}