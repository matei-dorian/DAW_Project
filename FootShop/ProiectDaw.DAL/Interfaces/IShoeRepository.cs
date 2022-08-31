using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IShoeRepository
    {
        Task<List<ShoeModel>> GetAll();
        Task<Shoe> GetById(int id);
        Task Create(Shoe shoe);
        Task Update(Shoe shoe);
        Task Delete(Shoe shoe);
        IQueryable<Shoe> GetAllQuery();
        IQueryable<ShoeModel> GetWithOffers();
    }
}
