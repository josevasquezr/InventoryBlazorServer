using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class WarehouseValidator : AbstractValidator<WarehouseEntity>
    {
        public WarehouseValidator()
        {
            RuleFor( warehouse => warehouse.WarehouseId).NotNull().NotEmpty();
            Include( new WarehouseNameIsSpecified());
        }
    }

    public class WarehouseNameIsSpecified : AbstractValidator<WarehouseEntity>
    {
        public WarehouseNameIsSpecified()
        {
            RuleFor(warehouse => warehouse.WarehouseName).NotEmpty().WithMessage("El nombre no debe ser vacío.")
                                                            .NotNull().WithMessage("El nombre no puede ser nulo.")
                                                            .Length(5, 100).WithMessage("El nombre debe tener entre 5 a 100 caracteres.");
        }
    }

    public class WarehouseNameWithoutStrangerCharacteres : AbstractValidator<WarehouseEntity>
    {
        public WarehouseNameWithoutStrangerCharacteres()
        {
            RuleFor(warehouse => warehouse.WarehouseName);
        }
    }
}
