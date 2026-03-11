using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityManagementSystem2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTimeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Citizens");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Citizens",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Citizens",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Citizens",
                newName: "CitizenId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Citizens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Citizens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AlterColumn<DateTime>(
                 name: "RegistrationDate",  // Use the correct column name
                 table: "Citizens",         // Use the correct table name
                 type: "datetime2",         // Change the type to datetime2
                 nullable: false,
                 oldClrType: typeof(DateTime),
                 oldType: "datetime");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Citizens");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Citizens");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Citizens",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Citizens",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "CitizenId",
                table: "Citizens",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Citizens",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
