using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.EF.Migrations
{
    /// <inheritdoc />
    public partial class Add_SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Contact");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Contact",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contact",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Contact",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "City", "Country", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5cd999ba-d860-4071-8132-375fe49f27f1"), "Davao City", "Philippines", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("f27c04d5-53e7-4962-9d68-604034a044c7"), "Cebu City", "Philippines", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "enum.Work.Type",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Engineer" },
                    { (byte)2, "Designer" },
                    { (byte)3, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "LocationId", "MobileNumber", "UpdatedAt", "WorkTypeId" },
                values: new object[] { new Guid("d3351cd6-bd41-4892-8629-4404fa6f46a8"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juan@example.com", "Juan Dela Cruz", new Guid("f27c04d5-53e7-4962-9d68-604034a044c7"), "09171234567", null, (byte)1 });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_LocationId",
                table: "Contact",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Location",
                table: "Contact",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Location",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Contact_LocationId",
                table: "Contact");

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("d3351cd6-bd41-4892-8629-4404fa6f46a8"));

            migrationBuilder.DeleteData(
                table: "enum.Work.Type",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "enum.Work.Type",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "enum.Work.Type",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Contact");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Contact",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Contact",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Contact",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
