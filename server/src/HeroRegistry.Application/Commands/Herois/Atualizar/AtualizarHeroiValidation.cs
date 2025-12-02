using FluentValidation;
using HeroRegistry.Application.Commands.Herois.Atualizar;
using HeroRegistry.Application.Commands.Herois.Criar;

namespace HeroRegistry.Application.Heroes.Commands.Criar;

public class AtualizarHeroiValidation : AbstractValidator<AtualizarHeroiCommand>
{
    public AtualizarHeroiValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O Id é obrigatório.");

        RuleFor(x => x.AtualizarHeroiInputDto).ChildRules(dto =>
        {
            dto.RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do herói é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres.")
                .MaximumLength(120).WithMessage("O nome deve ter no máximo 120 caracteres.");

            dto.RuleFor(x => x.NomeHeroi)
                .NotEmpty().WithMessage("O poder do herói é obrigatório.")
                .MaximumLength(120).WithMessage("O poder deve ter no máximo 120 caracteres.");

            dto.RuleFor(x => x.DataNascimento)
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data passada.");

            dto.RuleFor(x => x.Altura)
                .GreaterThan(0).WithMessage("A Altura deve ser maior que zero.");

            dto.RuleFor(x => x.Peso)
                .GreaterThan(0).WithMessage("O Peso deve ser maior que zero.");
            });
        
    }
}
