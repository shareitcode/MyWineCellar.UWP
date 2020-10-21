using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWineCellar.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wines",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Producer = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: false),
                    Appellation = table.Column<string>(nullable: false),
                    Parcel = table.Column<string>(nullable: false),
                    Vintage = table.Column<short>(maxLength: 4, nullable: false),
                    Quantity = table.Column<short>(nullable: false),
                    Color = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    AcquisitionDate = table.Column<DateTime>(nullable: false),
                    AcquisitionMeans = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wines", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Appellation",
                table: "Wines",
                column: "Appellation");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Country",
                table: "Wines",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Id",
                table: "Wines",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Parcel",
                table: "Wines",
                column: "Parcel");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Producer",
                table: "Wines",
                column: "Producer");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_Region",
                table: "Wines",
                column: "Region");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wines");
        }
    }
}
