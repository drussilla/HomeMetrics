using System;

namespace HomeMetrics.Collector.DAL.EF
{
    public class LazyDbContextProvider : IDbContextProvider
    {
        private Lazy<Context> _currentContext;
        public void SetContext(Lazy<Context> currentContext)
        {
            _currentContext = currentContext;
        }

        public Context Current => _currentContext.Value;
    }
}