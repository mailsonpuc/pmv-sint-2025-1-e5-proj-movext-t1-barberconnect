

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.ServicoTest
{
    public class PutServicoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ServicoController>> _mockLogger;
        private readonly ServicoController _controller;


        public PutServicoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ServicoController>>();
            _controller = new ServicoController(_mockUof.Object, _mockLogger.Object);
        }




        //Teste: Put com ID diferente → retorna BadRequest
        [Fact]
        public async Task PutServico_Return_BadRequest()
        {
            // Arrange
            var servicoDto = new ServicoDTO
            {
                ServicoId = 1,
                Nome = "Corte",
                Descricao = "Corte masculino"
            };

            var routeId = 2; // ID diferente do DTO

            // Act
            var result = await _controller.Put(routeId, servicoDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);
        }





        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutServico_Return_OkResult()
        {
            // Arrange
            var servicoDto = new ServicoDTO
            {
                ServicoId = 1,
                Nome = "Corte",
                Descricao = "Corte masculino"
            };

            var servico = servicoDto.ToServico();
            var servicoAtualizado = servico;

            _mockUof.Setup(repo => repo.ServicoRepository.Update(It.IsAny<Servico>()))
                    .Returns(servicoAtualizado);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Put(servicoDto.ServicoId, servicoDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ServicoDTO>(okResult.Value);
            Assert.Equal(servicoDto.ServicoId, returnValue.ServicoId);
        }





    }
}