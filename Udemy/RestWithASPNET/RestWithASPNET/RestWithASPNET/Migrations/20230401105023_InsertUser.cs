using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestWithASPNET.Migrations
{
    /// <inheritdoc />
    public partial class InsertUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "user_name", "password", "full_name", "refresh_token", "refresh_token_expiry_time" },
                values: new object[]
                {
                    1L, "cristiano", "24-0B-E5-18-FA-BD-27-24-DD-B6-F0-4E-EB-1D-A5-96-74-48-D7-E8-31-C0-8C-8F-A8-22-80-9F-74-C7-20-A9", "CRISTIANO APARECIDO LÁZARO", "h9lzVOoLlBoTbcQrh/e16/aIj+4p6C67lLdDbBRMsjE=", "2023-04-03 17:30:49"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 1L
                );
        }
    }
}
