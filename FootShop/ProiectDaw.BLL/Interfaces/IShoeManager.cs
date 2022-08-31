using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IShoeManager
    {
        Task CreateShoe(ShoeModel model);
        Task<int> DeleteShoe(int id);
        Task<List<ShoeModel>> GetAll();
        Task UpdateShoe(ShoeModel model); 
        Task<ShoeModel> GetById(int id);
        Task<ShoeModel> GetByName(string name);
        Task<List<String>> GetSizeOfCategory();
        Task<List<ShoeModel>> GetByCategory(string category);
        Task<List<ShoeModel>> GetSorted();
        Task<List<ShoeModel>> GetAllWithOffer();
    }
}
