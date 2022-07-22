using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class InputOutputValidator : AbstractValidator<InputOutputEntity>
    {
        public InputOutputValidator()
        {
            RuleFor(inOut => inOut.InOutId).NotNull().NotEmpty();
            RuleFor(inOut => inOut.StorageId).NotNull().NotEmpty();
            Include(new InOutDateIsSpecified());
            Include(new InOutQuatityIsSpecified());
            Include(new InOutQuantityIsBiggerOrEqualThanZero());
            Include(new InOutIsInputIsSpecified());
        }

        public class InOutDateIsSpecified : AbstractValidator<InputOutputEntity>
        {
            public InOutDateIsSpecified()
            {
                RuleFor(inOut => inOut.InOutDate).NotNull().WithMessage("La fecha de entrada y salida no debe ser nula.")
                                                    .NotEmpty().WithMessage("La fecha de entrada y salida no debe ser vacía.");
            }
        }

        public class InOutQuatityIsSpecified : AbstractValidator<InputOutputEntity>
        {
            public InOutQuatityIsSpecified()
            {
                RuleFor(inOut => inOut.Quantity).NotNull().WithMessage("La cantidad no debe ser nula.")
                                                .NotEmpty().WithMessage("La cantidad no debe ser vacía.");
            }
        }

        public class InOutQuantityIsBiggerOrEqualThanZero : AbstractValidator<InputOutputEntity>
        {
            public InOutQuantityIsBiggerOrEqualThanZero()
            {
                RuleFor(inOut => inOut.Quantity).Must(IsBiggerOrEqualThanZero)
                                                .WithMessage("La cantidad debe ser mayor o igual a cero.");
            }

            private bool IsBiggerOrEqualThanZero(int quantity)
            {
                return quantity >= 0;
            }
        }

        public class InOutIsInputIsSpecified : AbstractValidator<InputOutputEntity>
        {
            public InOutIsInputIsSpecified()
            {
                RuleFor(inOut => inOut.IsInput).NotNull().WithMessage("La entrada o salida no debe ser nula.")
                                                .NotEmpty().WithMessage("Especifique si es entrada o salida.");
            }
        }
    }
}
