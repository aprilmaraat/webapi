using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.EF.Migrations
{
    /// <inheritdoc />
    public partial class Add_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Contact",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Contact",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Contact");
        }
    }
}
