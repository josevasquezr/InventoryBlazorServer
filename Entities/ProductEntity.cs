namespace Entities
{
    public class ProductEntity
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int TotalQuantity { get; set; }
        public CategoryEntity Category { get; set; }
        public ICollection<StorageEntity> Storages { get; set; }

    }
}
