using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectWorks()
        {
            // Padrão AAA - Arrange - Act - Assert visa a organização do teste unitário
            // Padrão Given_When_Then
            var project = new Project("Nome de teste", "Descrição de teste", 1, 2, 100000);

            // Validando a inicializacao do objeto
            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotNull(project.Description);
            Assert.NotEmpty(project.Description);

            project.Start();

            //  Validando se o sart está ok
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            Assert.NotEmpty(project.Title);
        }
    }
}
