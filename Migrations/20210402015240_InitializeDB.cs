using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroPi.Migrations
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outputs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("abf475ba-42bd-4bdc-8717-99cb304c2f28"), null, new DateTime(2021, 4, 2, 1, 52, 40, 705, DateTimeKind.Utc).AddTicks(405), "Output A" });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("51523f79-5af9-44b4-a584-db76a4b19ebf"), null, new DateTime(2021, 4, 2, 1, 52, 40, 705, DateTimeKind.Utc).AddTicks(440), "Output B" });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("01615b17-5b76-4272-a23e-072297f42b39"), null, new DateTime(2021, 4, 2, 1, 52, 40, 705, DateTimeKind.Utc).AddTicks(453), "Output C" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("cd48a90a-b72b-4609-b422-7a633505ca3c"), null, new DateTime(2021, 4, 2, 1, 52, 40, 764, DateTimeKind.Utc).AddTicks(5583), "Sensor A" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("44848670-502e-416c-822d-86d37f529401"), null, new DateTime(2021, 4, 2, 1, 52, 40, 764, DateTimeKind.Utc).AddTicks(5688), "Sensor B" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[] { new Guid("690a564d-77ee-45a6-bdab-3d91282c0cef"), null, new DateTime(2021, 4, 2, 1, 52, 40, 764, DateTimeKind.Utc).AddTicks(5704), "Sensor C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outputs");

            migrationBuilder.DropTable(
                name: "Sensors");
        }
    }
}
