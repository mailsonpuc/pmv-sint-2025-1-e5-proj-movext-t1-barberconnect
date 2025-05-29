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
        public async Task Get_ReturnsOkResult_WithListOfHorarioDisponivelDTO()
        {
            // Arrange
            var horarios = new List<HorarioDisponivel>
            {
                new HorarioDisponivel { HorarioDisponivelId = 1, Date = DateTime.Today, HoraInicio = TimeSpan.FromHours(9), HoraFim = TimeSpan.FromHours(10), Disponivel = true }
            };

            _mockUof.Setup(u => u.HorarioDisponivelRepository.GetAllAsync())
                .ReturnsAsync(horarios);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<HorarioDisponivelDTO>>(okResult.Value);
            Assert.Single(returnValue); // Verifica se tem 1 item
        }




        [Fact]
        public async Task Get_ReturnsNotFound_WhenNoHorarioDisponivel()
        {
            // Arrange
            List<HorarioDisponivel>? nullList = null;

            _mockUof.Setup(u => u.HorarioDisponivelRepository.GetAllAsync())
                .ReturnsAsync(nullList);

            // Act
            var result = await _controller.Get();

            // Assert
            var notFound = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Não existem horariosDisponivels ...", notFound.Value);
        }


        
    }
}
