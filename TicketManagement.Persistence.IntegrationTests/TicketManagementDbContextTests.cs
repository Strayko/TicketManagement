using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shouldly;
using TicketManagement.Application.Contracts;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Persistence.IntegrationTests
{
    [TestFixture]
    public class TicketManagementDbContextTests
    {
        private TicketManagementDbContext _ticketManagementDbContext;
        private Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private string _loggedInUserId;

        [SetUp]
        public void SetUp()
        {
            var dbContextOptions =
                new DbContextOptionsBuilder<TicketManagementDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _ticketManagementDbContext =
                new TicketManagementDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Test]
        public async Task Save_SetCreatedByProperty()
        {
            var ev = new Event() {EventId = Guid.NewGuid(), Name = "Test event"};

            _ticketManagementDbContext.Events.Add(ev);
            await _ticketManagementDbContext.SaveChangesAsync();
            
            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}