using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelightDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MenuConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuReviewsId");

            migrationBuilder.CreateTable(
                name: "MenuReviewsIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MenuReviewId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviewsIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviewsIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviewsIds_MenuId",
                table: "MenuReviewsIds",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuReviewsIds");

            migrationBuilder.CreateTable(
                name: "MenuReviewsId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuReviewId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuReviewsId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuReviewsId_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuReviewsId_MenuId",
                table: "MenuReviewsId",
                column: "MenuId");
        }
    }
}
