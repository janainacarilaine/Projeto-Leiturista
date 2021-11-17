using Business.Modelos;
using FluentValidation;

namespace Business.Validations
{
    public class UsuarioValidacao : AbstractValidator<Usuario>
    {
        public UsuarioValidacao()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo Nome deve ser preenchido.")
                .NotNull().WithMessage("O campo Nome não pode ser nulo.")
                .Length(3, 100);

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo Email deve ser preenchido.")
                .NotNull().WithMessage("O campo Email não pode ser nulo.")
                .Length(6, 100).WithMessage("O campo Email deve ter entre 6 e 100 caracteres.")
                .EmailAddress().WithMessage("O campo informado deve atender aos padrões de um email.");

            RuleFor(u => u.Funcao)
                .NotEmpty().WithMessage("O campo Função deve ser preenchido.")
                .NotNull().WithMessage("O campo Função não pode ser nulo.")
                .Length(3, 50).WithMessage("O campo Função deve ter entre 3 e 50 caracteres.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("O campo Senha deve ser preenchido.")
                .NotNull().WithMessage("O campo Senha não pode ser nulo.")
                .Length(6, 32).WithMessage("O campo Senha deve ter entre 6 e 32 caracteres.");               

        }
    }
}
