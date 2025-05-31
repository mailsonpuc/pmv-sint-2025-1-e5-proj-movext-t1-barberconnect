

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
    public class PutHistoricoCorteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HistoricoCorteController>> _mockLogger;
        private readonly HistoricoCorteController _controller;



        public PutHistoricoCorteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HistoricoCorteController>>();
            _controller = new HistoricoCorteController(_mockUof.Object, _mockLogger.Object);

        }




        //Teste: Put com ID diferente → retorna BadRequest
        [Fact]
        public async Task PutHistoricoCorte_Return_BadRequest()
        {
            // Arrange
            var historicoCorteDto = new HistoricoCorteDTO
            {
                HistoricoCorteId = 1,
                Foto = "foto.png",
                Observacoes = "Legal",
                AgendamentoId = 1,
            };

            var routeId = 2; // ID diferente do DTO


            // Act
            var result = await _controller.Put(routeId, historicoCorteDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);

        }





        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutHistoricoCorte_Return_OkResult()
        {

            // Arrange
            var historicoCorteDto = new HistoricoCorteDTO
            {
                HistoricoCorteId = 1,
                Foto = "foto.png",
                Observacoes = "Legal",
                AgendamentoId = 1,
            };



            var historicocorte = historicoCorteDto.ToHistoricoCorte();
            var historicocorteAtualizado = historicocorte;


            _mockUof.Setup(repo => repo.HistoricoCorteRepository.Update(It.IsAny<HistoricoCorte>()))
                             .Returns(historicocorteAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Put(historicoCorteDto.HistoricoCorteId, historicoCorteDto);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HistoricoCorteDTO>(okResult.Value);
            Assert.Equal(historicoCorteDto.HistoricoCorteId, returnValue.HistoricoCorteId);
        }

    }
}