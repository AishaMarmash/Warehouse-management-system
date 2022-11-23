using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class SupplierContainerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_SchedulingProcess_ScheduleProcessId",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchedulingProcess",
                table: "SchedulingProcess");

            migrationBuilder.RenameTable(
                name: "SchedulingProcess",
                newName: "SchedulingProcesses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchedulingProcesses",
                table: "SchedulingProcesses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContainerSupplier",
                columns: table => new
                {
                    ContainersId = table.Column<int>(type: "int", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerSupplier", x => new { x.ContainersId, x.SuppliersId });
                    table.ForeignKey(
                        name: "FK_ContainerSupplier_Containers_ContainersId",
                        column: x => x.ContainersId,
                        principalTable: "Containers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContainerSupplier_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerSupplier_SuppliersId",
                table: "ContainerSupplier",
                column: "SuppliersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SchedulingProcesses_ScheduleProcessId",
                table: "Packages",
                column: "ScheduleProcessId",
                principalTable: "SchedulingProcesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_SchedulingProcesses_ScheduleProcessId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "ContainerSupplier");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchedulingProcesses",
                table: "SchedulingProcesses");

            migrationBuilder.RenameTable(
                name: "SchedulingProcesses",
                newName: "SchedulingProcess");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchedulingProcess",
                table: "SchedulingProcess",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SchedulingProcess_ScheduleProcessId",
                table: "Packages",
                column: "ScheduleProcessId",
                principalTable: "SchedulingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
