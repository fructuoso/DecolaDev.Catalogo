using AutoMapper;
using DecolaDev.Catalogo.Domain.Core.Entity;
using DecolaDev.Catalogo.Domain.Core.Interfaces.Service;
using DecolaDev.Catalogo.WebAPI.Controllers;
using DecolaDev.Catalogo.WebAPI.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace DecolaDev.Catalogo.WebAPI.Tests
{
    public class LivroControllerTest : IClassFixture<WebApplicationFixture>
    {
        private readonly WebApplicationFixture _webAppFixture;

        public LivroControllerTest(WebApplicationFixture webAppFixture)
        {
            _webAppFixture = webAppFixture;
        }

        [Fact(DisplayName = "DADO um Livro válido QUANDO solicitamos sua inclusão ENTÃO retornar StatusCode = Created")]
        public async Task PostWhenIsValid()
        {
            //Arrange
            HttpClient httpClient = _webAppFixture.CreateHttpClient();
            
            Livro model = new Livro();

            //Act
            var response = await httpClient.PostAsJsonAsync("/api/Livro", model);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact(DisplayName = "DADO um livro válido QUANDO chamado o Update E exisitir na base ENTÃO retornar StatusCode.NoContent (204)")]
        public async Task UpdateAsync()
        {
            //Arrange
            var livro = new Livro();

            var livroService = new Mock<IServiceCrud<int, Livro>>();
            livroService.Setup(o => o.UpdateAsync(It.IsAny<Livro>())).Returns(Task.FromResult(livro));

            var mapper = new Mock<IMapper>();

            var controller = new LivroController(livroService.Object, mapper.Object);

            //Act
            var response = await controller.Put(livro);

            //Assert
            Assert.IsAssignableFrom<NoContentResult>(response);
        }
        
        [Fact(DisplayName = "DADO um livro válido QUANDO chamado o Update E não existir na base ENTÃO retornar StatusCode.NotFound (404)")]
        public async Task UpdateAsync_NotFound()
        {
            //Arrange
            var livroService = new Mock<IServiceCrud<int, Livro>>();
            livroService.Setup(o => o.UpdateAsync(It.IsAny<Livro>())).Returns(Task.FromResult<Livro>(null));

            var mapper = new Mock<IMapper>();
            var livro = new Livro();

            var controller = new LivroController(livroService.Object, mapper.Object);

            //Act
            var response = await controller.Put(livro);

            //Assert
            Assert.IsAssignableFrom<NotFoundResult>(response);
        }

    }
}
