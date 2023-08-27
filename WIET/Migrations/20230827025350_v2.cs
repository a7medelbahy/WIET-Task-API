using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WIET.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressTwo",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressTwo",
                table: "Employees",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}
