using ProiectDaw.BLL.Interfaces;
using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Interfaces;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Managers
{
    public class OfferManager : IOfferManager
    {
        private readonly IOfferRepository _repo;

        public OfferManager(IOfferRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateOffer(OfferModel model)
        {
            var offer = new Offer
            {
                Discount = model.Discount,
                EndDate = model.EndDate,
                ShoeId = model.ShoeId
            };

            await _repo.Create(offer);
        }

        public async Task<int> DeleteOffer(int id)
        {
            var offer = await _repo.GetById(id);
            if (offer == null)
            {
                return -1;
            }

            await _repo.Delete(offer);
            return 1;
        }

        public async Task<List<OfferModel>> GetAll()
        {
            var offers = await _repo.GetAll();
            return offers;
        }

        public async Task UpdateOffer(OfferModel model)
        {
            var offer = await _repo.GetById(model.Id);
            if (offer == null)
            {
                throw new Exception();
            }

            offer.Discount = model.Discount;
            offer.EndDate = model.EndDate;
            offer.ShoeId = model.ShoeId;

            await _repo.Update(offer);
        }
    }
}
