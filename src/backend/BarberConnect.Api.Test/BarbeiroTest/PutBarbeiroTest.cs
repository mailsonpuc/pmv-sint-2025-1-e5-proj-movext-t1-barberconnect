

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
    public class PutBarbeiroTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<BarbeiroController>> _mockLogger;
        private readonly BarbeiroController _controller;



        public PutBarbeiroTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<BarbeiroController>>();
            _controller = new BarbeiroController(_mockUof.Object, _mockLogger.Object);
        }



        //Teste: Put com ID diferente → retorna BadRequest
        [Fact]
        public async Task PutBarbeiro_Return_BadRequest()
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


            var routeId = 2; // ID diferente do DTO

            // Act
            var result = await _controller.Put(routeId, barbeiroDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);
        }




        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutBarbeiro_Return_OkResult()
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



            var barbeiro = barbeiroDto.ToBarbeiro();
            var barbeiroAtualizado = barbeiro;


            _mockUof.Setup(repo => repo.BarbeiroRepository.Update(It.IsAny<Barbeiro>()))
                             .Returns(barbeiroAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);





            // Act
            var result = await _controller.Put(barbeiroDto.BarbeiroId, barbeiroDto);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<BarbeiroDTO>(okResult.Value);
            Assert.Equal(barbeiroDto.BarbeiroId, returnValue.BarbeiroId);

        }

    }
}