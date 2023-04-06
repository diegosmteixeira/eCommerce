using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    public partial class EmployeeVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeesId",
                table: "EmployeeVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Vehicles_VehiclesId",
                table: "EmployeeVehicle");

            migrationBuilder.RenameColumn(
                name: "VehiclesId",
                table: "EmployeeVehicle",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeVehicle",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeVehicle_VehiclesId",
                table: "EmployeeVehicle",
                newName: "IX_EmployeeVehicle_EmployeeId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "EmployeeVehicle",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 1, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(744), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 6, 1 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(865), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 4, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(873), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 5, 2 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(871), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 2, 3 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(875), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "EmployeesSections",
                keyColumns: new[] { "EmployeeId", "SectionId" },
                keyValues: new object[] { 3, 4 },
                column: "Created",
                value: new DateTimeOffset(new DateTime(2023, 4, 5, 21, 31, 17, 788, DateTimeKind.Unspecified).AddTicks(877), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "LicensePlate", "Name" },
                values: new object[,]
                {
                    { 1, "ABC-7771", "Alfa Romeo - C43" },
                    { 2, "ABC-7772", "AlphaTauri - AT04" },
                    { 3, "ABC-7773", "Alpine - A523" },
                    { 4, "ABC-7774", "Aston Martin - AMR23" },
                    { 5, "ABC-7775", "Ferrari - SF-23" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeeId",
                table: "EmployeeVehicle",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Vehicles_VehicleId",
                table: "EmployeeVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeeId",
                table: "EmployeeVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeVehicle_Vehicles_VehicleId",
                table: "EmployeeVehicle");

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "EmployeeVehicle");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeVehicle",
                newName: "VehiclesId");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "EmployeeVehicle",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeVehicle_EmployeeId",
                table: "EmployeeVehicle",
                newName: "IX_EmployeeVehicle_VehiclesId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Employees_EmployeesId",
                table: "EmployeeVehicle",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeVehicle_Vehicles_VehiclesId",
                table: "EmployeeVehicle",
                column: "VehiclesId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
