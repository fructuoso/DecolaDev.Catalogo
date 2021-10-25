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
            _webAppFixture = new WebApplicationFixture();
        }

        [Theory(DisplayName = "DADO um Livro válido QUANDO solicitamos sua inclusão ENTÃO retornar StatusCode = Created")]
        [ClassData(typeof(TestDataGenerator))]
        public async Task Post(Livro livro)
        {
            //Arrange
            HttpClient httpClient = _webAppFixture.CreateHttpClient();
            
            //Act
            var response = await httpClient.PostAsJsonAsync("/api/Livro", livro);

            //Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
