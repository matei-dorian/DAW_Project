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
    public class DescriptionManager : IDescriptionManager
    {
        private readonly IDescriptionRepository _repo;

        public DescriptionManager(IDescriptionRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateDescription(DescriptionModel model)
        {
            var offer = new Description
            {
                Desc = model.Desc,
                LastUpdate = DateTime.Now
            };

            await _repo.Create(offer);
        }

        public async Task<int> DeleteDescription(int id)
        {
            var desc = await _repo.GetById(id);
            if (desc == null)
            {
                return -1;
            }

            await _repo.Delete(desc);
            return 1;
        }

        public async Task<List<DescriptionModel>> GetAll()
        {
            var descriptions = await _repo.GetAll();
            return descriptions;
        }

        public async Task UpdateDescription(DescriptionModel model)
        {
            var desc = await _repo.GetById(model.Id);
            if (desc == null)
            {
                throw new Exception();
            }

            desc.Desc = model.Desc;
            desc.LastUpdate = DateTime.Now;

            await _repo.Update(desc);
        }

        public async Task<DescriptionModel> GetById(int id)
        {
            var desc = _repo.GetAllQuery().FirstOrDefault(x => x.Id == id);
            if (desc == null)
                throw new Exception();
            var model = new DescriptionModel
            {
                Id = desc.Id,
                Desc = desc.Desc,
                LastUpdate = desc.LastUpdate
            };

            return model;
        }
    }
}
