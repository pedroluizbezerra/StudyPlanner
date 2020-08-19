using FluentValidation;
using FluentValidation.Results;
using StudyPlanner.Business.Models;

namespace StudyPlanner.Business.Services
{
    public abstract class BaseServices
    {

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string message)
        {
            //propagar erro para a apresentação
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
