using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Migrations
{
    public partial class TasksMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "CreatedAt", "Name", "Status" },
                values: new object[] { 1, new DateTime(2021, 8, 16, 12, 32, 50, 567, DateTimeKind.Local).AddTicks(7019), "Test1", 0 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "CreatedAt", "Name", "Status" },
                values: new object[] { 2, new DateTime(2021, 8, 16, 12, 32, 50, 573, DateTimeKind.Local).AddTicks(9469), "Test2", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
