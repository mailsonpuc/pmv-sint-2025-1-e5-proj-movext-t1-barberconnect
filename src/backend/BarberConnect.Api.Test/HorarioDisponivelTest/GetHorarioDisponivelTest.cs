using System.Collections.Generic;
using System.Threading.Tasks;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System.Linq;
using System;
using System.Linq.Expressions;

namespace BarberConnect.Api.Test.HorarioDisponivelTest
{
    public class GetHorarioDisponivelTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HorarioDisponivelController>> _mockLogger;
        private readonly HorarioDisponivelController _controller;

        public GetHorarioDisponivelTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HorarioDisponivelController>>();
            _controller = new HorarioDisponivelController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task GetHorarioDisponivelById_OkResult()
        {
            // Arrange
            var horarioDisponivelId = 1;
            var horario = new HorarioDisponivel
            {
                HorarioDisponivelId = 1,
                Date = DateTime.Today,
                HoraInicio = TimeSpan.FromHours(9),
                HoraFim = TimeSpan.FromHours(10),
                Disponivel = true
            };



            _mockUof.Setup(u => u.HorarioDisponivelRepository.GetAsync(It.IsAny<Expression<Func<HorarioDisponivel, bool>>>()))
            .ReturnsAsync(horario);


            //act
            var result = await _controller.Get(horarioDisponivelId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HorarioDisponivelDTO>(okResult.Value);
            Assert.Equal(horarioDisponivelId, returnValue.HorarioDisponivelId);



        }





        [Fact]
        public async Task GetHorarioDisponivelById_Return_NotFound()
        {
            // Arrange
            var horarioDisponivelId = 999;
            _mockUof.Setup(u => u.HorarioDisponivelRepository.GetAsync(It.IsAny<Expression<Func<HorarioDisponivel, bool>>>()))
                    .ReturnsAsync((HorarioDisponivel)null);



            // Act
            var result = await _controller.Get(horarioDisponivelId);



            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"horarioDisponivel com id= {horarioDisponivelId} não encontrado...", notFoundResult.Value);
        }




        [Fact]
        public async Task GetHorarioDisponivelById_Returns_BadRequest()
        {
            // Arrange
            var horarioDisponivelId = -1;

            // Act
            var result = await _controller.Get(horarioDisponivelId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }






    }
}
