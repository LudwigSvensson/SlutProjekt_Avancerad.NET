using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlutProjekt_Avancerad.NET.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteRestrict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 17, 47, 55, 641, DateTimeKind.Local).AddTicks(5980));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 17, 47, 55, 641, DateTimeKind.Local).AddTicks(6048));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 17, 47, 55, 641, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ApointmentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ApointmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
