using System.Linq.Expressions;
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
    public class GetServicoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ServicoController>> _mockLogger;
        private readonly ServicoController _controller;


        // Construtor correto para teste
        public GetServicoTest()
        {
            //iniciando no construtor
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ServicoController>>();
            _controller = new ServicoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task GetServicoById_OKResult()
        {
            // Arrange
            var servicoId = 1;
            var servico = new Servico
            {
                ServicoId = servicoId,
                Nome = "Corte de cabelo",
                Descricao = "Corte masculino",
            };

            _mockUof.Setup(u => u.ServicoRepository.GetAsync(It.IsAny<Expression<Func<Servico, bool>>>()))
                    .ReturnsAsync(servico);

            // Act
            var result = await _controller.Get(servicoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ServicoDTO>(okResult.Value);
            Assert.Equal(servicoId, returnValue.ServicoId);
        }




        [Fact]
        public async Task GetServicoById_Return_NotFound()
        {
            // Arrange
            var servicoId = 999;
            _mockUof.Setup(u => u.ServicoRepository.GetAsync(It.IsAny<Expression<Func<Servico, bool>>>()))
                    .ReturnsAsync((Servico)null);



            // Act
            var result = await _controller.Get(servicoId);



            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"Servico com id= {servicoId} não encontrado...", notFoundResult.Value);
        }





        [Fact]
        public async Task GetServicoById_Returns_BadRequest()
        {
            // Arrange
            var servicoId = -1;

            // Act
            var result = await _controller.Get(servicoId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }





        [Fact]
        public async Task GetServico_Return_ListOfServicosDTO()
        {
            // Arrange
            var servicos = new List<Servico>
    {
        new Servico { ServicoId = 1, Nome = "Corte", Descricao = "Corte de cabelo" },
        new Servico { ServicoId = 2, Nome = "Barba", Descricao = "Barba completa" }
    };

            _mockUof.Setup(repo => repo.ServicoRepository.GetAllAsync())
                    .ReturnsAsync(servicos);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ServicoDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }





    }
}
