using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeyFromIdToFiveDaysWeatherId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_Id",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Items_FiveDaysWeatherId",
                table: "Items",
                column: "FiveDaysWeatherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Items",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_FiveDaysWeatherId",
                table: "Items");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_Id",
                table: "Items",
                column: "Id",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
