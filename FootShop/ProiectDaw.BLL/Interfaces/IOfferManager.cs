using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.BLL.Interfaces
{
    public interface IOfferManager
    {
        Task CreateOffer(OfferModel model);
        Task<int> DeleteOffer(int id);
        Task<List<OfferModel>> GetAll();
        Task UpdateOffer(OfferModel model);
    }
}
