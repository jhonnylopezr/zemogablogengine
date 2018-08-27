using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services
{
    public abstract class Service : IDisposable
    {
        public IBlogEngineContext Context { get; set; }

        public Service(IBlogEngineContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
