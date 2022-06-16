using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoomby.Migrations
{
    public partial class Zoombies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Pic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Pic", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_ZoomAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_ZoomAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ZoomScheduler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Agenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PicId = table.Column<int>(type: "int", nullable: false),
                    ZoomAccountId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ZoomScheduler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ZoomScheduler_M_Pic_PicId",
                        column: x => x.PicId,
                        principalTable: "M_Pic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_ZoomScheduler_M_ZoomAccount_ZoomAccountId",
                        column: x => x.ZoomAccountId,
                        principalTable: "M_ZoomAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ZoomScheduler_PicId",
                table: "T_ZoomScheduler",
                column: "PicId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ZoomScheduler_ZoomAccountId",
                table: "T_ZoomScheduler",
                column: "ZoomAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ZoomScheduler");

            migrationBuilder.DropTable(
                name: "M_Pic");

            migrationBuilder.DropTable(
                name: "M_ZoomAccount");
        }
    }
}
