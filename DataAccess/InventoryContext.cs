using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class InventoryContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<InputOutputEntity> InOuts { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<CategoryEntity> categories = getCategories();
            List<ProductEntity> products = getProducts();
            List<WarehouseEntity> warehouses = getWarehouses();

            modelBuilder.Entity<CategoryEntity>(category => {
                category.ToTable("Categories");
                category.HasKey(p => p.CategoryId);
                category.Property(p => p.CategoryName).IsRequired().HasMaxLength(100);
                category.HasData(categories);
            });

            modelBuilder.Entity<ProductEntity>(product => {
                product.ToTable("Products");
                product.HasKey(p => p.ProductId);
                product.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
                product.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
                product.Property(p => p.ProductDescription).IsRequired(false).HasMaxLength(600);
                product.Property(p => p.TotalQuantity).IsRequired().HasMaxLength(10);
                product.HasData(products);
            });

            modelBuilder.Entity<WarehouseEntity>(warehouse => {
                warehouse.ToTable("Warehouses");
                warehouse.HasKey(p => p.WarehouseId);
                warehouse.Property(p => p.WarehouseName).IsRequired().HasMaxLength(100);
                warehouse.Property(p => p.WarehouseAddress).IsRequired().HasMaxLength(300);
                warehouse.HasData(warehouses);
            });

            modelBuilder.Entity<StorageEntity>(storage => {
                storage.ToTable("Storages");
                storage.HasKey(p => p.StorageId);
                storage.HasOne(p => p.Product).WithMany(p => p.Storages).HasForeignKey(p => p.ProductId);
                storage.HasOne(p => p.Warehouse).WithMany(p => p.Storages).HasForeignKey(p => p.WarehouseId);
                storage.Property(p => p.LastUpdate).IsRequired();
                storage.Property(p => p.PartialQuantity).IsRequired();
            });

            modelBuilder.Entity<InputOutputEntity>(inOut => {
                inOut.ToTable("InputsOuputs");
                inOut.HasKey(p => p.InOutId);
                inOut.HasOne(p => p.Storage).WithMany(p => p.InputOutputs).HasForeignKey(p => p.StorageId);
                inOut.Property(p => p.InOutDate).IsRequired();
                inOut.Property(p => p.Quantity).IsRequired();
                inOut.Property(p => p.IsInput).IsRequired();
            });
        }
        #region DataSemilla
        private List<WarehouseEntity> getWarehouses()
        {
            return new List<WarehouseEntity>(){ 
                new WarehouseEntity(){ 
                    WarehouseId = Guid.Parse("c4d478b2-9227-43e9-b106-94e25fb4a75b"),
                    WarehouseName = "Bodega 1",
                    WarehouseAddress = "Direccion 1"
                },
                new WarehouseEntity(){
                    WarehouseId = Guid.Parse("e236cc76-4c0b-460a-9333-c1aa2bb5d4c9"),
                    WarehouseName = "Bodega 2",
                    WarehouseAddress = "Direccion 2"
                },
                new WarehouseEntity(){
                    WarehouseId = Guid.Parse("82549001-6a77-4885-ae6e-d701c5277b48"),
                    WarehouseName = "Bodega 3",
                    WarehouseAddress = "Direccion 3"
                },
                new WarehouseEntity(){
                    WarehouseId = Guid.Parse("1ae7f481-1589-4d1c-883e-b1e7252bebaa"),
                    WarehouseName = "Bodega 4",
                    WarehouseAddress = "Direccion 4"
                }
            };
        }

        private List<ProductEntity> getProducts()
        {
            return new List<ProductEntity>(){
                new ProductEntity(){
                    ProductId = Guid.Parse("6f453819-bc23-4085-a050-c419130bc878"),
                    CategoryId = Guid.Parse("0eeb418b-50e1-424d-a81d-59f8d74d99e0"),
                    ProductName = "Producto 1",
                    ProductDescription = "Producto 1",
                    TotalQuantity = 10,
                },
                new ProductEntity(){
                    ProductId = Guid.Parse("dd139eee-bf3b-4d81-a8bb-21e989dee8cb"),
                    CategoryId = Guid.Parse("98559254-e77e-4e45-9395-9793bea1bbae"),
                    ProductName = "Producto 2",
                    ProductDescription = "Producto 2",
                    TotalQuantity = 20,
                },
                new ProductEntity(){
                    ProductId = Guid.Parse("e3a0d31c-886f-4c72-877e-c08f2a484ffe"),
                    CategoryId = Guid.Parse("efc6dfcf-8cb4-46b7-a051-b36e822be152"),
                    ProductName = "Producto 3",
                    ProductDescription = "Producto 3",
                    TotalQuantity = 30,
                },
                new ProductEntity(){
                    ProductId = Guid.Parse("362d3236-eed2-4602-8256-036ee828c3b2"),
                    CategoryId = Guid.Parse("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"),
                    ProductName = "Producto 4",
                    ProductDescription = "Producto 4",
                    TotalQuantity = 40,
                }
            };
        }

        private List<CategoryEntity> getCategories()
        {
            return new List<CategoryEntity>(){
                new CategoryEntity(){ 
                    CategoryId = Guid.Parse("0eeb418b-50e1-424d-a81d-59f8d74d99e0"),
                    CategoryName = "Categoria 1"
                },
                new CategoryEntity(){
                    CategoryId = Guid.Parse("98559254-e77e-4e45-9395-9793bea1bbae"),
                    CategoryName = "Categoria 2"
                },
                new CategoryEntity(){
                    CategoryId = Guid.Parse("efc6dfcf-8cb4-46b7-a051-b36e822be152"),
                    CategoryName = "Categoria 3"
                },
                new CategoryEntity(){
                    CategoryId = Guid.Parse("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"),
                    CategoryName = "Categoria 4"
                },
            };
        }
        #endregion
    }
}
