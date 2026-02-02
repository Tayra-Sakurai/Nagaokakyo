using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kizu.Migrations
{
    /// <inheritdoc />
    public partial class CreationKizu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Item = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cash = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Icoca = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Nanaco = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0),
                    Coop = table.Column<int>(type: "INTEGER", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tables");
        }
    }
}
