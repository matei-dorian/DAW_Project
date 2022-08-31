using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IUserManager
    {
        Task<int> DeleteUser(int id);
        Task<List<UserModel>> GetAll();
    }
}
