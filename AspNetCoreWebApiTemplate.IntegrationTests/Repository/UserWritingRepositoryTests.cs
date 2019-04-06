using AspNetCoreWebApiTemplate.Domain.Interfaces;
using AspNetCoreWebApiTemplate.Domain.ObjectModel;
using AspNetCoreWebApiTemplate.Infrastructure.Repository;
using AspNetCoreWebApiTemplate.IntegrationTests.ContextConfigurationTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCoreWebApiTemplate.IntegrationTests.Repository
{
    public class UserWritingRepositoryTests : IntegrationTestsContext
    {
        private IUnitOfWork unitOfWorkTest;
        private User user;

        [SetUp]
        public void SetUp()
        {
            ResetContext.Reset(contextIntegrationTests);
            unitOfWorkTest = new UnitOfWork(contextIntegrationTests);
            user = CreateUser();
        }

        [Test]
        public void Add_ShouldInsertUser()
        {
            unitOfWorkTest.UserWritingRepository.Add(user);
            var actual = unitOfWorkTest.Complete();

            Assert.True(actual == 1);
        }

        [Test]
        public async Task Add_ShouldInsertUsers()
        {
            await unitOfWorkTest.UserWritingRepository.Add(new List<User> { user });
            var actual = await unitOfWorkTest.CompleteAsync();

            Assert.True(actual == 1);
        }

        [Test]
        public void Add_ShouldUpdateUser()
        {
            SetUpUserOnDataBase();
            user.Name = "Updated";

            unitOfWorkTest.UserWritingRepository.Update(user);
            var actual = unitOfWorkTest.Complete();

            Assert.True(actual == 1);
        }

        [Test]
        public void Add_ShouldDeleteUser()
        {
            SetUpUserOnDataBase();

            unitOfWorkTest.UserWritingRepository.Remove(user);
            var actual = unitOfWorkTest.Complete();

            Assert.True(actual == 1);
        }

        [Test]
        public void Add_ShouldDeleteUsers()
        {
            SetUpUserOnDataBase();

            unitOfWorkTest.UserWritingRepository.Remove(new List<User> { user });
            var actual = unitOfWorkTest.Complete();

            Assert.True(actual == 1);
        }

        private void SetUpUserOnDataBase()
        {
            unitOfWorkTest.UserWritingRepository.Add(user);
            unitOfWorkTest.Complete();
        }

        private User CreateUser()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Surname = "Test",
                Email = "test@test.com"
            };
        }
    }
}
