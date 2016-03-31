using System.Collections.Generic;
using System.Linq;
using HomeMetrics.Collector.DAL.Models;
using HomeMetrics.Collector.DAL.Repositories;
using Microsoft.Data.Entity;

namespace HomeMetrics.Collector.DAL.EF.Repositories
{
    public class ReadingRepository : IReadingRepository
    {
        private readonly IDbContextProvider _db;

        public ReadingRepository(IDbContextProvider db)
        {
            _db = db;
        }

        public void Add(Reading reading)
        {
            _db.Current.Readings.Add(reading);
        }

        public List<Reading> GetAll()
        {
            return _db.Current.Readings.Include(x => x.Sensor).ToList();
        }
    }
}