using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinic.Core.Entities;

namespace Clinic.Core.Repositories
{
    public interface IUserRepository
    {
        public Task<UserClass> GetByUserNameAsync(string UserName, string Password);
        public Task<UserClass> AddUserAsync(UserClass user);

    }
}
