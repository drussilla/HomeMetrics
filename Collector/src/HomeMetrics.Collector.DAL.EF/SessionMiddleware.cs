using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;

namespace HomeMetrics.Collector.DAL.EF
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _request;

        public SessionMiddleware(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            var contextProvider = (IDbContextProvider)context.RequestServices.GetService(typeof(IDbContextProvider));
            if (contextProvider == null)
            {
                throw new Exception("IDbContext is not registered. Please register it with AddEF() method");
            }

            var lazyContext = new Lazy<Context>(() => new Context());
            contextProvider.SetContext(lazyContext);
            using (new RequestDbContext(lazyContext))
            {
                await _request(context);
            }
        }

        private class RequestDbContext : IDisposable
        {
            private readonly Lazy<Context> _context;

            public RequestDbContext(Lazy<Context> context)
            {
                _context = context;
            }

            public void Dispose()
            {
                if (!_context.IsValueCreated || _context.Value == null) return;

                _context.Value.SaveChanges();
                _context.Value.Dispose();
            }
        }
    }
}