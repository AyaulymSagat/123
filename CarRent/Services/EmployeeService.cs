using CarRent.Interfaces;
using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeService(IEmployeeRepository context)
        {
            _employee = context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await _employee.GetAll();
        }

        public async Task AddAndSave(Employee employee)
        {
            _employee.Add(employee);
            await _employee.Save();
        }

        public async Task DeleteEmployee(int id)
        {
            await _employee.DeleteEmployee(id);
        }

        public bool IsEntityExist(int id)
        {
            return _employee.IsEntityExist(id);
        }
    }
}
