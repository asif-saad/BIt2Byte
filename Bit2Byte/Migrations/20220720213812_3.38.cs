using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bit2Byte.Migrations
{
    public partial class _338 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookPdfUrl",
                table: "Achievements");

            migrationBuilder.CreateTable(
                name: "BookGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AchievementId = table.Column<int>(type: "int", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGallery");

            migrationBuilder.AddColumn<string>(
                name: "BookPdfUrl",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
