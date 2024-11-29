using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_Gestion_Rh.Migrations
{
    /// <inheritdoc />
    public partial class heldldldl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes");

            migrationBuilder.AlterColumn<int>(
                name: "PosteId",
                table: "Employes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes",
                column: "PosteId",
                principalTable: "Postes",
                principalColumn: "PosteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes");

            migrationBuilder.AlterColumn<int>(
                name: "PosteId",
                table: "Employes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employes_Postes_PosteId",
                table: "Employes",
                column: "PosteId",
                principalTable: "Postes",
                principalColumn: "PosteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
