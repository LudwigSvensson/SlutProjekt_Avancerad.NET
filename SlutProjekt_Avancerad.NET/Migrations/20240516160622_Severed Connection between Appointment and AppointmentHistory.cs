using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlutProjekt_Avancerad.NET.Migrations
{
    /// <inheritdoc />
    public partial class SeveredConnectionbetweenAppointmentandAppointmentHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentHistories_AppointmentID",
                table: "AppointmentHistories");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4424));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "ApointmentID",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2024, 5, 16, 18, 6, 22, 245, DateTimeKind.Local).AddTicks(4469));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentHistories_AppointmentID",
                table: "AppointmentHistories",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentHistories_Appointments_AppointmentID",
                table: "AppointmentHistories",
                column: "AppointmentID",
                principalTable: "Appointments",
                principalColumn: "ApointmentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
