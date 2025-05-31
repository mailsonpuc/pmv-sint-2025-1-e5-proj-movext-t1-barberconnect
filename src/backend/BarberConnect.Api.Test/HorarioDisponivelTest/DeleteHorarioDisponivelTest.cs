


using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.HorarioDisponivelTest
{
    public class DeleteHorarioDisponivelTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HorarioDisponivelController>> _mockLogger;
        private readonly HorarioDisponivelController _controller;


        public DeleteHorarioDisponivelTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HorarioDisponivelController>>();
            _controller = new HorarioDisponivelController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Delete_HorarioDispponivel_ReturnsNotFound()
        {
            // Arrange
            int horariodisponivelId = 9999;
            _mockUof.Setup(repo => repo.HorarioDisponivelRepository.GetAsync(It.IsAny<Expression<Func<HorarioDisponivel, bool>>>()))
                    .ReturnsAsync((HorarioDisponivel)null);

            // Act
            var result = await _controller.Delete(horariodisponivelId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"horarioDisponivel com id={horariodisponivelId} não encontrada...", notFoundResult.Value.ToString());
        }




        [Fact]
        public async Task Delete_HorarioDisponiveo_Returns_OkObjectResult()
        {
            // Arrange
            int horariodisponivelId = 1;

            var horarioDisponivel = new HorarioDisponivel
            {
                HorarioDisponivelId = horariodisponivelId,
                Date = DateTime.Today,
                HoraInicio = TimeSpan.FromHours(9),
                HoraFim = TimeSpan.FromHours(10),
                Disponivel = true
            };

            _mockUof.Setup(repo => repo.HorarioDisponivelRepository.GetAsync(It.IsAny<Expression<Func<HorarioDisponivel, bool>>>()))
                .ReturnsAsync(horarioDisponivel);

            _mockUof.Setup(repo => repo.HorarioDisponivelRepository.Delete(horarioDisponivel))
                   .Returns(horarioDisponivel);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Delete(horariodisponivelId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HorarioDisponivelDTO>(okResult.Value);
            Assert.Equal(horariodisponivelId , returnValue.HorarioDisponivelId);


        }

    }
}