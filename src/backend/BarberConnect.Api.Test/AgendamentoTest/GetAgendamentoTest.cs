

using System.Linq.Expressions;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.AgendamentoTest
{
    public class GetAgendamentoTest
    {

        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AgendamentoController>> _mockLogger;
        private readonly AgendamentoController _controller;


        public GetAgendamentoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AgendamentoController>>();
            _controller = new AgendamentoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task GetAgendamentoById_OkResult()
        {
            // Arrange
            var agendamentoId = 1;
            var agendamento = new Agendamento
            {
                AgendamentoId = 1,
                Status = 0,
                LembreteEnviado = true,
                ClienteId = 1,
                ServicoId = 1,
                HorarioId = 1,
                BarbeiroId = 1,
            };



            _mockUof.Setup(u => u.AgendamentoRepository.GetAsync(It.IsAny<Expression<Func<Agendamento, bool>>>()))
                    .ReturnsAsync(agendamento);

            //act
            var result = await _controller.Get(agendamentoId);



            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AgendamentoDTO>(okResult.Value);
            Assert.Equal(agendamentoId, returnValue.AgendamentoId);

        }






        [Fact]
        public async Task GetAgendamentoById_Return_NotFound()
        {
            // Arrange
            var agendamentoId = 999;
            _mockUof.Setup(u => u.AgendamentoRepository.GetAsync(It.IsAny<Expression<Func<Agendamento, bool>>>()))
                    .ReturnsAsync((Agendamento)null);


            // Act
            var result = await _controller.Get(agendamentoId);


            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"agendamento com id= {agendamentoId} não encontrado...", notFoundResult.Value);
        }



        [Fact]
        public async Task GetAgendamentoById_Returns_BadRequest()
        {
            // Arrange
            var agendamentoId = -1;

            // Act
            var result = await _controller.Get(agendamentoId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }




        [Fact]
        public async Task GetAgendamentos_Return_ListOfAgendamentosDTO()
        {
            // Arrange
            var agendamentos = new List<Agendamento>
            {
                new Agendamento {
                       AgendamentoId = 1,
                       Status = 0,
                       LembreteEnviado = true,
                       ClienteId = 1,
                       ServicoId = 1,
                       HorarioId = 1,
                       BarbeiroId = 1,
                },
                new Agendamento {
                       AgendamentoId = 2,
                       Status = 0,
                       LembreteEnviado = true,
                       ClienteId = 2,
                       ServicoId = 2,
                       HorarioId = 2,
                       BarbeiroId = 2,
                }
            };




            _mockUof.Setup(repo => repo.AgendamentoRepository.GetAllAsync())
                    .ReturnsAsync(agendamentos);


            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<AgendamentoDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
            
        }

    }
}