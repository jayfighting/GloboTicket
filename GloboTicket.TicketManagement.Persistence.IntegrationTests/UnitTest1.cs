using System;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace GloboTicket.TicketManagement.Persistence.IntegrationTests
{
    public class GloboTicketDbContextTests
    {
        private string  _logginUserId;

        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _logginUserId = "feafewaf";
        }

        [Fact]
        public void Test1()
        {
        }
    }

    public interface ILoggerUserService
    {
    }
}