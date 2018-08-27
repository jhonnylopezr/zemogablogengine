using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zemoga.BlogEngine.Services.Interfaces;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services
{
    /// <summary>
    /// Set of services of security (Interface)
    /// </summary>
    public class SecurityServices : Service, ISecurityServices
    {
        public SecurityServices(IBlogEngineContext db) : base(db)
        {

        }

        /// <summary>
        /// Gets an user by UserName
        /// </summary>
        /// <param name="userName">Username</param>
        /// <returns>AspNet user</returns>
        public AspNetUser GetUserByUserName(string userName)
        {
            return Context.AspNetUsers
                .FirstOrDefault(it => it.UserName == userName);
        }
    }
}
