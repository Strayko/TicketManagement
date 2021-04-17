using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Shouldly;
using TicketManagement.Application.Contracts.Persistence;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using TicketManagement.Application.Profiles;
using TicketManagement.Application.UnitTests.Mocks;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Application.UnitTests.Categories.Queries
{
    [TestFixture]
    public class GetCategoriesListQueryHandlerTests
    {
        private IMapper _mapper;
        private Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        
        [SetUp]
        public void SetUp()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Test]
        public async Task GetCategoriesListTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();
            result.Count.ShouldBe(4);
        }
    }
}