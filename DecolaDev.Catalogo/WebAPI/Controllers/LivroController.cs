using AutoMapper;
using DecolaDev.Catalogo.Domain.Core.Entity;
using DecolaDev.Catalogo.Domain.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecolaDev.Catalogo.WebAPI.Controllers
{
    public class LivroController : GenericControllerCrud<int, Livro, Livro>
    {
        public LivroController(IServiceCrud<int, Livro> service, IMapper mapper) : base(service, mapper) { }
    }
}
