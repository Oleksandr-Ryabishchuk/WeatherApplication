using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class ConnectOtherCrucialEntitiesToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "Records",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "FiveDaysWeatherCalls",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "TenantId",
                table: "CurrentWeatherCalls",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Records_TenantId",
                table: "Records",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FiveDaysWeatherCalls_TenantId",
                table: "FiveDaysWeatherCalls",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentWeatherCalls_TenantId",
                table: "CurrentWeatherCalls",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentWeatherCalls_Tenants_TenantId",
                table: "CurrentWeatherCalls",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FiveDaysWeatherCalls_Tenants_TenantId",
                table: "FiveDaysWeatherCalls",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Tenants_TenantId",
                table: "Records",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrentWeatherCalls_Tenants_TenantId",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_FiveDaysWeatherCalls_Tenants_TenantId",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Tenants_TenantId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_TenantId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_FiveDaysWeatherCalls_TenantId",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropIndex(
                name: "IX_CurrentWeatherCalls_TenantId",
                table: "CurrentWeatherCalls");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "FiveDaysWeatherCalls");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "CurrentWeatherCalls");
        }
    }
}
