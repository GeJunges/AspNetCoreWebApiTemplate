using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AspNetCoreWebApiTemplate.Infrastructure.Repository;
using AspNetCoreWebApiTemplate.IntegrationTests.ContextConfigurationTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.IntegrationTests.Repository
{
    public class UserReadOnlyRepository : IntegrationTestsContext
    {
        private IUnitOfWork unitOfWorkTest;
        private List<User> users;

        [SetUp]
        public void SetUp()
        {
            ResetContext.Reset(contextIntegrationTests);
            unitOfWorkTest = new UnitOfWork(contextIntegrationTests);
            users = CreateUsers();
        }

        [Test]
        public async Task FindAll_ShouldReturnEmptyListIfNoUsers()
        {
            var actual = await unitOfWorkTest.UserReadOnlyRepository.FindAll();

            Assert.IsEmpty(actual);
        }

        [Test]
        public async Task FindAll_ShouldReturnAllUsers()
        {
            var expected = users.Count();
            SetUpUsersOnDataBase();

            var actual = await unitOfWorkTest.UserReadOnlyRepository.FindAll();

            Assert.AreEqual(expected, actual.Count());
        }

        [Test]
        public async Task Find_ShouldReturnUserById()
        {
            var expected = users.Last();
            SetUpUsersOnDataBase();

            var actual = await unitOfWorkTest.UserReadOnlyRepository.Find(expected.Id);

            Assert.AreEqual(expected, actual);
        }

        private void SetUpUsersOnDataBase()
        {
            unitOfWorkTest.UserWritingRepository.Add(users);
            unitOfWorkTest.Complete();
        }

        private List<User> CreateUsers()
        {
            return new List<User> {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Test1",
                    Surname = "Test1",
                    Email = "test1@test.com" },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Test2",
                    Surname = "Test2",
                    Email = "test2@test.com"
                }
            };
        }
    }
}
