using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GlobalTicket.TicketManagement.Application.Contracts.Persistence;
using GlobalTicket.TicketManagement.Application.Features.Events.Queries.GetCategoriesList;
using GlobalTicket.TicketManagement.Application.Profile;
using GloboTicket.TicketManagement.Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace GloboTicket.TicketManagement.Application.UnitTests
{
    public class GetCategoriesListQueryHandlerTests
    {
        private Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        private IMapper _mapper;

        public GetCategoriesListQueryHandlerTests()
        {
            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task GetCategoriesListsTest()
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);
            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.Count.ShouldBeOfType<List<GetCategoriesListVM>>();
            result.Count.ShouldBe(4);
        }

        
    }

    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            throw new NotImplementedException();
        }
    }
}