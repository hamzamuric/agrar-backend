using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrarIS.Migrations
{
    /// <inheritdoc />
    public partial class list_vocnjaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParcelaId",
                table: "Vocnjak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vocnjak_ParcelaId",
                table: "Vocnjak",
                column: "ParcelaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vocnjak_Parcela_ParcelaId",
                table: "Vocnjak",
                column: "ParcelaId",
                principalTable: "Parcela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocnjak_Parcela_ParcelaId",
                table: "Vocnjak");

            migrationBuilder.DropIndex(
                name: "IX_Vocnjak_ParcelaId",
                table: "Vocnjak");

            migrationBuilder.DropColumn(
                name: "ParcelaId",
                table: "Vocnjak");
        }
    }
}
