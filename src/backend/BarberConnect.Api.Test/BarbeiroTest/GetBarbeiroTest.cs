
using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.BarbeiroTest
{
    public class GetBarbeiroTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<BarbeiroController>> _mockLogger;
        private readonly BarbeiroController _controller;



        public GetBarbeiroTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<BarbeiroController>>();
            _controller = new BarbeiroController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task GetBarbeiroById_OkResult()
        {
            // Arrange
            var barbeiroId = 1;
            var barbeiro = new Barbeiro
            {
                BarbeiroId = 1,
                Nome = "Ronaldo",
                Email = "fernando@gmail.com",
                Senha = "ferNando@Nando90",
                Telefone = "949999999",

            };


            _mockUof.Setup(u => u.BarbeiroRepository.GetAsync(It.IsAny<Expression<Func<Barbeiro, bool>>>()))
                 .ReturnsAsync(barbeiro);




            //act
            var result = await _controller.Get(barbeiroId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<BarbeiroDTO>(okResult.Value);
            Assert.Equal(barbeiroId, returnValue.BarbeiroId);


        }





        [Fact]
        public async Task GetBarbeiroById_Return_NotFound()
        {
            // Arrange
            var barbeiroId = 999;
            _mockUof.Setup(u => u.BarbeiroRepository.GetAsync(It.IsAny<Expression<Func<Barbeiro, bool>>>()))
                    .ReturnsAsync((Barbeiro)null);



            // Act
            var result = await _controller.Get(barbeiroId);



            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"barbeiro com id= {barbeiroId} não encontrado...", notFoundResult.Value);
        }




        [Fact]
        public async Task GetBarbeiroById_Returns_BadRequest()
        {
            // Arrange
            var barbeiroId = -1;

            // Act
            var result = await _controller.Get(barbeiroId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }





        [Fact]
        public async Task GetBarbeiros_Return_ListOfBarbeirosDTO()
        {
            // Arrange
            var barbeiros = new List<Barbeiro>
            {
                new Barbeiro {
                      BarbeiroId = 1,
                      Nome = "Ronaldo",
                      Email = "fernando@gmail.com",
                      Senha = "ferNando@Nando90",
                      Telefone = "949999999",
                },
                new Barbeiro {
                      BarbeiroId = 2,
                      Nome = "Venicius",
                      Email = "fve@gmail.com",
                      Senha = "fVenicius@Nando90",
                      Telefone = "949999999",
                }
            };




            _mockUof.Setup(repo => repo.BarbeiroRepository.GetAllAsync())
                    .ReturnsAsync(barbeiros);


            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<BarbeiroDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());



        }
    }
}