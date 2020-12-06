using FluentValidation;
using FluentValidation.AspNetCore;

namespace StudyPlanner.Business.Models.Validations
{
    public class ConhecimentoValidation : AbstractValidator<Conhecimento>
    {
        public ConhecimentoValidation()
        {
            //TODO Criar resources com mensagens
            var mensagemObrigatoriedade = "O campo {propertyName} precisa ser fornecido";
            var mensagemRangeConhecimento = "O valor para o campo {propertyName} deve ser entre {From} e {To}";
            var mensagemTamanhoMaximo = "O campo {propertyName} precisa ter no máximo {MaxLenght} caracteres";

            RuleFor(c => c.NivelConhecimentoAtual)
                .NotEmpty().WithMessage(mensagemObrigatoriedade)
                .InclusiveBetween(0, 5).WithMessage(mensagemRangeConhecimento);

            RuleFor(c => c.NivelConhecimentoDesejado)
                .NotEmpty().WithMessage(mensagemObrigatoriedade)
                .InclusiveBetween(0,5).WithMessage(mensagemRangeConhecimento);

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(mensagemObrigatoriedade)
                .MaximumLength(200).WithMessage(mensagemTamanhoMaximo);

            RuleFor(c => c.PlanoAcao)
                .NotEmpty().WithMessage(mensagemObrigatoriedade)
                .MaximumLength(1000).WithMessage(mensagemTamanhoMaximo);

            RuleFor(c => c.Prioridade)
                .NotEmpty().WithMessage(mensagemObrigatoriedade);

            //RuleFor(c => c.TipoConhecimento)
            //    .NotEmpty().WithMessage(mensagemObrigatoriedade);
        }
    }
}
