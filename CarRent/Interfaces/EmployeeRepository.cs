using CarRent.Data;
using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRent.Interfaces
{
    public class EmployeeRepository:IEmployeeRepository
    {
        readonly MyAppDataContext _context;

        public EmployeeRepository(MyAppDataContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Add(employee);
        }

        public Task DeleteEmployee(int id)
        {
            var var = _context.Employees.FindAsync(id);
            _context.Employees.Remove(var.Result);
            return _context.SaveChangesAsync();
        }

        public Task<List<Employee>> GetAll()
        {
            return _context.Employees.ToListAsync();

        }

        public Task<List<Employee>> GetEmployees(Expression<Func<Employee, bool>> predicate)
        {
            return _context.Employees.Where(predicate).ToListAsync();
        }

        public bool IsEntityExist(int id)
        {
            return _context.Employees.Any(e => e.EmployeeID == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
