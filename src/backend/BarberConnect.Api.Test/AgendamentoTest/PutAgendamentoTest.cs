
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
    public class PutAgendamentoTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<AgendamentoController>> _mockLogger;
        private readonly AgendamentoController _controller;


        public PutAgendamentoTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<AgendamentoController>>();
            _controller = new AgendamentoController(_mockUof.Object, _mockLogger.Object);
        }




        [Fact]
        public async Task Put_Agendamento_Return_CreatedAtRoute()
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


            var routeId = 2; // ID diferente do DTO


            // Act
            var result = await _controller.Put(routeId, agendamentoDto);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("Dados inválidos", badRequest.Value);
        }




        //Teste: Put com ID correto → retorna Ok
        [Fact]
        public async Task PutAgendamento_Return_OkResult()
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




            var agendamento = agendamentoDto.ToAgendamento();
            var agendamentoAtualizado = agendamento;


            _mockUof.Setup(repo => repo.AgendamentoRepository.Update(It.IsAny<Agendamento>()))
                             .Returns(agendamentoAtualizado);


            _mockUof.Setup(repo => repo.Commit())
                    .Returns(Task.CompletedTask);



            // Act
            var result = await _controller.Put(agendamentoDto.AgendamentoId, agendamentoDto);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AgendamentoDTO>(okResult.Value);
            Assert.Equal(agendamentoDto.AgendamentoId, returnValue.AgendamentoId);
        }
    }
}