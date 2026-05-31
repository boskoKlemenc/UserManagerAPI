using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ApiClientSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ApiClients",
                columns: new[] { "Id", "ApiKey", "ClientName", "CreatedAt", "IsActive" },
                values: new object[,]
                {
                    { 1, "test-key-1", "TestClient1", new DateTime(2026, 5, 31, 14, 52, 17, 456, DateTimeKind.Utc).AddTicks(6070), true },
                    { 2, "test-key-2", "TestClient2", new DateTime(2026, 5, 31, 14, 52, 17, 456, DateTimeKind.Utc).AddTicks(6073), true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApiClients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ApiClients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
