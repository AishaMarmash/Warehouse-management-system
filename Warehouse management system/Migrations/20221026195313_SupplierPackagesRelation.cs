using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class SupplierPackagesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
