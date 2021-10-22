using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecolaDev.Catalogo.Domain.Core.Entity
{
    public class Livro : BaseEntity<int>
    {
        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public string Categoria { get; set; }

        public string Autor { get; set; }
    }
}
