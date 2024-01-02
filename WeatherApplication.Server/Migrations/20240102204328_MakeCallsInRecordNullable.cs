using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class MakeCallsInRecordNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "FiveDaysWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records",
                column: "CurrentWeatherId",
                principalTable: "CurrentWeatherCalls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "FiveDaysWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentWeatherId",
                table: "Records",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_CurrentWeatherCalls_CurrentWeatherId",
                table: "Records",
                column: "CurrentWeatherId",
                principalTable: "CurrentWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_FiveDaysWeatherCalls_FiveDaysWeatherId",
                table: "Records",
                column: "FiveDaysWeatherId",
                principalTable: "FiveDaysWeatherCalls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
