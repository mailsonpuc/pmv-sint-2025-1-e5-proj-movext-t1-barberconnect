

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
    public class PutClienteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<ClienteController>> _mockLogger;
        private readonly ClienteController _controller;



        public PutClienteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<ClienteController>>();
            _controller = new ClienteController(_mockUof.Object, _mockLogger.Object);
        }




        //Teste: Put com ID diferente → retorna BadRequest
        [Fact]
        public async Task PutCliente_Return_BadRequest()
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


            var routeId = 2; // ID diferente do DTO



            // Act
            var result = await _controller.Put(routeId, clienteDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);

        }




        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutCliente_Return_OkResult()
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



            var cliente = clienteDto.ToCliente();
            var clienteAtualizado = cliente;


            _mockUof.Setup(repo => repo.ClienteRepository.Update(It.IsAny<Cliente>()))
                             .Returns(clienteAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);




            // Act
            var result = await _controller.Put(clienteDto.ClienteId, clienteDto);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<ClienteDTO>(okResult.Value);
            Assert.Equal(clienteDto.ClienteId, returnValue.ClienteId);


        }
    }
}