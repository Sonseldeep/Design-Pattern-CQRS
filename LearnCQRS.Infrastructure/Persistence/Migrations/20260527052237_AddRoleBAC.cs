using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnCQRS.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleBAC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Roles",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Roles",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "AdminId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrainerId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
