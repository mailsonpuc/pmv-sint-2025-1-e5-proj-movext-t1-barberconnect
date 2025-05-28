

using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace BarberConnect.Api.Test.Testes
{
    public class GetAgendamentoUnitTests : IClassFixture<AgendamentoUnitTestController>
    {
        //controller original
        private readonly AgendamentoController _controller;

        public GetAgendamentoUnitTests(AgendamentoUnitTestController controller)
        {
            _controller = new AgendamentoController(controller.repository);

        }



        [Fact]
        public async Task getAgendamentoById_OkResult()
        {
            //Arrange
            var agendamentoid = 1;

            //Act
            var data = await _controller.Get(agendamentoid);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(data.Result);
            Assert.Equal(200, okResult.StatusCode);

        }



        [Fact]
        public async Task getAgendamentoById_Return_NotFound()
        {
            //Arrange
            var agendamentoid = 999;

            //Act
            var data = await _controller.Get(agendamentoid);

            //Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(data.Result);
            Assert.Equal(404, notFoundResult.StatusCode);

        }



        [Fact]
        public async Task getAgendamentoById_Return_BadRequest()
        {
            //Arrange
            var agendamentoid = -1;

            //Act
            var data = await _controller.Get(agendamentoid);

            //Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(data.Result);
            Assert.Equal(400, badRequestResult.StatusCode);

        }




        [Fact]
        public async Task getAgendamentoById_Return_ListOfAgendamento()
        {
            //Arrange


            //Act
            var data = await _controller.Get();

            //Assert
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(data.Result);
            var returnValue = Assert.IsType<List<AgendamentoDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }






    }
}