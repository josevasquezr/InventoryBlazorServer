using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class StorageValidator : AbstractValidator<StorageEntity>
    {
        public StorageValidator()
        {
            RuleFor(storage => storage.StorageId).NotNull().NotEmpty();
            RuleFor(storage => storage.ProductId).NotNull().NotEmpty();
            RuleFor(storage => storage.WarehouseId).NotNull().NotEmpty();
            Include(new LastUpdateIsSpecified());
            Include(new PartialQuantityIsSpecified());
            Include(new PartialQuantityIsBiggerOrEqualThanZero());
        }
    }

    public class LastUpdateIsSpecified : AbstractValidator<StorageEntity>
    {
        public LastUpdateIsSpecified()
        {
            RuleFor(storage => storage.LastUpdate).NotNull().WithMessage("La fecha de actualización no debe ser nula.")
                                                    .NotEmpty().WithMessage("La fecha de actualización no debe ser vacia.");
        }
    }

    public class PartialQuantityIsSpecified : AbstractValidator<StorageEntity>
    {
        public PartialQuantityIsSpecified()
        {
            RuleFor(storage => storage.PartialQuantity).NotNull().WithMessage("La cantidad parcial no debe ser nula.")
                                                    .NotEmpty().WithMessage("La cantidad parcial no debe ser vacia.");
        }
    }

    public class PartialQuantityIsBiggerOrEqualThanZero : AbstractValidator<StorageEntity>
    {
        public PartialQuantityIsBiggerOrEqualThanZero()
        {
            RuleFor(storage => storage.PartialQuantity).Must(IsBiggerOrEqualThanZero)
                                                        .WithMessage("La cantidad parcial de producto debe ser mayor o igual a 0.");
        }

        private bool IsBiggerOrEqualThanZero(int partialQuantity)
        {
            return partialQuantity >= 0;
        }
    }
}
