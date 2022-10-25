using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class LocationSchedulingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseLocationId",
                table: "SchedulingProcesses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WarehouseLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimintion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseLocation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcesses_WarehouseLocationId",
                table: "SchedulingProcesses",
                column: "WarehouseLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchedulingProcesses_WarehouseLocation_WarehouseLocationId",
                table: "SchedulingProcesses",
                column: "WarehouseLocationId",
                principalTable: "WarehouseLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchedulingProcesses_WarehouseLocation_WarehouseLocationId",
                table: "SchedulingProcesses");

            migrationBuilder.DropTable(
                name: "WarehouseLocation");

            migrationBuilder.DropIndex(
                name: "IX_SchedulingProcesses_WarehouseLocationId",
                table: "SchedulingProcesses");

            migrationBuilder.DropColumn(
                name: "WarehouseLocationId",
                table: "SchedulingProcesses");
        }
    }
}
