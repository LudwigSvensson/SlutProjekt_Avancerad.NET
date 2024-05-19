using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlutProjekt_Avancerad.NET.Migrations
{
    /// <inheritdoc />
    public partial class AddedHistoryClassModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7761));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 14, 17, 2, 41, 445, DateTimeKind.Local).AddTicks(7831));
        }
    }
}
