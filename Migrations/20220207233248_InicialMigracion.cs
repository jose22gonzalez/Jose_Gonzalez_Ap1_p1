using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jose_Gonzalez_Ap1_p1.Migrations
{
    public partial class InicialMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Productoid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Existencia = table.Column<string>(type: "TEXT", nullable: true),
                    Costo = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorInventario = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Productoid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
