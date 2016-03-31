using System;

namespace HomeMetrics.Collector.DAL.EF
{
    public interface IDbContextProvider
    {
        void SetContext(Lazy<Context> context);

        Context Current { get; }
    }
}