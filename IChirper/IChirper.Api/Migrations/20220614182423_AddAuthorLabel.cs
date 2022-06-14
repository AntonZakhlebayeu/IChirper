using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IChirper.Controllers.@base.Migrations
{
    public partial class AddAuthorLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_AspNetUsers_IntId",
                table: "AspNetUsers",
                column: "IntId");

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
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.GuidId);
                    table.UniqueConstraint("AK_Page_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    GuidId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagsCollection = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.GuidId);
                    table.UniqueConstraint("AK_Post_Id", x => x.Id);
                });

            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[] { "a3138574-071e-4118-a32a-9aa4c8caeb04", "f60c2b6c-3a48-4c93-a177-6a9f9acd74ce", "user", "USER" });
            //
            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[] { "e535ea38-38c6-4cd1-9bfe-dc389bb7f2ac", "e5a77231-2231-4ea4-8179-1089a8f896c2", "moderator", "MODERATOR" });
            //
            // migrationBuilder.InsertData(
            //     table: "AspNetRoles",
            //     columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //     values: new object[] { "eeb22a02-3878-4fa2-af54-254352d9f934", "13b3cb5c-71fe-495a-b23d-a84dd4ec4d94", "admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_AspNetUsers_IntId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a3138574-071e-4118-a32a-9aa4c8caeb04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e535ea38-38c6-4cd1-9bfe-dc389bb7f2ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eeb22a02-3878-4fa2-af54-254352d9f934");
        }
    }
}
