using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Entities;

namespace Clinic.Core.Services
{
    public interface IUserService
    {
        public Task<UserClass> GetByUserNameAsync(string UserName, string Password);
        public Task<UserClass> AddUserAsync(UserClass user);

    }
}
