using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BarberConnect.Api.Controllers;
using BarberConnect.Api.DTOS;
using BarberConnect.Api.Models;
using BarberConnect.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BarberConnect.Api.Test.HistoricoCorteTest
{
    public class GetHistoricoCorteTest
    {
        private readonly Mock<IUnitOfWork> _mockUof;
        private readonly Mock<ILogger<HistoricoCorteController>> _mockLogger;
        private readonly HistoricoCorteController _controller;



        public GetHistoricoCorteTest()
        {
            _mockUof = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<HistoricoCorteController>>();
            _controller = new HistoricoCorteController(_mockUof.Object, _mockLogger.Object);

        }





        [Fact]
        public async Task GetHistoricoCorteById_OkResult()
        {
            // Arrange
            var historicoCorteId = 1;
            var historicoCorte = new HistoricoCorte
            {
                HistoricoCorteId = 1,
                Foto = "foto.png",
                Observacoes = "Legal",
                AgendamentoId = 1,
            };


            _mockUof.Setup(u => u.HistoricoCorteRepository.GetAsync(It.IsAny<Expression<Func<HistoricoCorte, bool>>>()))
                       .ReturnsAsync(historicoCorte);



            //act
            var result = await _controller.Get(historicoCorteId);


            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<HistoricoCorteDTO>(okResult.Value);
            Assert.Equal(historicoCorteId, returnValue.HistoricoCorteId);


        }




        [Fact]
        public async Task GetHistoricoCorteById_Return_NotFound()
        {
            // Arrange
            var historicoCorteId = 1;
            _mockUof.Setup(u => u.HistoricoCorteRepository.GetAsync(It.IsAny<Expression<Func<HistoricoCorte, bool>>>()))
                    .ReturnsAsync((HistoricoCorte)null);




            // Act
            var result = await _controller.Get(historicoCorteId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"historicoCorte com id= {historicoCorteId} não encontrado...", notFoundResult.Value);

        }





        [Fact]
        public async Task GetHistorioCorteById_Returns_BadRequest()
        {
            // Arrange
            var historicoCorteId = -1;

            // Act
            var result = await _controller.Get(historicoCorteId);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.Equal("ID inválido.", badRequest.Value);
        }





        [Fact]
        public async Task GetHistoricoCortes_Return_ListOfHistoricoCortesDTO()
        {
            // Arrange
            var historicoCortes = new List<HistoricoCorte>
            {
                new HistoricoCorte {
                       HistoricoCorteId = 1,
                       Foto = "foto2.png",
                       Observacoes = "Legal",
                       AgendamentoId = 1,
                },

                new HistoricoCorte {
                       HistoricoCorteId = 2,
                       Foto = "foto3.png",
                       Observacoes = "Legal, curti",
                       AgendamentoId = 2,
                }
            };



            _mockUof.Setup(repo => repo.HistoricoCorteRepository.GetAllAsync())
                    .ReturnsAsync(historicoCortes);


            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsAssignableFrom<IEnumerable<HistoricoCorteDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count());
        }






    }
}