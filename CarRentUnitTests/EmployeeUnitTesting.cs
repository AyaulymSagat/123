using CarRent.Interfaces;
using CarRent.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarRent.CarRentUnitTests
{
    public class EmployeeUnitTesting
    {

        List<Employee> employees = new List<Employee>
        {
            new Employee() { Email="aya@gmail.com",Name = "test name 1",Surname="test surname 1",passportID=1 },
            new Employee() { Email="aya2@gmail.com",Name = "test name 2",Surname="test surname 2",passportID=1 },
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IEmployeeRepository>();
            var employeeService = new Services.EmployeeService(fakeRepository);

            var employee = new Employee() { Email = "aya@gmail.com", Name = "test name 1", Surname = "test surname 1", passportID = 1 };
            await employeeService.AddAndSave(employee);
        }

        [Fact]
        public async Task GetEmployeeTest()
        {
            var employees = new List <Employee>
            {
                    new Employee() { Email = "aya@gmail.com", Name = "test name 1", Surname = "test surname 1", passportID = 1 },
                new Employee() { Email = "aya2@gmail.com", Name = "test name 2", Surname = "test surname 2", passportID = 1 },
            };

            var fakeRepositoryMock = new Mock<IEmployeeRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(employees);


            var employeeService = new Services.EmployeeService(fakeRepositoryMock.Object);

            var resultUsers = await employeeService.GetEmployees();

            Assert.Collection(resultUsers, employee =>
            {
                Assert.Equal("test name 1", employee.Name);
            },
            employee =>
            {
                Assert.Equal("test name 2", employee.Name);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IEmployeeRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(employees);


            var employeeService = new Services.EmployeeService(fakeRepositoryMock.Object);

            await employeeService.DeleteEmployee(2);
        }
    }
}
