using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clinic;
using Clinic.Core.Entities;
using Clinic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly DataContext _dataContext;
        public UserRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<UserClass> GetByUserNameAsync(string userName, string Password)
        {
            return await _dataContext.userClass.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == Password);
        }
        public async Task<UserClass> AddUserAsync(UserClass user)
        {
            await _dataContext.userClass.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

    }
}
