using BarberConnect.Api.Controllers;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BarberConnect.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetServicos_ReturnsListOfServicos()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Servico>>();
            var expectedServicos = new List<Servico>
            {
                new Servico { Id = 1, Nome = "Corte de Cabelo" },
                new Servico { Id = 2, Nome = "Barba" }
            };
            
            mockRepo.Setup(repo => repo.GetAllAsync())
                   .ReturnsAsync(expectedServicos);
            
            var controller = new ServicosController(mockRepo.Object);

            // Act
            var result = await controller.GetServicos();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Servico>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValue = Assert.IsType<List<Servico>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }
    }
}