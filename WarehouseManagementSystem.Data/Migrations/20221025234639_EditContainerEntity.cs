using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse_management_system.Migrations
{
    public partial class EditContainerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContainerNumber",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainerNumber",
                table: "Containers");
        }
    }
}
