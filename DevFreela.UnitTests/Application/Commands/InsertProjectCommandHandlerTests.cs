using DevFreela.Application.Commands.Projects.InsertProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class InsertProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            // Arrange
            var projectRepository = new Mock<IProjectRepository>();
            var mediator = new Mock<IMediator>();

            var insertProjectCommand = new InsertProjectCommand("Teste", "Descricao", 1, 2, 100000);
            var insertProjectCommandHandler = new InsertProjectHandler(projectRepository.Object, mediator.Object);

            // Act
            var id = await insertProjectCommandHandler.Handle(insertProjectCommand, new CancellationToken());

            // Assert
            Assert.NotNull(id);
            Assert.True(id.Data >= 0);

            projectRepository.Verify(pr => pr.Add(It.IsAny<Project>()), Times.Once);

        }
    }
}
