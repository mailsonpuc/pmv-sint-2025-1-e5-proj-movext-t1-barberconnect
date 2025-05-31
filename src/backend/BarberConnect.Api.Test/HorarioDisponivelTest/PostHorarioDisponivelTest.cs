

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.HorarioDisponivelTest
{
    public class PostHorarioDisponivelTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HorarioDisponivelController>> _mockLogger;
        private readonly HorarioDisponivelController _controller;

        public PostHorarioDisponivelTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HorarioDisponivelController>>();
            _controller = new HorarioDisponivelController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Post_ValidHorarioDisponivel_Returns_CreatedAtRoute()
        {
            // Arrange
            var horarioDisponivelDto = new HorarioDisponivelDTO
            {
                HorarioDisponivelId = 1,
                Date = DateTime.Today,
                HoraInicio = TimeSpan.FromHours(9),
                HoraFim = TimeSpan.FromHours(10),
                Disponivel = true
            };

            var horariodisponivel = horarioDisponivelDto.ToHorarioDisponivel(); // simula conversão
            var horariodisponivelCriado = horariodisponivel; // assume que Create retorna o mesmo objeto


            _mockUof.Setup(repo => repo.HorarioDisponivelRepository.Create(It.IsAny<HorarioDisponivel>()))
                  .Returns(horariodisponivelCriado);

            _mockUof.Setup(repo => repo.Commit())
                            .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Post(horarioDisponivelDto);


            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<HorarioDisponivelDTO>(createdAtRoute.Value);

            Assert.Equal("ObterHorarioDisponivel", createdAtRoute.RouteName);
            Assert.Equal(horarioDisponivelDto.HorarioDisponivelId, returnValue.HorarioDisponivelId);
        }





        [Fact]
        public async Task Post_HorarioDisponivel_Returns_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<HorarioDisponivelController>>();
            var controller = new HorarioDisponivelController(mockUof.Object, mockLogger.Object);

            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);
        }



    }
}