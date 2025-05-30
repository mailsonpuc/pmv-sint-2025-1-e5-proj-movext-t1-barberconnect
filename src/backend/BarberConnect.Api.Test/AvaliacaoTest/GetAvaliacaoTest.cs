
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
    public class GetAvaliacaoTest
    {

        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AvaliacaoController>> _mockLogger;
        private readonly AvaliacaoController _controller;



        public GetAvaliacaoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AvaliacaoController>>();
            _controller = new AvaliacaoController(_mockUof.Object, _mockLogger.Object);
        }


        [Fact]
        public async Task GetAvaliacaoById_OkResult()
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


            _mockUof.Setup(u => u.AvaliacaoRepository.GetAsync(It.IsAny<Expression<Func<Avaliacao, bool>>>()))
                    .ReturnsAsync(avaliacao);

            //act
            var result = await _controller.Get(avaliacaoId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AvaliacaoDTO>(okResult.Value);
            Assert.Equal(avaliacaoId, returnValue.AvaliacaoId);

        }




        [Fact]
        public async Task GetAvaliacaooById_Return_NotFound()
        {
            // Arrange
            var avaliacaoId = 999;
            _mockUof.Setup(u => u.AvaliacaoRepository.GetAsync(It.IsAny<Expression<Func<Avaliacao, bool>>>()))
                    .ReturnsAsync((Avaliacao)null);


            // Act
            var result = await _controller.Get(avaliacaoId);


            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"avaliacao com id= {avaliacaoId} não encontrado...", notFoundResult.Value);
        }




        [Fact]
        public async Task GetAvaliacaoById_Returns_BadRequest()
        {
            // Arrange
            var avaliacaoId = -1;

            // Act
            var result = await _controller.Get(avaliacaoId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }





        [Fact]
        public async Task GetAvaliacoes_Return_ListOfAvaliacoesDTO()
        {
            // Arrange
            var avaliacoes = new List<Avaliacao>
            {
                new Avaliacao {
                    AvaliacaoId = 1,
                    Nota = 1,
                    Comentario = "Muito bom",
                    Data = DateTime.Now,
                    AgendamentoId = 1,
                    ClienteId = 1,
                    BarbeiroId = 1
                },
                new Avaliacao {
                    AvaliacaoId = 2,
                    Nota = 2,
                    Comentario = "Muito bom, gostei do corte",
                    Data = DateTime.Now,
                    AgendamentoId = 2,
                    ClienteId = 2,
                    BarbeiroId = 2
                },

            };





            _mockUof.Setup(repo => repo.AvaliacaoRepository.GetAllAsync())
                    .ReturnsAsync(avaliacoes);



            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AvaliacaoDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());

        }



    }
}