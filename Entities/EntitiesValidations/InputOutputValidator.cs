using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class InputOutputValidator : AbstractValidator<InputOutputEntity>
    {
        public InputOutputValidator()
        {
            RuleFor(inOut => inOut.InOutId).NotNull().NotEmpty();
            RuleFor(inOut => inOut.StorageId).NotNull().WithMessage("Debe seleccionar un almacenamiento.")
                                                .NotEmpty().WithMessage("Debe seleccionar un almacenamiento.");
            Include(new InOutDateIsSpecified());
            Include(new InOutQuatityIsSpecified());
            Include(new InOutQuantityIsBiggerThanZero());
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

        public class InOutQuantityIsBiggerThanZero : AbstractValidator<InputOutputEntity>
        {
            public InOutQuantityIsBiggerThanZero()
            {
                RuleFor(inOut => inOut.Quantity).Must(IsBiggerThanZero)
                                                .WithMessage("La cantidad debe ser mayor a cero.");
            }

            private bool IsBiggerThanZero(int quantity)
            {
                return quantity > 0;
            }
        }
    }
}
