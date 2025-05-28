

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace BarberConnect.Api.Test.Testes
{
    public class PostAgendamentoUnitTest : IClassFixture<AgendamentoUnitTestController>
    {
        private readonly AgendamentoController _controller;

        public PostAgendamentoUnitTest(AgendamentoUnitTestController controller)
        {
            _controller = new AgendamentoController(controller.repository);

        }

        //metodos de test para post
        [Fact]
        public async Task PostProduto_Return_CreatedStatusCode()
        {
            //arrange
            var novoAgendamentoDto = new AgendamentoDTO
            {
                Status = 0,
                LembreteEnviado = true,
                ClienteId = 1,
                ServicoId = 1,
                HorarioId = 1,
                BarbeiroId = 1

            };

            //act
            var data = await _controller.Post(novoAgendamentoDto);

           //Assert
            var createdResult = Assert.IsType<CreatedAtRouteResult>(data.Result);
            Assert.Equal(201, createdResult.StatusCode);

        }


    }
}