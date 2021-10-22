using DecolaDev.Catalogo.WebAPI.Tests.Setup;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace DecolaDev.Catalogo.WebAPI.Tests.Fixtures
{
    public class WebApplicationFixture
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public WebApplicationFixture()
        {
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");

            var builder = new CustomWebApplicationBuilder();

            _factory = builder.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
                });
            });
        }
        public HttpClient CreateHttpClient()
        {
            return _factory.CreateClient();
        }
    }
}
