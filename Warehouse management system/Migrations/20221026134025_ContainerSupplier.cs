using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class ContainerSupplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContainerSupplier",
                table: "ContainerSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ContainerSupplier_SuppliersId",
                table: "ContainerSupplier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContainerSupplier",
                table: "ContainerSupplier",
                columns: new[] { "SuppliersId", "ContainersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerSupplier_ContainersId",
                table: "ContainerSupplier",
                column: "ContainersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContainerSupplier",
                table: "ContainerSupplier");

            migrationBuilder.DropIndex(
                name: "IX_ContainerSupplier_ContainersId",
                table: "ContainerSupplier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContainerSupplier",
                table: "ContainerSupplier",
                columns: new[] { "ContainersId", "SuppliersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerSupplier_SuppliersId",
                table: "ContainerSupplier",
                column: "SuppliersId");
        }
    }
}
