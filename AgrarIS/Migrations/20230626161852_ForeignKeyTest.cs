using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrarIS.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Parcela",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcela_KorisnikId",
                table: "Parcela",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcela_Korisnik_KorisnikId",
                table: "Parcela",
                column: "KorisnikId",
                principalTable: "Korisnik",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcela_Korisnik_KorisnikId",
                table: "Parcela");

            migrationBuilder.DropIndex(
                name: "IX_Parcela_KorisnikId",
                table: "Parcela");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Parcela");
        }
    }
}
