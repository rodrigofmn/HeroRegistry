using FluentValidation;
using HeroRegistry.Application.Commands.Herois.Remover;
using HeroRegistry.Application.Commands.Herois.Criar;

namespace HeroRegistry.Application.Heroes.Commands.Herois.Remover;

public class RemoverHeroiValidation : AbstractValidator<RemoverHeroiCommand>
{
    public RemoverHeroiValidation()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("O Id é obrigatório.");
    }
}
