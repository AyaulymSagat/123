using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Interfaces
{
    public interface IBrandRepository
    {
        void Add(Brand user);
        Task Save();
        Task<List<Brand>> GetAll();
        Task<List<Brand>> GetBrands(Expression<Func<Brand, bool>> predicate);
        Task DeleteBrand(int id);
        bool IsEntityExist(int id);

    }
}
