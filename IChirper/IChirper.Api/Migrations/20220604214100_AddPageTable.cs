using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IChirper.Controllers.@base.Migrations
{
    public partial class AddPageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba64a632-2e08-4452-b2af-85a046e3b1da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bde12195-855c-4c95-b9f6-a4592418b260");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef3996fd-b1f7-4f9d-addd-f8478c278e14");
                */

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.GuidId);
                    table.UniqueConstraint("AK_Page_Id", x => x.Id);
                });
/*
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c082dc0a-0c86-4bb1-ad14-f83acf7a7800", "41f9e67b-1bd8-4fd3-8d72-a9832d6fd7e4", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3947f55-3f43-4ca4-9d15-40a0dfe716e7", "af58cf35-1ba1-42f9-a1cc-5fa96016ab3d", "moderator", "MODERATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb8dcbec-7ccb-4377-ba3b-6897afce0aa0", "c794b267-4ff4-4a24-bad1-beaea3ed7ed8", "user", "USER" });
                */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c082dc0a-0c86-4bb1-ad14-f83acf7a7800");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3947f55-3f43-4ca4-9d15-40a0dfe716e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb8dcbec-7ccb-4377-ba3b-6897afce0aa0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ba64a632-2e08-4452-b2af-85a046e3b1da", "13f000e6-8bf4-4797-bea9-3c68c4d26d99", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bde12195-855c-4c95-b9f6-a4592418b260", "1ef4914a-48b7-44c9-a3fe-0a81666017f2", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ef3996fd-b1f7-4f9d-addd-f8478c278e14", "225b07f1-5ba0-46ef-b9d6-cf026e1e1e34", "moderator", "MODERATOR" });
        }
    }
}
