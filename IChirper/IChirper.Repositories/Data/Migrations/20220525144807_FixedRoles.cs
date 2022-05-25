using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IChirper.Data.Migrations
{
    public partial class FixedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07f0ea61-bea8-4758-8aa7-e1b0683d5fda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7ebf3b1e-a686-408f-a25f-ccbb9ac6e04f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c91bbf52-8b56-4d48-9c11-554a999002c7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "282c0960-b0ff-4623-baa2-cfa7cbaae6b8", "12a17e28-3aec-4934-88f0-f9324161c264", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e3ccebb-9915-4203-b627-3a7044815565", "e20c7cd8-634d-4dfc-a993-4474a57269d2", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b2ac7b76-cd49-465f-9c9d-a684fce507db", "3ff67446-9719-4ce0-ac2a-a8334878b49f", "moderator", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "282c0960-b0ff-4623-baa2-cfa7cbaae6b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e3ccebb-9915-4203-b627-3a7044815565");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2ac7b76-cd49-465f-9c9d-a684fce507db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "07f0ea61-bea8-4758-8aa7-e1b0683d5fda", "1335edcf-8834-4921-8365-f943d9f6f43a", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ebf3b1e-a686-408f-a25f-ccbb9ac6e04f", "6440e296-b64d-47ea-b8e2-f861f62609f1", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c91bbf52-8b56-4d48-9c11-554a999002c7", "94b65bb4-8768-446c-978e-7fb53d2f9cca", "admin", "ADMIN" });
        }
    }
}
