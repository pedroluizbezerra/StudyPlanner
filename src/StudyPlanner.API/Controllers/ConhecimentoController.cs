using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudyPlanner.API.DTO;
using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyPlanner.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ConhecimentoController : MainController
    {

        private readonly ILogger<ConhecimentoController> _logger;
        private readonly IConhecimentoServices _conhecimentoServices;
        private readonly IMapper _mapper;

        public ConhecimentoController(ILogger<ConhecimentoController> logger,
            IConhecimentoServices conhecimentoServices, 
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _logger = logger;
            _conhecimentoServices = conhecimentoServices;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IList<ConhecimentoDTO>>> ObterTodos()
        {
            var lista = _mapper.Map<IList<ConhecimentoDTO>>(
                await _conhecimentoServices.ObterTodos());

            if (lista == null || !lista.Any())
                return NotFound();

            return Ok(lista);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ConhecimentoDTO>> ObterPorId(Guid Id)
        {
            var conhecimentoDTO = _mapper.Map<ConhecimentoDTO>(
                await _conhecimentoServices.ObterPorId(Id));

            if (conhecimentoDTO == null)
                return NotFound();

            return Ok(conhecimentoDTO);
        }


        [HttpPost]
        public async Task<ActionResult<ConhecimentoDTO>> Adicionar(ConhecimentoDTO conhecimentoDTO)
        {

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _conhecimentoServices.Adcionar(
                _mapper.Map<Conhecimento>(conhecimentoDTO));

            return CustomResponse(conhecimentoDTO);

        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ConhecimentoDTO>> Atualizar(Guid id, ConhecimentoDTO conhecimentoDTO){

            if  (id != conhecimentoDTO.Id)
            {
                NotificarErro("O id informado não é o mesmo passado na query");
                CustomResponse(conhecimentoDTO);
            }
                
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _conhecimentoServices.Atualizar(
                _mapper.Map<Conhecimento>(conhecimentoDTO));

            return CustomResponse(conhecimentoDTO);
        }    

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ConhecimentoDTO>> Remover(Guid id)
        {

            if (id == null)
            {
                NotificarErro("O id informador é null");
                CustomResponse(id);
            }

            await _conhecimentoServices.Remover(id);

            return CustomResponse();
        }
    }
}
