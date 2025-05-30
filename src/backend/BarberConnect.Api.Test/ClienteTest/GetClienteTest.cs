

using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.ClienteTest
{
    public class GetClienteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ClienteController>> _mockLogger;
        private readonly ClienteController _controller;



        public GetClienteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ClienteController>>();
            _controller = new ClienteController(_mockUof.Object, _mockLogger.Object);
        }






        [Fact]
        public async Task GetClienteById_OkResult()
        {
            // Arrange
            var clienteId = 1;
            var cliente = new Cliente
            {
                ClienteId = 1,
                Nome = "Fernando",
                Email = "fernando@gmail.com",
                Senha = "ferNando@Nando90",
                Telefone = "949999999",
                Data_Nascimento = DateTime.Now


            };


            _mockUof.Setup(u => u.ClienteRepository.GetAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                    .ReturnsAsync(cliente);




            //act
            var result = await _controller.Get(clienteId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ClienteDTO>(okResult.Value);
            Assert.Equal(clienteId, returnValue.ClienteId);


        }






        [Fact]
        public async Task GetClienteById_Return_NotFound()
        {
            // Arrange
            var clienteId = 999;
            _mockUof.Setup(u => u.ClienteRepository.GetAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                    .ReturnsAsync((Cliente)null);



            // Act
            var result = await _controller.Get(clienteId);



            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"cliente com id= {clienteId} não encontrado...", notFoundResult.Value);
        }




        [Fact]
        public async Task GetClienteById_Returns_BadRequest()
        {
            // Arrange
            var clienteId = -1;

            // Act
            var result = await _controller.Get(clienteId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }





        [Fact]
        public async Task GetClientes_Return_ListOfClientesDTO()
        {
            // Arrange
            var clientes = new List<Cliente>

        {
        new Cliente {
                ClienteId = 1,
                Nome = "Fernando",
                Email = "fernando@gmail.com",
                Senha = "ferNando@Nando90",
                Telefone = "949999999",
                Data_Nascimento = DateTime.Now
                 },
        new Cliente {
                ClienteId = 1,
                Nome = "pereira",
                Email = "pereira@gmail.com",
                Senha = "pepreirao@Nando90",
                Telefone = "949999999",
                Data_Nascimento = DateTime.Now
                 }

        };

            _mockUof.Setup(repo => repo.ClienteRepository.GetAllAsync())
                    .ReturnsAsync(clientes);


            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<ClienteDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }




    }
}