

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
    public class DeleteAgendamentoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AgendamentoController>> _mockLogger;
        private readonly AgendamentoController _controller;


        public DeleteAgendamentoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AgendamentoController>>();
            _controller = new AgendamentoController(_mockUof.Object, _mockLogger.Object);
        }



        [Fact]
        public async Task Delete_Agendamento_Return_NotFound()
        {
            // Arrange
            int agendamentoId = 9999;
            _mockUof.Setup(repo => repo.AgendamentoRepository.GetAsync(It.IsAny<Expression<Func<Agendamento, bool>>>()))
                    .ReturnsAsync((Agendamento)null);

            // Act
            var result = await _controller.Delete(agendamentoId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"agendamento com id={agendamentoId} não encontrado...", notFoundResult.Value.ToString());
        }




        [Fact]
        public async Task Delete_Agendamento_Return_OkObjectResult()
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


            _mockUof.Setup(repo => repo.AgendamentoRepository.GetAsync(It.IsAny<Expression<Func<Agendamento, bool>>>()))
                         .ReturnsAsync(agendamento);


            _mockUof.Setup(repo => repo.AgendamentoRepository.Delete(agendamento))
                   .Returns(agendamento);

            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Delete(agendamentoId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AgendamentoDTO>(okResult.Value);
            Assert.Equal(agendamentoId, returnValue.AgendamentoId);

        }



    }
}