using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services
{
    /// <summary>
    /// Abstract base class for all services
    /// </summary>
    public abstract class Service : IDisposable
    {
        /// <summary>
        /// DbContext of the service
        /// </summary>
        public IBlogEngineContext Context { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DbContext to use in the service (injected by DI)</param>
        public Service(IBlogEngineContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Releases all the resources of the service (used in HierarchichalLifetimeManager strategy)
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
