using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SlutProjekt_Avancerad.NET.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ApointmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentType = table.Column<int>(type: "int", nullable: false),
                    AppointmentStatus = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ApointmentID);
                    table.ForeignKey(
                        name: "FK_Appointments_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyID", "CompanyName" },
                values: new object[,]
                {
                    { 1, "Dagges tvätt" },
                    { 2, "Mulles bilmeck" },
                    { 3, "example ex" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerEmail", "CustomerName" },
                values: new object[,]
                {
                    { 1, "ludwig@hotmail.com", "Ludwig" },
                    { 2, "robin@gmail.com", "Robin" },
                    { 3, "sara@yahoo.com", "Sara" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "ApointmentID", "AppointmentDate", "AppointmentStatus", "AppointmentType", "CompanyID", "CustomerID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7761), 0, 0, 2, 1 },
                    { 2, new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7820), 2, 2, 3, 2 },
                    { 3, new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7831), 1, 1, 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompanyID",
                table: "Appointments",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerID",
                table: "Appointments",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
