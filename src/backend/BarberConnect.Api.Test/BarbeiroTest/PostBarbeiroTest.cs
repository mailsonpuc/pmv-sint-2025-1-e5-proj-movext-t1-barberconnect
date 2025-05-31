

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.BarbeiroTest
{
    public class PostBarbeiroTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<BarbeiroController>> _mockLogger;
        private readonly BarbeiroController _controller;



        public PostBarbeiroTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<BarbeiroController>>();
            _controller = new BarbeiroController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Post_Barbeiro_Return_CreatedAtRoute()
        {
            // Arrange
            var barbeiroDto = new BarbeiroDTO
            {
                BarbeiroId = 1,
                Nome = "Ronaldo",
                Email = "fernando@gmail.com",
                Senha = "ferNando@Nando90",
                Telefone = "949999999",
            };


            var barbeiro = barbeiroDto.ToBarbeiro(); // simula conversão
            var barbeiroCriado = barbeiro; // assume que Create retorna o mesmo objeto




            _mockUof.Setup(repo => repo.BarbeiroRepository.Create(It.IsAny<Barbeiro>()))
                  .Returns(barbeiroCriado);

            _mockUof.Setup(repo => repo.Commit())
           .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Post(barbeiroDto);


            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<BarbeiroDTO>(createdAtRoute.Value);



            Assert.Equal("ObterBarbeiro", createdAtRoute.RouteName);
            Assert.Equal(barbeiroDto.BarbeiroId, returnValue.BarbeiroId);
        }



        [Fact]
        public async Task Post_Barbeiro_Return_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<BarbeiroController>>();
            var controller = new BarbeiroController(mockUof.Object, mockLogger.Object);


            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);
        }



    }
}