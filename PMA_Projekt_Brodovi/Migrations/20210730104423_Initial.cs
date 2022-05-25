using Microsoft.EntityFrameworkCore.Migrations;

namespace PMA_Projekt_Brodovi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SvojstvaBrodova",
                columns: table => new
                {
                    SvojstvaBrodaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkaBroda = table.Column<string>(type: "varchar(100)", nullable: true),
                    ModelBroda = table.Column<string>(type: "varchar(100)", nullable: true),
                    Boja = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvojstvaBrodova", x => x.SvojstvaBrodaId);
                });

            migrationBuilder.CreateTable(
                name: "Vlasnici",
                columns: table => new
                {
                    VlasnikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImeVlasnika = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PrezimeVlasnika = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OibVlasnika = table.Column<string>(type: "nvarchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vlasnici", x => x.VlasnikId);
                });

            migrationBuilder.CreateTable(
                name: "Brodovi",
                columns: table => new
                {
                    BrodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SvojstvaBrodaId = table.Column<int>(type: "int", nullable: false),
                    VlasnikId = table.Column<int>(type: "int", nullable: false),
                    ImeBroda = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    RegistracijskeOznake = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brodovi", x => x.BrodId);
                    table.ForeignKey(
                        name: "FK_Brodovi_SvojstvaBrodova_SvojstvaBrodaId",
                        column: x => x.SvojstvaBrodaId,
                        principalTable: "SvojstvaBrodova",
                        principalColumn: "SvojstvaBrodaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brodovi_Vlasnici_VlasnikId",
                        column: x => x.VlasnikId,
                        principalTable: "Vlasnici",
                        principalColumn: "VlasnikId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brodovi_SvojstvaBrodaId",
                table: "Brodovi",
                column: "SvojstvaBrodaId");

            migrationBuilder.CreateIndex(
                name: "IX_Brodovi_VlasnikId",
                table: "Brodovi",
                column: "VlasnikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brodovi");

            migrationBuilder.DropTable(
                name: "SvojstvaBrodova");

            migrationBuilder.DropTable(
                name: "Vlasnici");
        }
    }
}
