
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
    public class PutAvaliacaoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AvaliacaoController>> _mockLogger;
        private readonly AvaliacaoController _controller;



        public PutAvaliacaoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AvaliacaoController>>();
            _controller = new AvaliacaoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Put_Avaliacao_Return_CreatedAtRoute()
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



            var routeId = 2; // ID diferente do DTO


            // Act
            var result = await _controller.Put(routeId, avaliacaoDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);

        }



        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutAvaliacao_Return_OkResult()
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


            var avaliacao = avaliacaoDto.ToAvaliacao();
            var avaliacaoAtualizado = avaliacao;


            _mockUof.Setup(repo => repo.AvaliacaoRepository.Update(It.IsAny<Avaliacao>()))
                             .Returns(avaliacaoAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Put(avaliacaoDto.AvaliacaoId, avaliacaoDto);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AvaliacaoDTO>(okResult.Value);
            Assert.Equal(avaliacaoDto.AvaliacaoId, returnValue.AvaliacaoId);

        }

    }
}