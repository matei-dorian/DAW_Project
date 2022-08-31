using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IShoeOrderRepository
    {
        Task<List<ShoeOrderModel>> GetAll();
        Task<ShoeOrder> GetById(int id);
        Task Create(ShoeOrder shoeOrder);
        Task Update(ShoeOrder shoeOrder);
        Task Delete(ShoeOrder shoeOrder);
        Task<IQueryable<ShoeOrder>> GetAllQuery();
        public IQueryable<ShoeOrder> GetFullList();
    }
}
