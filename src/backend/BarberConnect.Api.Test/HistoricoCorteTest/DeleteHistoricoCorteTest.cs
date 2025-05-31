

using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.HistoricoCorteTest
{
    public class DeleteHistoricoCorteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HistoricoCorteController>> _mockLogger;
        private readonly HistoricoCorteController _controller;



        public DeleteHistoricoCorteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HistoricoCorteController>>();
            _controller = new HistoricoCorteController(_mockUof.Object, _mockLogger.Object);

        }





        [Fact]
        public async Task Delete_HistoricoCorte_Return_NotFound()
        {
            // Arrange
            int historicocorteId = 9999;
            _mockUof.Setup(repo => repo.HistoricoCorteRepository.GetAsync(It.IsAny<Expression<Func<HistoricoCorte, bool>>>()))
                    .ReturnsAsync((HistoricoCorte)null);


            // Act
            var result = await _controller.Delete(historicocorteId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"historicoCorte com id={historicocorteId} não encontrada...", notFoundResult.Value.ToString());

        }




        [Fact]
        public async Task Delete_HistoricoCorte_Return_OkObjectResult()
        {
            // Arrange
            var historicoCorteId = 1;
            var historicoCorte = new HistoricoCorte
            {
                HistoricoCorteId = 1,
                Foto = "foto.png",
                Observacoes = "Legal",
                AgendamentoId = 1,
            };



            _mockUof.Setup(repo => repo.HistoricoCorteRepository.GetAsync(It.IsAny<Expression<Func<HistoricoCorte, bool>>>()))
                .ReturnsAsync(historicoCorte);


            _mockUof.Setup(repo => repo.HistoricoCorteRepository.Delete(historicoCorte))
                   .Returns(historicoCorte);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Delete(historicoCorteId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HistoricoCorteDTO>(okResult.Value);
            Assert.Equal(historicoCorteId, returnValue.HistoricoCorteId);

        }

    }
}