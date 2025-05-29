using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BarberConnect.Api.Test.ServicoTest
{
    public class DeleteServicoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ServicoController>> _mockLogger;
        private readonly ServicoController _controller;

        public DeleteServicoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ServicoController>>();
            _controller = new ServicoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Delete_NonExistentServico_ReturnsNotFound()
        {
            // Arrange
            int servicoId = 99;
            _mockUof.Setup(repo => repo.ServicoRepository.GetAsync(It.IsAny<Expression<Func<Servico, bool>>>()))
                    .ReturnsAsync((Servico)null);

            // Act
            var result = await _controller.Delete(servicoId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains("não encontrada", notFoundResult.Value.ToString());
        }



        [Fact]
        public async Task Delete_Servico_ReturnsOkObjectResult()
        {
            // Arrange
            int servicoId = 1;
            var servico = new Servico
            {
                ServicoId = servicoId,
                Nome = "Corte",
                Descricao = "Corte masculino"
            };

            _mockUof.Setup(repo => repo.ServicoRepository.GetAsync(It.IsAny<Expression<Func<Servico, bool>>>()))
                    .ReturnsAsync(servico);

            _mockUof.Setup(repo => repo.ServicoRepository.Delete(servico))
                    .Returns(servico);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(servicoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ServicoDTO>(okResult.Value);
            Assert.Equal(servicoId, returnValue.ServicoId);
        }


    }
}
