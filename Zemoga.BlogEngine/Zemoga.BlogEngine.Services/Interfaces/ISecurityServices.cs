using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZemogaBlogEngine.Entities;

namespace Zemoga.BlogEngine.Services.Interfaces
{
    public interface ISecurityServices : IDisposable
    {
        AspNetUser GetUserByUserName(string userName);
    }
}
