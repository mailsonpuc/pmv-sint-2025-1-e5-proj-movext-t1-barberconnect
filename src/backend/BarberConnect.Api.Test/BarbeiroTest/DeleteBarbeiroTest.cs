

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
    public class DeleteBarbeiroTest
    {

        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<BarbeiroController>> _mockLogger;
        private readonly BarbeiroController _controller;



        public DeleteBarbeiroTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<BarbeiroController>>();
            _controller = new BarbeiroController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Delete_Barbeiro_Return_NotFound()
        {
            // Arrange
            int barbeiroId = 9999;
            _mockUof.Setup(repo => repo.BarbeiroRepository.GetAsync(It.IsAny<Expression<Func<Barbeiro, bool>>>()))
                    .ReturnsAsync((Barbeiro)null);

            // Act
            var result = await _controller.Delete(barbeiroId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"barbeiro com id={barbeiroId} não encontrado...", notFoundResult.Value.ToString());

        }



        [Fact]
        public async Task Delete_Barbeiro_Return_OkObjectResult()
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

            _mockUof.Setup(repo => repo.BarbeiroRepository.GetAsync(It.IsAny<Expression<Func<Barbeiro, bool>>>()))
                .ReturnsAsync(barbeiro);


            _mockUof.Setup(repo => repo.BarbeiroRepository.Delete(barbeiro))
                   .Returns(barbeiro);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Delete(barbeiroId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<BarbeiroDTO>(okResult.Value);
            Assert.Equal(barbeiroId, returnValue.BarbeiroId);
        }
        
    }
}