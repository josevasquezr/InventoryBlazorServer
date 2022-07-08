using FluentValidation;

namespace Entities
{
    public class CategoryEntity
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
