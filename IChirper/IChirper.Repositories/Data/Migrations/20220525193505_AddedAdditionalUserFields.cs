using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IChirper.Controllers.@base.Migrations
{
    public partial class AddedAdditionalUserFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a66f9939-66ef-4d0a-8a0b-4740702e94ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae146df8-3f5e-43bb-b468-857315076d86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ee9f4a9a-c569-4b0f-8332-69a88f5f0758");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b90600d6-eeee-4e12-96fc-f0ffa4b2ce65", "893c60f6-9c0f-49f7-a749-f3dbaf6edb38", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7a74a21-98ea-4379-92d3-2d3a862c3e8b", "a3554be1-cf3e-4808-ac62-ed3b197e7f29", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e39fd600-356a-44e5-af43-1db89efa9f2b", "6d1f93de-5e6c-4877-bacb-dfd0d91a4953", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b90600d6-eeee-4e12-96fc-f0ffa4b2ce65");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7a74a21-98ea-4379-92d3-2d3a862c3e8b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39fd600-356a-44e5-af43-1db89efa9f2b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a66f9939-66ef-4d0a-8a0b-4740702e94ac", "a1744b07-f8e4-4aa6-98d5-50be042fc7dc", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae146df8-3f5e-43bb-b468-857315076d86", "ee58496c-f0e4-4d85-8895-b5c88e19416b", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ee9f4a9a-c569-4b0f-8332-69a88f5f0758", "86cd2881-8085-4ef6-a6a5-faa28441850e", "admin", "ADMIN" });
        }
    }
}
