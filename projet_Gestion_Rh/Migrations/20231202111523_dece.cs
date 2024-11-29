using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projet_Gestion_Rh.Migrations
{
    /// <inheritdoc />
    public partial class dece : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nomPrenom",
                table: "Employes",
                newName: "NomPrenom");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "Employes",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Employes",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "nomResponsable",
                table: "Departement",
                newName: "NomResponsable");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Departement",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Departement",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NomPrenom",
                table: "Employes",
                newName: "nomPrenom");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "Employes",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employes",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "NomResponsable",
                table: "Departement",
                newName: "nomResponsable");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Departement",
                newName: "nom");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Departement",
                newName: "description");
        }
    }
}
