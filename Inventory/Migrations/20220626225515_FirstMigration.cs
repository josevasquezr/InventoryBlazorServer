using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WarehouseAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartialQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storages_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputsOuputs",
                columns: table => new
                {
                    InOutId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsInput = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputsOuputs", x => x.InOutId);
                    table.ForeignKey(
                        name: "FK_InputsOuputs_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("0eeb418b-50e1-424d-a81d-59f8d74d99e0"), "Categoria 1" },
                    { new Guid("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"), "Categoria 4" },
                    { new Guid("98559254-e77e-4e45-9395-9793bea1bbae"), "Categoria 2" },
                    { new Guid("efc6dfcf-8cb4-46b7-a051-b36e822be152"), "Categoria 3" }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "WarehouseId", "WarehouseAddress", "WarehouseName" },
                values: new object[,]
                {
                    { new Guid("1ae7f481-1589-4d1c-883e-b1e7252bebaa"), "Direccion 4", "Bodega 4" },
                    { new Guid("82549001-6a77-4885-ae6e-d701c5277b48"), "Direccion 3", "Bodega 3" },
                    { new Guid("c4d478b2-9227-43e9-b106-94e25fb4a75b"), "Direccion 1", "Bodega 1" },
                    { new Guid("e236cc76-4c0b-460a-9333-c1aa2bb5d4c9"), "Direccion 2", "Bodega 2" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "ProductDescription", "ProductName", "TotalQuantity" },
                values: new object[,]
                {
                    { new Guid("362d3236-eed2-4602-8256-036ee828c3b2"), new Guid("44a9d8fb-9371-42dd-a2d0-07e8cf72b934"), "Producto 4", "Producto 4", 40 },
                    { new Guid("6f453819-bc23-4085-a050-c419130bc878"), new Guid("0eeb418b-50e1-424d-a81d-59f8d74d99e0"), "Producto 1", "Producto 1", 10 },
                    { new Guid("dd139eee-bf3b-4d81-a8bb-21e989dee8cb"), new Guid("98559254-e77e-4e45-9395-9793bea1bbae"), "Producto 2", "Producto 2", 20 },
                    { new Guid("e3a0d31c-886f-4c72-877e-c08f2a484ffe"), new Guid("efc6dfcf-8cb4-46b7-a051-b36e822be152"), "Producto 3", "Producto 3", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InputsOuputs_StorageId",
                table: "InputsOuputs",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ProductId",
                table: "Storages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_WarehouseId",
                table: "Storages",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputsOuputs");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
