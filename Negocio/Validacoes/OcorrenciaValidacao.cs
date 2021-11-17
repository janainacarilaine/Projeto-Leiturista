using Business.Modelos;
using FluentValidation;

namespace Business.Validacoes
{
    public class OcorrenciaValidacao : AbstractValidator<Ocorrencia>
    {
        public OcorrenciaValidacao()
        {
            RuleFor(o => o.Descricao)
                .NotEmpty().WithMessage("O campo Descrição deve ser preenchido.")
                .NotNull().WithMessage("O campo Descrição não pode ser nulo.")
                .Length(6, 50).WithMessage("O campo Descrição deve ter entre 6 e 50 caracteres.");

            RuleFor(o => o.PermiteLeitura)
               .NotNull().WithMessage("O campo Permite Leitura não pode ser nulo.");

            RuleFor(o => o.Valor)
               .NotNull().WithMessage("O campo Valor não pode ser nulo.")
               .GreaterThanOrEqualTo(0).WithMessage("O campo Valor deve ser maior ou igual a 0.");

        }
    }
}
