using FluentValidation;
using HeroRegistry.Application.Commands.Herois.Criar;

namespace HeroRegistry.Application.Heroes.Commands.Criar;

public class CriarHeroiValidation : AbstractValidator<CriarHeroiCommand>
{
    public CriarHeroiValidation()
    {
        RuleFor(x => x.Heroi).ChildRules(dto =>
        {
            dto.RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do herói é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(120).WithMessage("O nome deve ter no máximo 120 caracteres.");

            dto.RuleFor(x => x.NomeHeroi)
                .NotEmpty().WithMessage("O nome de herói é obrigatório.")
                .MaximumLength(120).WithMessage("O nome de herói deve ter no máximo 120 caracteres.");

            dto.RuleFor(x => x.DataNascimento)
                .LessThan(DateTime.Today).WithMessage("A data de nascimento deve ser no passado.");

            dto.RuleFor(x => x.Altura)
                .GreaterThan(0).WithMessage("A altura deve ser maior que zero.");

            dto.RuleFor(x => x.Peso)
                .GreaterThan(0).WithMessage("O peso deve ser maior que zero.");
        });
    }
}
