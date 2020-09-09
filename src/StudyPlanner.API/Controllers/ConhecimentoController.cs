using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Models;

namespace StudyPlanner.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConhecimentoController : ControllerBase
    {
        
        private readonly ILogger<ConhecimentoController> _logger;
        private readonly IConhecimentoServices conhecimentoServices;
        public ConhecimentoController(ILogger<ConhecimentoController> logger,
            IConhecimentoServices _conhecimentoServices)
        {
            _logger = logger;
            conhecimentoServices = _conhecimentoServices;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Conhecimento>>> ObterTodos()
        {

            var lista = await conhecimentoServices.ObterTodos(); 

            if (lista == null || !lista.Any())
                return NotFound();

            return Ok(lista);
        }

        [HttpPost]
        public async Task<ActionResult<Conhecimento>> Adicionar(Conhecimento conhecimento) {
            
            await conhecimentoServices.Adcionar(conhecimento);

            return Ok();
            
        }
    }
}
