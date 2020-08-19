using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Models;
using StudyPlanner.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyPlanner.Business.Services
{
    public class ConhecimentoServices : BaseServices, IConhecimentoServices
    {
        private readonly IConhecimentoRepository _conhecimentoRepository;
        public ConhecimentoServices(IConhecimentoRepository conhecimentoRepository)
        {
            _conhecimentoRepository = conhecimentoRepository;
        }

        public async Task Adcionar(Conhecimento conhecimento)
        {
            if (!ExecutarValidacao(new ConhecimentoValidation(), conhecimento))
            {                
                return;
            }
            if (_conhecimentoRepository.Buscar(c=> c.Nome == conhecimento.Nome).Result.Any()) //TODO Criar um método existe caso este esteja materializando o objeto
            {
                Notificar("Já existe um conhecimento com o nome informado"); //TODO Criar resources de mensagem
                return;
            }
            await _conhecimentoRepository.Adicionar(conhecimento);

        }

        public async Task Atualizar(Conhecimento conhecimento)
        {
            if (!ExecutarValidacao(new ConhecimentoValidation(), conhecimento))
            {
                //TODO Completar
                return;
            }
            else
            {
                return;
            }
        }

        public Task<IEnumerable<Conhecimento>> BuscarPorFiltro()
        {
            throw new NotImplementedException();
        }

        public Task<Conhecimento> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Conhecimento>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
