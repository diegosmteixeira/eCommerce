using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCommerce.Office.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingClasses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesSections",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesSections", x => new { x.SectionId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeesSections_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesSections_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTrainingClass",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    TrainingClassesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTrainingClass", x => new { x.EmployeesId, x.TrainingClassesId });
                    table.ForeignKey(
                        name: "FK_EmployeeTrainingClass_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTrainingClass_TrainingClasses_TrainingClassesId",
                        column: x => x.TrainingClassesId,
                        principalTable: "TrainingClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVehicle",
                columns: table => new
                {
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    VehiclesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVehicle", x => new { x.EmployeesId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_EmployeeVehicle_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "José" },
                    { 2, "Mary" },
                    { 3, "Phillip" },
                    { 4, "Joe" },
                    { 5, "Paul" },
                    { 6, "Zoe" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Delivery" },
                    { 2, "Transport" },
                    { 3, "Marketing" },
                    { 4, "Management" }
                });

            migrationBuilder.InsertData(
                table: "EmployeesSections",
                columns: new[] { "EmployeeId", "SectionId", "Created" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4835), new TimeSpan(0, -3, 0, 0, 0)) },
                    { 6, 1, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4913), new TimeSpan(0, -3, 0, 0, 0)) },
                    { 4, 2, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4916), new TimeSpan(0, -3, 0, 0, 0)) },
                    { 5, 2, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4915), new TimeSpan(0, -3, 0, 0, 0)) },
                    { 2, 3, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4918), new TimeSpan(0, -3, 0, 0, 0)) },
                    { 3, 4, new DateTimeOffset(new DateTime(2023, 4, 4, 15, 41, 52, 429, DateTimeKind.Unspecified).AddTicks(4919), new TimeSpan(0, -3, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesSections_EmployeeId",
                table: "EmployeesSections",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTrainingClass_TrainingClassesId",
                table: "EmployeeTrainingClass",
                column: "TrainingClassesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeVehicle_VehiclesId",
                table: "EmployeeVehicle",
                column: "VehiclesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesSections");

            migrationBuilder.DropTable(
                name: "EmployeeTrainingClass");

            migrationBuilder.DropTable(
                name: "EmployeeVehicle");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "TrainingClasses");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
