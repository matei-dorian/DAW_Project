using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IOfferRepository
    {
        Task<List<OfferModel>> GetAll();
        Task<Offer> GetById(int id);
        Task Create(Offer offer);
        Task Update(Offer offer);
        Task Delete(Offer offer);
        Task<IQueryable<Offer>> GetAllQuery();
    }
}
