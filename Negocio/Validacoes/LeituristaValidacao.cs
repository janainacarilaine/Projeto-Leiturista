using Business.Modelos;
using FluentValidation;

namespace Business.Validacoes
{
    public class LeituristaValidacao : AbstractValidator<Leiturista>
    {
        public LeituristaValidacao()
        {
            RuleFor(l => l.Matricula)
                .NotEmpty().WithMessage("O campo Matrícula deve ser preenchido.")
                .NotNull().WithMessage("O campo Matrícula não pode ser nulo.");

            RuleFor(l => l.Nome)
                .NotEmpty().WithMessage("O campo Nome deve ser preenchido.")
                .NotNull().WithMessage("O campo Nome não pode ser nulo.")
                .Length(3,100).WithMessage("O campo Nome deve ter entre 3 e 100 caracteres.");

            RuleFor(l => l.Ativo)
                .NotNull().WithMessage("O campo Ativo não pode ser nulo.");                
        }
    }
}
