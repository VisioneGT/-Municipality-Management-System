using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MunicipalityManagementSystem2.Migrations
{
    /// <inheritdoc />
    public partial class AddReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_serivices_Citizens_CitizenID",
                table: "serivices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_serivices",
                table: "serivices");

            migrationBuilder.RenameTable(
                name: "serivices",
                newName: "ServiceRequests");

            migrationBuilder.RenameIndex(
                name: "IX_serivices_CitizenID",
                table: "ServiceRequests",
                newName: "IX_ServiceRequests_CitizenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceRequests",
                table: "ServiceRequests",
                column: "RequestID");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenID = table.Column<int>(type: "int", nullable: true),
                    ReportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_Reports_Citizens_CitizenID",
                        column: x => x.CitizenID,
                        principalTable: "Citizens",
                        principalColumn: "CitizenId");
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CitizenID",
                table: "Reports",
                column: "CitizenID");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenID",
                table: "ServiceRequests",
                column: "CitizenID",
                principalTable: "Citizens",
                principalColumn: "CitizenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceRequests_Citizens_CitizenID",
                table: "ServiceRequests");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceRequests",
                table: "ServiceRequests");

            migrationBuilder.RenameTable(
                name: "ServiceRequests",
                newName: "serivices");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceRequests_CitizenID",
                table: "serivices",
                newName: "IX_serivices_CitizenID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_serivices",
                table: "serivices",
                column: "RequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_serivices_Citizens_CitizenID",
                table: "serivices",
                column: "CitizenID",
                principalTable: "Citizens",
                principalColumn: "CitizenId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
