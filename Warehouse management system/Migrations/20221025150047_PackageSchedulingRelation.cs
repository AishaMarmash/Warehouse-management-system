using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class PackageSchedulingRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleProcessId",
                table: "Packages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SchedulingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActualIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedOut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProcess", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ScheduleProcessId",
                table: "Packages",
                column: "ScheduleProcessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SchedulingProcess_ScheduleProcessId",
                table: "Packages",
                column: "ScheduleProcessId",
                principalTable: "SchedulingProcess",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_SchedulingProcess_ScheduleProcessId",
                table: "Packages");

            migrationBuilder.DropTable(
                name: "SchedulingProcess");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ScheduleProcessId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "ScheduleProcessId",
                table: "Packages");
        }
    }
}
