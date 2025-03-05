using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class createtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "userClass",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userClass", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListDoctors_userClass_Id",
                        column: x => x.Id,
                        principalTable: "userClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListPatient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListPatient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListPatient_userClass_Id",
                        column: x => x.Id,
                        principalTable: "userClass",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListRoutes",
                columns: table => new
                {
                    IdRoutes = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorClassId = table.Column<int>(type: "int", nullable: true),
                    PatientClassId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListRoutes", x => x.IdRoutes);
                    table.ForeignKey(
                        name: "FK_ListRoutes_ListDoctors_DoctorClassId",
                        column: x => x.DoctorClassId,
                        principalTable: "ListDoctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListRoutes_ListDoctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "ListDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListRoutes_ListPatient_PatientClassId",
                        column: x => x.PatientClassId,
                        principalTable: "ListPatient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListRoutes_ListPatient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "ListPatient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListRoutes_DoctorClassId",
                table: "ListRoutes",
                column: "DoctorClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ListRoutes_DoctorId",
                table: "ListRoutes",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_ListRoutes_PatientClassId",
                table: "ListRoutes",
                column: "PatientClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ListRoutes_PatientId",
                table: "ListRoutes",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListRoutes");

            migrationBuilder.DropTable(
                name: "ListDoctors");

            migrationBuilder.DropTable(
                name: "ListPatient");

            migrationBuilder.DropTable(
                name: "userClass");
        }
    }
}
