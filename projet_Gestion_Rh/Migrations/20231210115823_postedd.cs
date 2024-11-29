using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_Gestion_Rh.Migrations
{
    /// <inheritdoc />
    public partial class postedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosteId",
                table: "Employes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Postes",
                columns: table => new
                {
                    PosteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salaire = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postes", x => x.PosteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employes_PosteId",
                table: "Employes",
                column: "PosteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes",
                column: "PosteId",
                principalTable: "Postes",
                principalColumn: "PosteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes");

            migrationBuilder.DropTable(
                name: "Postes");

            migrationBuilder.DropIndex(
                name: "IX_Employes_PosteId",
                table: "Employes");

            migrationBuilder.DropColumn(
                name: "PosteId",
                table: "Employes");
        }
    }
}
