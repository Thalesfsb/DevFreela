using DevFreela.Application.Queries.Projects.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async void ThreeProjectsExists_Executed_ReturnThreeProjectViewModel()
        {
            // Arrange - definir os mocs - instalar pacote
            var projects = new List<Project>
            {
                new Project("Nome Do Teste", "Descricao do teste 1", 1, 2, 10000),
                new Project("Nome Do Teste", "Descricao do teste 2", 1, 2, 20000),
                new Project("Nome Do Teste", "Descricao do teste 3", 1, 2, 30000)
            };

            var pagination = new Pagination("", 10, 5);

            var projectRepositoryMock = new Mock<IProjectRepository>();

            projectRepositoryMock.Setup(pr => pr.GetAllAsync(pagination).Result).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("", pagination.Size, pagination.Page);
            var getAllProjectsQueryHandler = new GetAllProjectsHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList.Data);
            Assert.Equal(projects.Count, projectViewModelList.Data.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync(pagination).Result, Times.Once);

        }
    }
}
