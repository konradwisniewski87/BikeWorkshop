using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "BikeWorkshops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BikeWorkshops_CreatedById",
                table: "BikeWorkshops",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_BikeWorkshops_AspNetUsers_CreatedById",
                table: "BikeWorkshops",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BikeWorkshops_AspNetUsers_CreatedById",
                table: "BikeWorkshops");

            migrationBuilder.DropIndex(
                name: "IX_BikeWorkshops_CreatedById",
                table: "BikeWorkshops");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "BikeWorkshops");
        }
    }
}
