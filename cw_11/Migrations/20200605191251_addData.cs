using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw_11.Migrations
{
    public partial class addData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "ferdekKiepski@gmail.com", "Ferdek", "Kiepski" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(2020, 6, 5, 21, 19, 28, 715, DateTimeKind.Local).AddTicks(2835), "Marian", "Pazdzioch" });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2020, 6, 5, 21, 19, 28, 736, DateTimeKind.Local).AddTicks(2801), new DateTime(2020, 6, 7, 21, 19, 28, 736, DateTimeKind.Local).AddTicks(3353), 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);
        }
    }
}
