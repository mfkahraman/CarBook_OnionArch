using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook_OnionArch.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rental_rel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_PickUpLocationId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_PickUpLocationId",
                table: "Rentals",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_PickUpLocationId",
                table: "Rentals");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_DropOffLocationId",
                table: "Rentals",
                column: "DropOffLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_PickUpLocationId",
                table: "Rentals",
                column: "PickUpLocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
