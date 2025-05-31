

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.AvaliacaoTest
{
    public class PostAvaliacaoTest
    {

        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AvaliacaoController>> _mockLogger;
        private readonly AvaliacaoController _controller;



        public PostAvaliacaoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AvaliacaoController>>();
            _controller = new AvaliacaoController(_mockUof.Object, _mockLogger.Object);
        }








        [Fact]
        public async Task Post_HistoricoCorte_Return_CreatedAtRoute()
        {
            // Arrange
            var avaliacaoDto = new AvaliacaoDTO
            {
                AvaliacaoId = 1,
                Nota = 1,
                Comentario = "Muito bom",
                Data = DateTime.Now,
                AgendamentoId = 1,
                ClienteId = 1,
                BarbeiroId = 1
            };




            var avaliacao = avaliacaoDto.ToAvaliacao(); // simula conversão
            var avaliacaoCriado = avaliacao; // assume que Create retorna o mesmo objeto



            _mockUof.Setup(repo => repo.AvaliacaoRepository.Create(It.IsAny<Avaliacao>()))
                  .Returns(avaliacaoCriado);

            _mockUof.Setup(repo => repo.Commit())
                                       .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Post(avaliacaoDto);



            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<AvaliacaoDTO>(createdAtRoute.Value);



            Assert.Equal("ObterAvaliacao", createdAtRoute.RouteName);
            Assert.Equal(avaliacaoDto.AvaliacaoId, returnValue.AvaliacaoId);

        }




        [Fact]
        public async Task Post_Avvaliacao_Returns_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<AvaliacaoController>>();
            var controller = new AvaliacaoController(mockUof.Object, mockLogger.Object);


            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);

        }

    }
}