using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ALevelHomework21
{
    public interface IUserRepository
    {
        Task<string> AddUserAsync(string firstName, string lastName);
        Task<UserEntity?> GetUserAsync(string id);
    }
}
