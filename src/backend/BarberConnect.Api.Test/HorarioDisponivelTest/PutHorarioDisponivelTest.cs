

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
    public class PutHorarioDisponivelTest
    {

        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HorarioDisponivelController>> _mockLogger;
        private readonly HorarioDisponivelController _controller;


        public PutHorarioDisponivelTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HorarioDisponivelController>>();
            _controller = new HorarioDisponivelController(_mockUof.Object, _mockLogger.Object);
        }





        //Teste: Put com ID diferente → retorna BadRequest
        [Fact]
        public async Task PutHorarioDisponivel_Return_BadRequest()
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

            var routeId = 2; // ID diferente do DTO


            // Act
            var result = await _controller.Put(routeId, horarioDisponivelDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);

        }





        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutHorarioDisponivel_Return_OkResult()
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



            var horariodisponivel = horarioDisponivelDto.ToHorarioDisponivel();
            var horariodisponivelAtualizado = horariodisponivel;

            _mockUof.Setup(repo => repo.HorarioDisponivelRepository.Update(It.IsAny<HorarioDisponivel>()))
                   .Returns(horariodisponivelAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);


            // Act
            var result = await _controller.Put(horarioDisponivelDto.HorarioDisponivelId, horarioDisponivelDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HorarioDisponivelDTO>(okResult.Value);
            Assert.Equal(horarioDisponivelDto.HorarioDisponivelId, returnValue.HorarioDisponivelId);

        }

    }
}