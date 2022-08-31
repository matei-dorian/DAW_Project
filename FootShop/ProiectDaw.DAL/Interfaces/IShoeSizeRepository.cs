using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IShoeSizeRepository
    {
        Task<List<ShoeSizeModel>> GetAll();
        Task<ShoeSize> GetById(int id);
        Task Create(ShoeSize shoeSize);
        Task Update(ShoeSize shoeSize);
        Task Delete(ShoeSize shoeSize);
        IQueryable<ShoeSize> GetAllQuery();
    }
}
