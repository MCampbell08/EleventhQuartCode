using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace StreamerSite.API.Migrations
{
    public partial class StreamerSiteAPIDataStreamersContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Admin = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FollowerCount = table.Column<int>(nullable: false),
                    PageViewCount = table.Column<int>(nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 14, nullable: true),
                    SubcriberCount = table.Column<int>(nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    AccessToken = table.Column<string>(type: "TEXT"),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Name = table.Column<string>(nullable: true),
                    UserDetailId = table.Column<int>(nullable: true),
                    MongoId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Video_User_UserDetailId",
                        column: x => x.UserDetailId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Video_UserDetailId",
                table: "Video",
                column: "UserDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
