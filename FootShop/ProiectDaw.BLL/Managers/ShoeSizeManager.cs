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
    public class ShoeSizeManager : IShoeSizeManager
    {
        private readonly IShoeSizeRepository _repo;

        public ShoeSizeManager(IShoeSizeRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateShoeSize(ShoeSizeModel model)
        {
            var shoeSize = new ShoeSize
            {
                Quantity = model.Quantity,
                ShoeId = model.ShoeId,
                Size = model.Size
            };

            await _repo.Create(shoeSize);
        }

        public async Task<int> DeleteShoeSize(int id)
        {
            var shoeSize = await _repo.GetById(id);
            if (shoeSize == null)
            {
                return -1;
            }

            await _repo.Delete(shoeSize);
            return 1;
        }

        public async Task<List<ShoeSizeModel>> GetAll()
        {
            var shoeSizes = await _repo.GetAll();
            return shoeSizes;
        }

        public async Task UpdateShoeSize(ShoeSizeModel model)
        {
            var shoeSize = await _repo.GetById(model.Id);
            if (shoeSize == null)
            {
                throw new Exception();
            }

            shoeSize.Quantity = model.Quantity;
            await _repo.Update(shoeSize);
        }

        public async Task<List<ShoeSizeModel>> GetWithShoeId(int id)
        {
            var shoes = _repo.GetAllQuery().Where(x => x.ShoeId == id).ToList();
            var list = new List<ShoeSizeModel>();

            if (shoes == null)
                throw new Exception();
            
            foreach(var shoe in shoes)
            {
                var model = new ShoeSizeModel
                {
                    ShoeId = id,
                    Size = shoe.Size,
                    Quantity = shoe.Quantity
                };
                list.Add(model);
            }

            return list;
        }
    }
}
