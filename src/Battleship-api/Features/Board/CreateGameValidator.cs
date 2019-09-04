using FluentValidation;

namespace BattleShip.Api.Features.Games
{
    public class CreateGameValidator : AbstractValidator<CreateGameRequest>
    {
        public CreateGameValidator()
        {
            RuleFor(t => t.BoardSize)
                .LessThanOrEqualTo(25)
                .GreaterThanOrEqualTo(5)
                .WithMessage("Board Size must be between 5 and 25.");

            RuleFor(t => t.PlayerOne)
                .NotEmpty()
                .WithMessage("Player one Id is required");

            RuleFor( t => t.PlayerTwo)
                .NotEmpty()
                .WithMessage("Player Two Id is required");

            RuleFor(t => t.PlayerTwo)
                .NotEqual(s => s.PlayerOne)
                .WithMessage("Player One Id can't Equal Player Two");
        }
    }
}
