using Microsoft.EntityFrameworkCore.Migrations;

namespace TelepathyLabs.ShowReels.Domain.Migrations
{
    public partial class Initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShowReels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    VideoStandard = table.Column<short>(type: "smallint", nullable: false),
                    VideoDefinition = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowReels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoClips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", nullable: false),
                    VideoStandard = table.Column<short>(type: "smallint", nullable: false),
                    VideoDefinition = table.Column<short>(type: "smallint", nullable: false),
                    StartTimeCodeId = table.Column<int>(type: "int", nullable: true),
                    ShowReelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoClips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoClips_ShowReels_ShowReelId",
                        column: x => x.ShowReelId,
                        principalTable: "ShowReels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    Seconds = table.Column<int>(type: "int", nullable: false),
                    Frames = table.Column<int>(type: "int", nullable: false),
                    FramesPerSecond = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeCodes_VideoClips_Id",
                        column: x => x.Id,
                        principalTable: "VideoClips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoClips_ShowReelId",
                table: "VideoClips",
                column: "ShowReelId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoClips_StartTimeCodeId",
                table: "VideoClips",
                column: "StartTimeCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoClips_TimeCodes_StartTimeCodeId",
                table: "VideoClips",
                column: "StartTimeCodeId",
                principalTable: "TimeCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeCodes_VideoClips_Id",
                table: "TimeCodes");

            migrationBuilder.DropTable(
                name: "VideoClips");

            migrationBuilder.DropTable(
                name: "ShowReels");

            migrationBuilder.DropTable(
                name: "TimeCodes");
        }
    }
}
