using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class ProductValidator : AbstractValidator<ProductEntity>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductId).NotNull().NotEmpty();
            Include(new ProductCategoryIdIsSpecified());
            Include(new ProductNameIsSpecified());
            Include(new ProductNameOnlyLettersAndSpace());
            Include(new ProductDescriptionIsSpecified());
            Include(new ProductDescriptionOnlyLettersAndSpace());
            Include(new TotalQuantityIsEspecified());
            Include(new TotalQuantityIsBiggerOrEqualThanZero());
        }
    }
    public class ProductCategoryIdIsSpecified : AbstractValidator<ProductEntity>
    {
        public ProductCategoryIdIsSpecified()
        {
            RuleFor(product => product.CategoryId).NotEmpty().WithMessage("Debe seleccionar una categoria.")
                                                    .NotNull().WithMessage("La categoria no debe ser nula.");
        }
    }

    public class ProductNameIsSpecified : AbstractValidator<ProductEntity>
    {
        public ProductNameIsSpecified()
        {
            RuleFor(product => product.ProductName).NotEmpty().WithMessage("El nombre no debe ser vacío.")
                                                    .NotNull().WithMessage("El nombre no debe ser nulo.")
                                                    .Length(4, 100).WithMessage("El nombre debe tener entre entre 4 y 100 caracteres.");
        }
    }

    public class ProductNameOnlyLettersAndSpace : AbstractValidator<ProductEntity>
    {
        public ProductNameOnlyLettersAndSpace()
        {
            RuleFor(product => product.ProductName).Matches("([A-Za-z]+)\\s?([A-Za-z]+)")
                                                    .WithMessage("El nombre solo debe tener letras y espacios.");
        }
    }

    public class ProductDescriptionIsSpecified : AbstractValidator<ProductEntity>
    {
        public ProductDescriptionIsSpecified()
        {
            RuleFor(product => product.ProductDescription).Length(600).WithMessage("La descripción no debe tener más de 600 caracteres.");
        }
    }

    public class ProductDescriptionOnlyLettersAndSpace : AbstractValidator<ProductEntity>
    {
        public ProductDescriptionOnlyLettersAndSpace()
        {
            RuleFor(product => product.ProductDescription).Matches("([A-Za-z]+)\\s?([A-Za-z]+)")
                                                            .WithMessage("La descripción solo debe tener letras y espacios.");
        }
    }

    public class TotalQuantityIsEspecified : AbstractValidator<ProductEntity>
    {
        public TotalQuantityIsEspecified()
        {
            RuleFor(product => product.TotalQuantity).NotEmpty().WithMessage("La cantidad no debe ser vacío.")
                                                        .NotNull().WithMessage("La cantidad no debe ser nulo.");
        }
    }

    public class TotalQuantityIsBiggerOrEqualThanZero : AbstractValidator<ProductEntity>
    {
        public TotalQuantityIsBiggerOrEqualThanZero()
        {
            RuleFor(product => product.TotalQuantity).Must(IsBiggerOrEqualThanZero)
                                                        .WithMessage("La cantidad total de producto debe ser mayor o igual a 0.");
        }

        private bool IsBiggerOrEqualThanZero(int totalQuantity)
        {
            return totalQuantity >= 0;
        }
    }

}
