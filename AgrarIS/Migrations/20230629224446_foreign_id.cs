using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrarIS.Migrations
{
    /// <inheritdoc />
    public partial class foreign_id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcela_Korisnik_KorisnikId",
                table: "Parcela");

            migrationBuilder.DropIndex(
                name: "IX_Parcela_KorisnikId",
                table: "Parcela");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Parcela",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Parcela",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
