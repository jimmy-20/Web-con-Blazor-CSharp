using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TbCategory",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { "AHR", "Aseo Hogar" },
                    { "ASP", "Aseo Personal" },
                    { "HGR", "Hogar" },
                    { "PRF", "Perfumeria" },
                    { "SLD", "Salud" },
                    { "VDJ", "Videojuegos" }
                });

            migrationBuilder.InsertData(
                table: "TbWarehouse",
                columns: new[] { "WarehouseId", "Adress", "Name" },
                values: new object[,]
                {
                    { "N-Bod", "7th Floor", "Bodega del Norte" },
                    { "S-Bod", "Room 1879", "Bodega del Sur" },
                    { "E-Bod", "Suite 63", "Bodega del Este" },
                    { "LP-Bod", "14th Floor", "Lote Praderas de Sandino" },
                    { "Dinsa-C", "PO Box 98900", "Planta central de Dinsa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "AHR");

            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "ASP");

            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "HGR");

            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "PRF");

            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "SLD");

            migrationBuilder.DeleteData(
                table: "TbCategory",
                keyColumn: "CategoryId",
                keyValue: "VDJ");

            migrationBuilder.DeleteData(
                table: "TbWarehouse",
                keyColumn: "WarehouseId",
                keyValue: "Dinsa-C");

            migrationBuilder.DeleteData(
                table: "TbWarehouse",
                keyColumn: "WarehouseId",
                keyValue: "E-Bod");

            migrationBuilder.DeleteData(
                table: "TbWarehouse",
                keyColumn: "WarehouseId",
                keyValue: "LP-Bod");

            migrationBuilder.DeleteData(
                table: "TbWarehouse",
                keyColumn: "WarehouseId",
                keyValue: "N-Bod");

            migrationBuilder.DeleteData(
                table: "TbWarehouse",
                keyColumn: "WarehouseId",
                keyValue: "S-Bod");
        }
    }
}
