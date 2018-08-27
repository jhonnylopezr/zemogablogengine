using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zemoga.BlogEngine.Services.Interfaces;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services
{
    public class SecurityServices : Service, ISecurityServices
    {
        public SecurityServices(IBlogEngineContext db) : base(db)
        {

        }

        public AspNetUser GetUserByUserName(string userName)
        {
            return Context.AspNetUsers
                .FirstOrDefault(it => it.UserName == userName);
        }
    }
}
