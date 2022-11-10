using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class removeSupplierPackagesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Suppliers_SupplierId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_SupplierId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Packages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SupplierId",
                table: "Packages",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Suppliers_SupplierId",
                table: "Packages",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
