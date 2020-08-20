using FluentValidation;
using FluentValidation.Results;
using StudyPlanner.Business.Interfaces;
using StudyPlanner.Business.Models;
using StudyPlanner.Business.Notificacoes;

namespace StudyPlanner.Business.Services
{
    public abstract class BaseServices
    {
        private readonly INotificador _notificador;

        public BaseServices(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid)
            {
                return true;
            }
            else
            {
                Notificar(validator);
                return false;
            }
        }
    }
}
