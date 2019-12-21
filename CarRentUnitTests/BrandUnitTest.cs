using System;
using System.Collections.Generic;
using Xunit;
using CarRent.Models;
using System.Threading.Tasks;
using Moq;
using CarRent.Interfaces;

namespace CarRent.CarRentUnitTests
{
    public class BrandUnitTest
    {
        List<Brand> users = new List<Brand>
        {
            new Brand() { Name = "test name 1",Description="test description 1" },
            new Brand() { Name = "test name 2", Description="test description 1" },
        };

        [Fact]
        public async Task AddTest()
        {
            var fakeRepository = Mock.Of<IBrandRepository>();
            var brandService = new Services.BrandService(fakeRepository);

            var brand = new Brand() { Name = "test name 2", Description = "test description 1" };
            await brandService.AddAndSave(brand);
        }

        [Fact]
        public async Task GetBrandTest()
        {
            var brands = new List<Brand>
            {
                new Brand() { Name = "test name 1",Description="test description 1" },
                new Brand() { Name = "test name 2", Description="test description 1" },
            };

            var fakeRepositoryMock = new Mock<IBrandRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(brands);


            var brandService = new Services.BrandService(fakeRepositoryMock.Object);

            var resultUsers = await brandService.GetBrands();

            Assert.Collection(resultUsers, barnd =>
            {
                Assert.Equal("test name 1", barnd.Name);
            },
            brand =>
            {
                Assert.Equal("test name 2", brand.Name);
            });
        }

        [Fact]
        public async Task DeleteEntityTest()
        {
            var fakeRepositoryMock = new Mock<IBrandRepository>();
            fakeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(users);


            var brandService = new Services.BrandService(fakeRepositoryMock.Object);

            await brandService.DeleteBrand(2);
        }
    }
}
