

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.ClienteTest
{
    public class PostClienteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ClienteController>> _mockLogger;
        private readonly ClienteController _controller;



        public PostClienteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ClienteController>>();
            _controller = new ClienteController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Post_Cliente_Return_CreatedAtRoute()
        {
            // Arrange
            var clienteDto = new ClienteDTO
            {
                ClienteId = 1,
                Nome = "Fernando",
                Email = "fernando@gmail.com",
                Senha = "ferNando@Nando90",
                Telefone = "949999999",
                Data_Nascimento = DateTime.Now
            };



            var cliente = clienteDto.ToCliente(); // simula conversão
            var clienteCriado = cliente; // assume que Create retorna o mesmo objeto



            _mockUof.Setup(repo => repo.ClienteRepository.Create(It.IsAny<Cliente>()))
                  .Returns(clienteCriado);

            _mockUof.Setup(repo => repo.Commit())
                                       .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Post(clienteDto);


            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<ClienteDTO>(createdAtRoute.Value);


            Assert.Equal("ObterCliente", createdAtRoute.RouteName);
            Assert.Equal(clienteDto.ClienteId, returnValue.ClienteId);

        }




        [Fact]
        public async Task Post_Cliente_Return_BadRequest()
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