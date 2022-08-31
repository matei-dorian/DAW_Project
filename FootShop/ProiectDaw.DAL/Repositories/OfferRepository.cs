using Microsoft.EntityFrameworkCore;
using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _context;

        public OfferRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Offer offer)
        {
            await _context.Offers.AddAsync(offer);
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(Offer offer)
        {
            _context.Remove(offer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<OfferModel>> GetAll()
        {
            var offers = await (await GetAllQuery()).ToListAsync();
            var list = new List<OfferModel>();
            foreach (var offer in offers)
            {
                var offerModel = new OfferModel
                {
                    Id = offer.Id,
                    Discount = offer.Discount,
                    EndDate = offer.EndDate,
                    ShoeId = offer.ShoeId
                };
                list.Add(offerModel);
            }
            return list;
        }

        public async Task<IQueryable<Offer>> GetAllQuery()
        {
            var query = _context.Offers.AsQueryable();
            return query;
        }

        public async Task<Offer> GetById(int id)
        {
            var offer = await _context.Offers.FindAsync(id);
            return offer;
        }

        public async Task Update(Offer offer)
        {
            _context.Offers.Update(offer);
            await _context.SaveChangesAsync();
        }
    }
}
