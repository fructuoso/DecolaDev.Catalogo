using DecolaDev.Catalogo.Domain.Core.Entity;
using DecolaDev.Catalogo.WebAPI.Tests.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;
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
    }
}
