using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook_OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
