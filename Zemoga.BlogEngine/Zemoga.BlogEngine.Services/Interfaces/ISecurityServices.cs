using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    /// <summary>
    /// Set of services of security (Interface)
    /// </summary>
    public interface ISecurityServices : IDisposable
    {
        /// <summary>
        /// Gets an user by UserName
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>AspNet user</returns>
        AspNetUser GetUserByUserName(string userName);
    }
}
