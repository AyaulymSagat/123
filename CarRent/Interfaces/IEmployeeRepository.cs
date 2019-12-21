using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);
        Task Save();
        Task<List<Employee>> GetAll();
        Task<List<Employee>> GetEmployees(Expression<Func<Employee, bool>> predicate);
        Task DeleteEmployee(int id);
        bool IsEntityExist(int id);
    }
}
