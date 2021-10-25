using Bogus;
using DecolaDev.Catalogo.Domain.Core.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecolaDev.Catalogo.WebAPI.Tests
{
    public class TestDataGenerator : IEnumerable<object[]>
    {
        const int SIZE = 10;

        public IEnumerator<object[]> GetEnumerator()
        {
            var livros = new Faker<Livro>()
                .RuleFor(o => o.Autor, f => f.Person.FullName)
                .RuleFor(o => o.Categoria, f => f.Random.Words(1))
                .RuleFor(o => o.Nome, f => f.Random.Words(3))
                .RuleFor(o => o.Preco, f => f.Random.Decimal(30, 150))
                .Generate(SIZE);

            foreach (var livro in livros)
            {
                yield return new object[] { livro };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
