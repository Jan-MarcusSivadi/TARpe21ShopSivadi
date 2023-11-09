using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopSivadi.Data.Migrations
{
    public partial class crudFinished2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_RealEstateId",
                table: "FilesToApi",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesToApi_RealEstates_RealEstateId",
                table: "FilesToApi",
                column: "RealEstateId",
                principalTable: "RealEstates",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesToApi_RealEstates_RealEstateId",
                table: "FilesToApi");

            migrationBuilder.DropIndex(
                name: "IX_FilesToApi_RealEstateId",
                table: "FilesToApi");
        }
    }
}
