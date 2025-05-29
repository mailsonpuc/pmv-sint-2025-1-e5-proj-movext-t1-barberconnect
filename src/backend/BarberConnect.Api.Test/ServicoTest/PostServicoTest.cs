using System.Threading.Tasks;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BarberConnect.Api.Test.ServicoTest
{
    public class PostServicoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ServicoController>> _mockLogger;
        private readonly ServicoController _controller;

        public PostServicoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ServicoController>>();
            _controller = new ServicoController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Post_ValidServico_Returns_CreatedAtRoute()
        {
            // Arrange
            var servicoDto = new ServicoDTO
            {
                ServicoId = 1,
                Nome = "Corte",
                Descricao = "Corte de cabelo"
            };

            var servico = servicoDto.ToServico(); // simula conversão
            var servicoCriado = servico; // assume que Create retorna o mesmo objeto

            _mockUof.Setup(repo => repo.ServicoRepository.Create(It.IsAny<Servico>()))
                    .Returns(servicoCriado);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Post(servicoDto);

            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<ServicoDTO>(createdAtRoute.Value);

            Assert.Equal("ObterServico", createdAtRoute.RouteName);
            Assert.Equal(servicoDto.ServicoId, returnValue.ServicoId);
        }




        [Fact]
        public async Task Post_Servico_Returns_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<ServicoController>>();
            var controller = new ServicoController(mockUof.Object, mockLogger.Object);

            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);
        }







    }
}
