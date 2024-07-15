using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedAbout : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "BikeWorkshops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "BikeWorkshops");
        }
    }
}
