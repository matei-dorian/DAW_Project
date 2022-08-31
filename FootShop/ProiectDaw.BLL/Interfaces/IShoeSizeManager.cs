using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IShoeSizeManager
    {
        Task CreateShoeSize(ShoeSizeModel model);
        Task<int> DeleteShoeSize(int id);
        Task<List<ShoeSizeModel>> GetAll();
        Task<List<ShoeSizeModel>> GetWithShoeId(int id);
        Task UpdateShoeSize(ShoeSizeModel model);
    }
}
