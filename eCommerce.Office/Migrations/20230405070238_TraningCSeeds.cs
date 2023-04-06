using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    public partial class TraningCSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TrainingClasses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 1, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(425), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 6, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(453), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 4, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(456), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 5, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(455), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 2, 3 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(457), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 3, 4 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 4, 2, 38, 359, DateTimeKind.Unspecified).AddTicks(459), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "TrainingClasses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Class A" },
                    { 2, "Class B" },
                    { 3, "Class C" },
                    { 4, "Class D" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TrainingClasses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainingClasses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainingClasses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainingClasses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "TrainingClasses",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 1, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 6, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 4, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 5, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4915), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 2, 3 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 3, 4 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4919), new TimeSpan(0, -3, 0, 0, 0)));
        }
    }
}
