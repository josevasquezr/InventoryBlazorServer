using FluentValidation;

namespace Entities
{
    public class CategoryEntity
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }

    public class CategoryValidator : AbstractValidator<CategoryEntity>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryId).NotEmpty();
            RuleFor(category => category.CategoryName).NotEmpty().Length(4, 100).Matches("([A-Za-z]+)\\s?([A-Za-z]+)");
        }
    }
}
