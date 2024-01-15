using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_FiveDaysWeatherCalls_Id",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_Id",
                table: "Items",
                column: "Id",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_FiveDaysWeatherCalls_Id",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_FiveDaysWeatherCalls_Id",
                table: "Item",
                column: "Id",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
