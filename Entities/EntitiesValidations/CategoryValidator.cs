using FluentValidation;

namespace Entities.EntitiesValidations
{
    public class CategoryValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryId).NotEmpty();
            Include(new CategoryNameIsSpecified());
            Include(new CategoryNameOnlyLettersAndSpace());
        }
    }

    public class CategoryNameIsSpecified : AbstractValidator<CategoryEntity>
    {
        public CategoryNameIsSpecified()
        {
            RuleFor(category => category.CategoryName).NotEmpty().WithMessage("El nombre no debe ser vacío.")
                                                        .NotNull().WithMessage("El nombre no debe ser nulo.")
                                                        .Length(4, 100).WithMessage("El nombre debe tener entre entre 4 y 100 caracteres.");
        }
    }

    public class CategoryNameOnlyLettersAndSpace : AbstractValidator<CategoryEntity>
    {
        public CategoryNameOnlyLettersAndSpace()
        {
            RuleFor(category => category.CategoryName).Matches("([A-Za-z]+)\\s?([A-Za-z]+)")
                                                        .WithMessage("El nombre solo debe tener letras y espacios."); 
        }
    }
}
