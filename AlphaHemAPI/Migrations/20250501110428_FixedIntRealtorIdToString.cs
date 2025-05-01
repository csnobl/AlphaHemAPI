using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlphaHemAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixedIntRealtorIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_RealtorId1",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_RealtorId1",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "RealtorId1",
                table: "Listings");

            migrationBuilder.AlterColumn<string>(
                name: "RealtorId",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealtorId",
                table: "Listings",
                column: "RealtorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_RealtorId",
                table: "Listings",
                column: "RealtorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_RealtorId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_RealtorId",
                table: "Listings");

            migrationBuilder.AlterColumn<int>(
                name: "RealtorId",
                table: "Listings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "RealtorId1",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_RealtorId1",
                table: "Listings",
                column: "RealtorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_RealtorId1",
                table: "Listings",
                column: "RealtorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
