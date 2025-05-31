
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
    public class DeleteClienteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ClienteController>> _mockLogger;
        private readonly ClienteController _controller;



        public DeleteClienteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ClienteController>>();
            _controller = new ClienteController(_mockUof.Object, _mockLogger.Object);
        }





        [Fact]
        public async Task Delete_Cliente_Return_NotFound()
        {
            // Arrange
            int clienteId = 9999;
            _mockUof.Setup(repo => repo.ClienteRepository.GetAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                    .ReturnsAsync((Cliente)null);


            // Act
            var result = await _controller.Delete(clienteId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"cliente com id={clienteId} não encontrado...", notFoundResult.Value.ToString());

        }



        [Fact]
        public async Task Delete_Cliente_Return_OkObjectResult()
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




            _mockUof.Setup(repo => repo.ClienteRepository.GetAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                .ReturnsAsync(cliente);


            _mockUof.Setup(repo => repo.ClienteRepository.Delete(cliente))
                   .Returns(cliente);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Delete(clienteId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ClienteDTO>(okResult.Value);
            Assert.Equal(clienteId, returnValue.ClienteId);

        }

    }
}