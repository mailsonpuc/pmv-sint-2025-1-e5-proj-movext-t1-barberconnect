

using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.AvaliacaoTest
{
    public class DeleteAvaliacaoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AvaliacaoController>> _mockLogger;
        private readonly AvaliacaoController _controller;



        public DeleteAvaliacaoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AvaliacaoController>>();
            _controller = new AvaliacaoController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Delete_Avaliacao_Return_NotFound()
        {
            // Arrange
            int avaliacaoId = 9999;
            _mockUof.Setup(repo => repo.AvaliacaoRepository.GetAsync(It.IsAny<Expression<Func<Avaliacao, bool>>>()))
                    .ReturnsAsync((Avaliacao)null);

            // Act
            var result = await _controller.Delete(avaliacaoId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"avaliacao com id={avaliacaoId} não encontrado...", notFoundResult.Value.ToString());
        }





        [Fact]
        public async Task Delete_Avaliacao_Return_OkObjectResult()
        {
            // Arrange
            var avaliacaoId = 1;
            var avaliacao = new Avaliacao
            {
                AvaliacaoId = 1,
                Nota = 1,
                Comentario = "Muito bom",
                Data = DateTime.Now,
                AgendamentoId = 1,
                ClienteId = 1,
                BarbeiroId = 1
            };


            _mockUof.Setup(repo => repo.AvaliacaoRepository.GetAsync(It.IsAny<Expression<Func<Avaliacao, bool>>>()))
                         .ReturnsAsync(avaliacao);


            _mockUof.Setup(repo => repo.AvaliacaoRepository.Delete(avaliacao))
                   .Returns(avaliacao);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Delete(avaliacaoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AvaliacaoDTO>(okResult.Value);
            Assert.Equal(avaliacaoId, returnValue.AvaliacaoId);

        }

    }
}