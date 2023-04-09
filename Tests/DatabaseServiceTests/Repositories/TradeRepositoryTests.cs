using DataBaseService.Database.Models;
using DataBaseService.Database;
using DataBaseService.Mappers.Interfaces;
using DataBaseService.Mappers;
using DataBaseService.Repositories.Interfaces;
using DataBaseService.Repositories;
using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using DTO.BrokerRequests;
using DTO.MarketBrokerObjects;

namespace DatabaseServiceTests.Repositories
{
    class TradeRepositoryTests
    {
        private Guid userId = Guid.NewGuid();
        private Guid credentialId = Guid.NewGuid();

        private ITradeRepository repository;
        private ITradeMapper mapper;

        private DbContextOptions<TPlatformDbContext> dbOptions;

        private DbUserCredential dbUserCredential;
        private Mock<ILogger<TradeRepository>> logger;

        [OneTimeSetUp]
        public void Initialize()
        { 
            mapper = new TradeMapper();
            logger = new Mock<ILogger<TradeRepository>>();

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
           
        }

        [Test]
        public void CreateTransactionTest()
        {
            using TPlatformDbContext dbContextTr = new TPlatformDbContext(dbOptions);
            repository = new TradeRepository(mapper, dbContextTr, logger.Object);

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

            dbContextTr.UsersCredentials.Add(dbUserCredential);
            dbContextTr.UserBalances.Add(userBalance);
            dbContextTr.Portfolios.Add(dbPortfolio);
            dbContextTr.SaveChanges();

            repository.SaveTransaction(transaction);

            Assert.AreEqual(1, dbContextTr.Transactions.CountAsync().Result);

            dbContextTr.Dispose();
        }

        [Test]
        public void GetUserBalanceTest()
        {
            using TPlatformDbContext dbContextBal = new TPlatformDbContext(dbOptions);
            repository = new TradeRepository(mapper, dbContextBal, logger.Object);

            UserBalance balance = repository.GetUserBalance(new GetUserBalanceRequest { UserId = dbUserCredential.UserId });

            Assert.AreEqual(1000, balance.BalanceInRub);
            Assert.AreEqual(0, balance.BalanceInEur);
            Assert.AreEqual(0, balance.BalanceInUsd);
            Assert.AreEqual(dbUserCredential.UserId, balance.UserId);

            dbContextBal.Dispose();
        }
    }
}
