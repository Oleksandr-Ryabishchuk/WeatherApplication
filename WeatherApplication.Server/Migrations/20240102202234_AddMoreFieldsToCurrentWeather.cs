using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreFieldsToCurrentWeather : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "CloudsAll",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Humidity",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Pressure",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Temp",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "WindSpeed",
                table: "CurrentWeatherCalls",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloudsAll",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Humidity",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Pressure",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "Temp",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "WindSpeed",
                table: "CurrentWeatherCalls");
        }
    }
}
