using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestWithASPNET.Migrations
{
    /// <inheritdoc />
    public partial class SeedPersonAndBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "id", "author", "launch_date", "price", "title" },
                values: new object[,]
                {
                    { 1L, "Aghata Christie", new DateTime(1931, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85.99m, "O caso dos dez negrinhos" },
                    { 2L, "Aghata Christie", new DateTime(1946, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 77.50m, "O assassinato no expresso do oriente" },
                    { 3L, "José de Alencar", new DateTime(1977, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 54.00m, "O guarani" },
                    { 4L, "Julio Verne", new DateTime(1880, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.99m, "A volta ao mundo em 80 dias" },
                    { 5L, "Julio Verne", new DateTime(1976, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 75.00m, "Vinte léguas submarinas" }
                });

            migrationBuilder.InsertData(
                table: "person",
                columns: new[] { "id", "address", "first_name", "gender", "last_name" },
                values: new object[,]
                {
                    { 1L, "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP", "Cristiano", "Male", "Ap Lázaro" },
                    { 2L, "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP", "Elenice", "Female", "C Lázaro" },
                    { 3L, "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP", "Cristiane", "Female", "C Lázaro" },
                    { 4L, "Rua José de Matos, 79 - Jdim Vale Verde - B Campos SP", "Bruno", "Male", "C Lázaro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "book",
                keyColumn: "id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "person",
                keyColumn: "id",
                keyValue: 4L);
        }
    }
}
