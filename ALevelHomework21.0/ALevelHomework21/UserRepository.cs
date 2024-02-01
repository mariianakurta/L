using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALevelHomework21
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        { 

            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<string> AddUserAsync(string firstName, string lastName)
        {
            var user = new UserEntity()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<UserEntity?> GetUserAsync(string id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
