using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class WarehouseValidator : AbstractValidator<WarehouseEntity>
    {
        public WarehouseValidator()
        {
            RuleFor( warehouse => warehouse.WarehouseId).NotNull().NotEmpty();
            Include( new WarehouseNameIsSpecified());
            Include( new WarehouseNameWithoutStrangerCharacteres());
            Include( new WarehouseAddressIsSpecified());
            Include( new WarehouseAddressWithoutStrangerCharacteres());
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
            RuleFor(warehouse => warehouse.WarehouseName).Matches("([A-Za-z0-9]+)\\s?([A-Za-z0-9]+)")
                                                            .WithMessage("El nombre solo debe contener letras, espacios o números");
        }
    }

    public class WarehouseAddressIsSpecified : AbstractValidator<WarehouseEntity>
    {
        public WarehouseAddressIsSpecified()
        {
            RuleFor(warehouse => warehouse.WarehouseAddress).NotEmpty().WithMessage("La dirección no debe ser vacío.")
                                                            .NotNull().WithMessage("La dirección no puede ser nulo.")
                                                            .Length(10, 300).WithMessage("La dirección debe tener entre {MinLength} a {MaxLength} caracteres.");
        }
    }

    public class WarehouseAddressWithoutStrangerCharacteres : AbstractValidator<WarehouseEntity>
    {
        public WarehouseAddressWithoutStrangerCharacteres()
        {
            RuleFor(warehouse => warehouse.WarehouseAddress).Matches("([A-Za-z0-9]+)\\s?([A-Za-z0-9]+)")
                                                            .WithMessage("La dirección solo debe contener letras, espacios o números");
        }
    }
}
