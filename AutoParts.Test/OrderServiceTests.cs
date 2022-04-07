using AutoParts.Core.Contracts;
using AutoParts.Core.Models;
using AutoParts.Core.Services;
using AutoParts.Infrastructure.Data.Models;
using AutoParts.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoParts.Test
{
    public class Tests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbCOntext dbContext;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbCOntext();
            var serviceCollection = new ServiceCollection();

            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IOrderService, OrderService>()
                .BuildServiceProvider();

            var repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void UnknownCustomerException()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "12345"
            };

            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.PlaceOrder(order), "Unknown customer");
        }

        [Test]
        public void KnownCustomerSuccess()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "testingNumber"
            };

            var service = serviceProvider.GetService<IOrderService>();

            Assert.DoesNotThrowAsync(async () => await service.PlaceOrder(order));
        }

        [Test]
        public void NotEnoughPartsException()
        {
            var order = new CustomerOrder()
            {
                CustomerNumber = "testingNumber",
                Parts = new List<PartOrder>()
                {
                   new PartOrder()
                   {
                    SerialNumber = "7777777",
                    Count = 9
                   }
                }
            };
            
            var service = serviceProvider.GetService<IOrderService>();

            Assert.CatchAsync<ArgumentException>(async () => await service.PlaceOrder(order), "Not enough quantity");
        }

        //[Test]
        //public void EnoughPartsSuccess()
        //{
        //    var order = new CustomerOrder()
        //    {
        //        CustomerNumber = "testingNumber",
        //        Parts = new List<PartOrder>()
        //        {
        //           new PartOrder()
        //           {
        //            SerialNumber = "7777777",
        //            Count = 2
        //           }
        //        }
        //    };

        //    var service = serviceProvider.GetService<IOrderService>();

        //    Assert.DoesNotThrowAsync(async () => await service.PlaceOrder(order));
        //}


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var customer = new Contragent()
            {
                CustomerNumber = "testingNumber",
                Name = "Pesho"
            };

            var part = new Part()
            {
                Name = "V8",
                SerialNumber = "7777777",
                Manufacturer = "Audi Germany",
                CarBrand = "Audi",
                CarModel = "RS7",
                Price = 25000,
                Date = DateTime.Now,
                ImageUrl="www",
                Description = "fast",
                Category = new Category()
                {
                    Name = "Engine"
                },
                StoreHouses = new List<StoreHouse>()
                {
                    new StoreHouse()
                    {
                        PartsCount = 7,
                        Number = "5",
                        Section = "11D",
                        IsInUse = true
                    }
                }
            };

            await repo.AddAsync(part);
            await repo.AddAsync(customer);
            await repo.SaveChangesAsync();
        }
    }
}