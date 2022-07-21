using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bit2Byte.Migrations
{
    public partial class _331 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGallery");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AchievementId = table.Column<int>(type: "int", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGallery_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGallery_AchievementId",
                table: "BookGallery",
                column: "AchievementId");
        }
    }
}
