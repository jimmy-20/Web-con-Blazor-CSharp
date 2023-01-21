using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "TbWarehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbWarehouse", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "TbProduct",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProduct", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_TbProduct_TbCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "TbCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbStorage",
                columns: table => new
                {
                    StorageId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WareHouseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbStorage", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_TbStorage_TbProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TbProduct",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbStorage_TbWarehouse_WareHouseId",
                        column: x => x.WareHouseId,
                        principalTable: "TbWarehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StorageId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateTransaction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    isInput = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTransaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_TbTransaction_TbStorage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "TbStorage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProduct_CategoryId",
                table: "TbProduct",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TbStorage_ProductId",
                table: "TbStorage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_TbStorage_WareHouseId",
                table: "TbStorage",
                column: "WareHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTransaction_StorageId",
                table: "TbTransaction",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTransaction");

            migrationBuilder.DropTable(
                name: "TbStorage");

            migrationBuilder.DropTable(
                name: "TbProduct");

            migrationBuilder.DropTable(
                name: "TbWarehouse");

            migrationBuilder.DropTable(
                name: "TbCategory");
        }
    }
}
