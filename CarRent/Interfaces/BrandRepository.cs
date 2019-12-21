using CarRent.Interfaces;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public class BrandRepository: IBrandRepository
    {
        readonly MyAppDataContext _context;

        public BrandRepository(MyAppDataContext context)
        {
            _context = context;
        }

        public void Add(Brand brand)
        {
            _context.Add(brand);
        }

        public Task DeleteBrand(int id)
        {
            var var = _context.Brands.FindAsync(id);
            _context.Brands.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<Brand>> GetAll()
        {
            return _context.Brands.ToListAsync();

        }

        public Task<List<Brand>> GetBrands(Expression<Func<Brand, bool>> predicate)
        {
            return _context.Brands.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
