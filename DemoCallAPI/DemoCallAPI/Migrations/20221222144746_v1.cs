using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCallAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    SongId = table.Column<string>(nullable: false),
                    Tittle = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Singer = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.SongId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_SongId",
                table: "Song",
                column: "SongId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
