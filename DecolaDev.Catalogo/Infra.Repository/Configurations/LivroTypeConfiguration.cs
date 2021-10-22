using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecolaDev.Catalogo.Domain.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DecolaDev.Catalogo.Infra.Repository.Configurations
{
    class LivroTypeConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(o => o.Autor).HasMaxLength(50);
            builder.Property(o => o.Categoria).HasMaxLength(50);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Property(o => o.Nome).HasMaxLength(50);
            builder.Property(o => o.Preco).IsRequired();
        }
    }
}
