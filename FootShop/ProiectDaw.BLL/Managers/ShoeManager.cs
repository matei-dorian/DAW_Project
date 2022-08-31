using Microsoft.EntityFrameworkCore;
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
    public class ShoeManager : IShoeManager
    {
        private readonly IShoeRepository _repo;

        public ShoeManager(IShoeRepository repo)
        {
            _repo = repo;
        }

        public async Task CreateShoe(ShoeModel model)
        {
            var shoe = new Shoe
            {
                Name = model.Name,
                Brand = model.Brand,
                Price = model.Price,
                Colour = model.Colour,
                Category = model.Category,
                Type = model.Type,
                Image = model.Image,
                Rating = model.Rating
            };

            await _repo.Create(shoe);
        }

        public async Task<int> DeleteShoe(int id)
        {
            var shoe = await _repo.GetById(id);
            if (shoe == null)
            {
                return -1;
            }

            await _repo.Delete(shoe);
            return 1;
        }

        public async Task<List<ShoeModel>> GetAll()
        {
            var shoes = await _repo.GetAll();
            return shoes;
        }

        public async Task UpdateShoe(ShoeModel model)
        {
            var shoe = await _repo.GetById(model.Id);
            if (shoe == null)
            {
                 throw new Exception();
            }

            shoe.Price = model.Price;

            await _repo.Update(shoe);
        }

        public async Task<ShoeModel> GetById(int id)
        {
            var shoe = _repo.GetAllQuery().FirstOrDefault(x => x.Id == id);
            if (shoe == null)
                throw new Exception();
            var model = new ShoeModel
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Price = shoe.Price,
                Colour = shoe.Colour,
                Category = shoe.Category,
                Type = shoe.Type,
                Image = shoe.Image
            };

            return model;
        }

        public async Task<ShoeModel> GetByName(string name)
        {
            var shoe =  _repo.GetAllQuery().FirstOrDefault(x => x.Name == name);
            if (shoe == null)
                throw new Exception();
            var model = new ShoeModel
            {
                Id = shoe.Id,
                Name = shoe.Name,
                Brand = shoe.Brand,
                Price = shoe.Price,
                Colour = shoe.Colour,
                Category = shoe.Category,
                Type = shoe.Type,
                Image = shoe.Image,
                Rating = shoe.Rating
            };

            return model;
        }

        public async Task<List<ShoeModel>> GetAllWithOffer()
        {

            var shoes = await _repo.GetWithOffers().ToListAsync();
            return shoes;
        }

        public async Task<List<String>> GetSizeOfCategory()
        {
            var sizeOfCategory = _repo.GetAllQuery()
                .GroupBy(x => x.Category)
                .Select(x => new
                {
                    Key = x.Key,
                    Count = x.Count()
                });

            var list = new List<String>();

            foreach (var obj in sizeOfCategory)
            {
                list.Add($"Category: {obj.Key}, Count: {obj.Count}");
            }

            return list;

        }

        public async Task<List<ShoeModel>> GetByCategory(string category)
        {
            var shoes = _repo.GetAllQuery().Where(x => x.Category == category);
            if (shoes == null)
                throw new Exception();

            var list = new List<ShoeModel>();
            foreach (var shoe in shoes) 
            {
                var model = new ShoeModel
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Brand = shoe.Brand,
                    Price = shoe.Price,
                    Colour = shoe.Colour,
                    Category = shoe.Category,
                    Type = shoe.Type,
                    Image = shoe.Image
                };

                list.Add(model);


            };

            return list;

        }

        public async Task<List<ShoeModel>> GetSorted()
        {
            var shoes = _repo.GetAllQuery().OrderBy(x => x.Price);
            if (shoes == null)
                throw new Exception();

            var list = new List<ShoeModel>();
            foreach (var shoe in shoes)
            {
                var model = new ShoeModel
                {
                    Id = shoe.Id,
                    Name = shoe.Name,
                    Brand = shoe.Brand,
                    Price = shoe.Price,
                    Colour = shoe.Colour,
                    Category = shoe.Category,
                    Type = shoe.Type,
                    Image = shoe.Image
                };

                list.Add(model);


            };

            return list;

        }
    }
}
