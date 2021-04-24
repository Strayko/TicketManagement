using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using TicketManagement.Api.IntegrationTests.Base;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Xunit;

namespace TicketManagement.Api.IntegrationTests.Controllers
{
    [TestFixture]
    public class CategoryControllerTests : IDisposable
    {
        private CustomWebApplicationFactory<Startup> _factory;
        
        [OneTimeSetUp]
        public void Init()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
        }

        [Test]
        public async Task ReturnSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category/all");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<CategoryListVm>>(responseString);
            
            Assert.IsNotEmpty(result);
            Assert.IsInstanceOf<List<CategoryListVm>>(result);
        }

        public void Dispose()
        {
            _factory.Dispose();
        }
    }
}