

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.HistoricoCorteTest
{
    public class PostHistoricoCorteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HistoricoCorteController>> _mockLogger;
        private readonly HistoricoCorteController _controller;



        public PostHistoricoCorteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HistoricoCorteController>>();
            _controller = new HistoricoCorteController(_mockUof.Object, _mockLogger.Object);

        }




        [Fact]
        public async Task Post_HistoricoCorte_Return_CreatedAtRoute()
        {
            // Arrange

            var historicoCorteDto = new HistoricoCorteDTO
            {
                HistoricoCorteId = 1,
                Foto = "foto.png",
                Observacoes = "Legal",
                AgendamentoId = 1,
            };


            var historicocorte = historicoCorteDto.ToHistoricoCorte(); // simula conversão
            var historicocorteCriado = historicocorte; // assume que Create retorna o mesmo objeto



            _mockUof.Setup(repo => repo.HistoricoCorteRepository.Create(It.IsAny<HistoricoCorte>()))
                  .Returns(historicocorteCriado);

            _mockUof.Setup(repo => repo.Commit())
                                       .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Post(historicoCorteDto);



            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<HistoricoCorteDTO>(createdAtRoute.Value);


            Assert.Equal("ObterHistorioCorte", createdAtRoute.RouteName);
            Assert.Equal(historicoCorteDto.HistoricoCorteId, returnValue.HistoricoCorteId);

        }






        [Fact]
        public async Task Post_HistoricoCorte_Returns_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<HistoricoCorteController>>();
            var controller = new HistoricoCorteController(mockUof.Object, mockLogger.Object);


            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);

        }


    }
}