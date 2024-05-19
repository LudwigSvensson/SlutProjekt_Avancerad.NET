using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlutProjekt_Avancerad.NET.Migrations
{
    /// <inheritdoc />
    public partial class HistoryClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentHistories",
                columns: table => new
                {
                    AppointmentHistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentHistories", x => x.AppointmentHistoryID);
                    table.ForeignKey(
                        name: "FK_AppointmentHistories_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ApointmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 36, 48, 676, DateTimeKind.Local).AddTicks(8761));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 36, 48, 676, DateTimeKind.Local).AddTicks(8788));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 36, 48, 676, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistories_AppointmentID",
                table: "AppointmentHistories",
                column: "AppointmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppointmentHistories");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 32, 3, 321, DateTimeKind.Local).AddTicks(5464));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 32, 3, 321, DateTimeKind.Local).AddTicks(5501));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 11, 32, 3, 321, DateTimeKind.Local).AddTicks(5511));
        }
    }
}
