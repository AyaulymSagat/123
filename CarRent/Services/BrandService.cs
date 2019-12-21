using CarRent.Interfaces;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public class BrandService
    {
        private readonly IBrandRepository _brand;

        public BrandService(IBrandRepository context)
        {
            _brand = context;
        }

        public async Task<List<Brand>> GetBrands()
        {
            return await _brand.GetAll();
        }

        public async Task AddAndSave(Brand brand)
        {
            _brand.Add(brand);
            await _brand.Save();
        }

        public async Task DeleteBrand(int id)
        {
            await _brand.DeleteBrand(id);
        }

        public bool IsEntityExist(int id)
        {
            return _brand.IsEntityExist(id);
        }
    }
}
