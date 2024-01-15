using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddItemsForFiveDaysWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "FiveDaysWeatherCalls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "FiveDaysWeatherCalls",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Lat",
                table: "FiveDaysWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Lon",
                table: "FiveDaysWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "FiveDaysWeatherCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sunrise",
                table: "FiveDaysWeatherCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sunset",
                table: "FiveDaysWeatherCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Timezone",
                table: "FiveDaysWeatherCalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FiveDaysWeatherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Dt = table.Column<int>(type: "int", nullable: false),
                    Temp = table.Column<double>(type: "double", nullable: false),
                    FeelsLike = table.Column<double>(type: "double", nullable: false),
                    TempMin = table.Column<double>(type: "double", nullable: false),
                    TempMax = table.Column<double>(type: "double", nullable: false),
                    Pressure = table.Column<int>(type: "int", nullable: false),
                    SeaLevel = table.Column<int>(type: "int", nullable: false),
                    GroundLevel = table.Column<int>(type: "int", nullable: false),
                    Humidity = table.Column<int>(type: "int", nullable: false),
                    MinMaxTempDiff = table.Column<double>(type: "double", nullable: false),
                    WeatherMain = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeatherDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeatherIcon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Visibility = table.Column<int>(type: "int", nullable: false),
                    Pop = table.Column<double>(type: "double", nullable: false),
                    Rain = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Snow = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CloudsAll = table.Column<int>(type: "int", nullable: false),
                    WindSpeed = table.Column<double>(type: "double", nullable: false),
                    WindDeg = table.Column<int>(type: "int", nullable: false),
                    WindGust = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_FiveDaysWeatherCalls_Id",
                        column: x => x.Id,
                        principalTable: "FiveDaysWeatherCalls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Lat",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Lon",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Population",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Sunrise",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Sunset",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Timezone",
                table: "FiveDaysWeatherCalls");
        }
    }
}
