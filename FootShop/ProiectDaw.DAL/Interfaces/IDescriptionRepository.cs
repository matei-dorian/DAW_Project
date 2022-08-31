using ProiectDaw.DAL.Entities;
using ProiectDaw.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDaw.DAL.Interfaces
{
    public interface IDescriptionRepository
    {
        Task<List<DescriptionModel>> GetAll();
        Task<Description> GetById(int id);
        Task Create(Description desc);
        Task Update(Description desc);
        Task Delete(Description desc);
        IQueryable<Description> GetAllQuery();
    }
}
