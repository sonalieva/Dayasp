using Microsoft.EntityFrameworkCore.Migrations;

namespace Dayasp.Migrations
{
    public partial class TeamTableCreted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(maxLength: 100, nullable: true),
                    Profession = table.Column<string>(maxLength: 50, nullable: true),
                    Desc = table.Column<string>(maxLength: 200, nullable: true),
                    TwitUrl = table.Column<string>(nullable: true),
                    FbUrl = table.Column<string>(nullable: true),
                    InsUrl = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
