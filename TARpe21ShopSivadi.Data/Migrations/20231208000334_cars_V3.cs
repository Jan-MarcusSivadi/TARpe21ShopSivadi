using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TARpe21ShopSivadi.Data.Migrations
{
    public partial class cars_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpaceshipId",
                table: "FileToDatabase",
                newName: "EntityId");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "FilesToApi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "FilesToApi",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilesToApi_CarId",
                table: "FilesToApi",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilesToApi_Cars_CarId",
                table: "FilesToApi",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilesToApi_Cars_CarId",
                table: "FilesToApi");

            migrationBuilder.DropIndex(
                name: "IX_FilesToApi_CarId",
                table: "FilesToApi");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "FilesToApi");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "FilesToApi");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "FileToDatabase",
                newName: "SpaceshipId");
        }
    }
}
