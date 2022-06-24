namespace Entities
{
    public class StorageEntity
    {
        public Guid StorageId { get; set; }
        public Guid ProductId { get; set; }
        public Guid WarehouseId { get; set; }
        public DateTime LastUpdate { get; set; }
        public int PartialQuantity { get; set; }
        public ProductEntity Product { get; set; }
        public WarehouseEntity Warehouse { get; set; }
        public ICollection<InputOutputEntity> InputOutputs { get; set; }
    }
}
