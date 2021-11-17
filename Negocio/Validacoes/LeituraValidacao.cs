using Business.Modelos;
using FluentValidation;

namespace Business.Validacoes
{
    public class LeituraValidacao : AbstractValidator<Leitura>
    {
        public LeituraValidacao()
        {
            RuleFor(l => l.CodCliente)
                .NotEmpty().WithMessage("O campo Código do Cliente deve ser informado.")
                .NotNull().WithMessage("O campo Código do Cliente não pode ser nulo.");

            RuleFor(l => l.Latitude)
                .NotEmpty().WithMessage("O campo Latitude deve ser informado.")
                .NotNull().WithMessage("O campo Latitude não pode ser nulo.");

            RuleFor(l => l.Longitude)
                .NotEmpty().WithMessage("O campo Longitude deve ser informado.")
                .NotNull().WithMessage("O campo Longitude não pode ser nulo.");

            RuleFor(l => l.LeituraAnterior)
                .NotEmpty().WithMessage("O campo Leitura Anterior deve estar preenchido.")
                .NotNull().WithMessage("O campo Leitura Anterior não pode ser nulo.")
                .GreaterThanOrEqualTo(0).WithMessage("O campo Leitura Anterior deve ser maior ou igual a 0.");

             RuleFor(l => l.LeituristaId)
                .NotEmpty().WithMessage("O campo Id do Leiturista deve ser informado.")
                .NotNull().WithMessage("O campo Id do Leiturista não pode ser nulo.");

            RuleFor(l => l.OcorrenciaId)
                .NotEmpty().WithMessage("O campo Id da Ocorrência deve ser informado.")
                .NotNull().WithMessage("O campo Id da Ocorrência não pode ser nulo.");
        }
    }
}
