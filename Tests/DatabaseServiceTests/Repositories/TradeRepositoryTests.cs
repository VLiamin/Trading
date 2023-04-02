using DataBaseService.Database.Models;
using DataBaseService.Database;
using DataBaseService.Mappers.Interfaces;
using DataBaseService.Mappers;
using DataBaseService.Repositories.Interfaces;
using DataBaseService.Repositories;
using DatabaseServiceTests.Comparators;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;

namespace DatabaseServiceTests.Repositories
{
    class TradeRepositoryTests
    {
        private Guid userId = Guid.NewGuid();
        private Guid credentialId = Guid.NewGuid();

        private ITradeRepository repository;
        private ITradeMapper mapper;

        private DbContextOptions<TPlatformDbContext> dbOptions;

        private string firstName = "Adam";
        private string lastName = "Yablokov";
        private string email = "example@gmail.com";
        private DateTime birth = DateTime.MinValue;
        private string passwordHash = "passwordHash";
        private string avatarExtension = "jpeg";
        private byte[] avatar = { 0, 0, 0, 25 };

        private User user;
        private DbUser dbUser;
        private UserCredential credential;
        private DbUserCredential dbCredential;
        private UserAvatar userAvatar;
        private DbUsersAvatars dbUserAvatar;

        private DbUserCredential dbUserCredential;
        private Mock<ILogger<TradeRepository>> logger;
        TPlatformDbContext dbContext;

        [OneTimeSetUp]
        public void Initialize()
        { 
            mapper = new TradeMapper();
            logger = new Mock<ILogger<TradeRepository>>();

            user = new User
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birth,
                Email = email
            };

            dbUser = new DbUser
            {
                Id = userId,
                FirstName = firstName,
                LastName = lastName,
                Birthday = birth
            };

            credential = new UserCredential()
            {
                Id = credentialId,
                UserId = userId,
                Email = email,
                PasswordHash = passwordHash
            };

            dbCredential = new DbUserCredential()
            {
                Id = credentialId,
                UserId = userId,
                Email = email,
                PasswordHash = passwordHash
            };

            userAvatar = new UserAvatar
            {
                Id = userId,
                AvatarExtension = avatarExtension,
                Avatar = avatar,
                UserId = dbUser.Id
            };

            dbUserAvatar = new DbUsersAvatars
            {
                Id = userId,
                AvatarExtension = avatarExtension,
                Avatar = avatar,
                UserId = dbUser.Id
            };

            dbOptions = new DbContextOptionsBuilder<TPlatformDbContext>()
                .UseInMemoryDatabase(databaseName: "Trade")
                .Options;

            dbUserCredential = new DbUserCredential
            {
                Id = credentialId,
                UserId = userId,
                Email = "example@gmail.com",
                PasswordHash = "hashpassword",
                IsActive = true
            };

            dbContext = new TPlatformDbContext(dbOptions);
            repository = new TradeRepository(mapper, dbContext, logger.Object);

        }

        [Test]
        public void CreateTransactionTest()
        {
            Transaction transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                UserId = dbUserCredential.UserId
            };

            DbUserBalance userBalance = new DbUserBalance
            {
                Id = Guid.NewGuid(),
                UserId = dbUserCredential.UserId,
                BalanceInRub = 1000
            };

            DbPortfolio dbPortfolio = new DbPortfolio
            {
                Id = Guid.NewGuid(),
                UserId = dbUserCredential.UserId
            };

            dbContext.UsersCredentials.Add(dbUserCredential);
            dbContext.UserBalances.Add(userBalance);
            dbContext.Portfolios.Add(dbPortfolio);
            dbContext.SaveChanges();

            repository.SaveTransaction(transaction);

            DbUserComparer comparer = new DbUserComparer();
            Assert.AreEqual(1, dbContext.Transactions.CountAsync().Result);
        }
    }
}
