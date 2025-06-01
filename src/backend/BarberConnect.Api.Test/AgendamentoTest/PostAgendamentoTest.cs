

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.DTOS.Mappings;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.AgendamentoTest
{
    public class PostAgendamentoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AgendamentoController>> _mockLogger;
        private readonly AgendamentoController _controller;


        public PostAgendamentoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AgendamentoController>>();
            _controller = new AgendamentoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Post_Avaliacao_Return_CreatedAtRoute()
        {
            // Arrange
            var agendamentoDto = new AgendamentoDTO
            {
                AgendamentoId = 1,
                Status = 0,
                LembreteEnviado = true,
                ClienteId = 1,
                ServicoId = 1,
                HorarioId = 1,
                BarbeiroId = 1,
            };



            var agendamento = agendamentoDto.ToAgendamento(); // simula conversão
            var agendamentoCriado = agendamento; // assume que Create retorna o mesmo objeto


            _mockUof.Setup(repo => repo.AgendamentoRepository.Create(It.IsAny<Agendamento>()))
                  .Returns(agendamentoCriado);

            _mockUof.Setup(repo => repo.Commit())
                                       .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Post(agendamentoDto);



            // Assert
            var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
            var returnValue = Assert.IsType<AgendamentoDTO>(createdAtRoute.Value);


            Assert.Equal("ObterAgendamento", createdAtRoute.RouteName);
            Assert.Equal(agendamentoDto.AgendamentoId, returnValue.AgendamentoId);

        }



        [Fact]
        public async Task Post_Agendamento_Returns_BadRequest()
        {
            // Arrange
            var mockUof = new Mock<IUnitOfWork>();
            var mockLogger = new Mock<ILogger<AgendamentoController>>();
            var controller = new AgendamentoController(mockUof.Object, mockLogger.Object);


            // Act
            var result = await controller.Post(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequestResult.Value);

        }

    }
}