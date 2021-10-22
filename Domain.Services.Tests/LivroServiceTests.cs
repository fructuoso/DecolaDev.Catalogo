using DecolaDev.Catalogo.Domain.Core.Entity;
using DecolaDev.Catalogo.Domain.Core.Interfaces.Repository;
using DecolaDev.Catalogo.Domain.Services;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Services.Tests
{
    public class LivroServiceTests
    {
        /*
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> DeleteAsync(TKey id);
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity obj);
        */

        [Fact(DisplayName = "DADO um Livro válido QUANDO chamado o GenericServiceCrud.AddAsync ENTÃO chamar o IRepositoryCrud.AddAsync")]
        public async Task AddAsync()
        {
            //Arrange
            var repositorio = new Mock<IRepositoryCrud<int, Livro>>();

            var livro = new Livro() { Nome = "DOMAIN DRIVEN DESIGN", Autor = "EVANS" };

            var livroService = new GenericServiceCrud<int, Livro>(repositorio.Object);

            //Act
            await livroService.AddAsync(livro);

            //Assert
            repositorio.Verify(o => o.AddAsync(livro), Times.Once());
        }
    }
}
