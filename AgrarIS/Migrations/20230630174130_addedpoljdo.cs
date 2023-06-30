using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrarIS.Migrations
{
    /// <inheritdoc />
    public partial class addedpoljdo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoljoprivrednoDobroId",
                table: "Vocnjak",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VocnjakId",
                table: "PoljoprivrednoDobro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vocnjak_PoljoprivrednoDobroId",
                table: "Vocnjak",
                column: "PoljoprivrednoDobroId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vocnjak_PoljoprivrednoDobro_PoljoprivrednoDobroId",
                table: "Vocnjak",
                column: "PoljoprivrednoDobroId",
                principalTable: "PoljoprivrednoDobro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vocnjak_PoljoprivrednoDobro_PoljoprivrednoDobroId",
                table: "Vocnjak");

            migrationBuilder.DropIndex(
                name: "IX_Vocnjak_PoljoprivrednoDobroId",
                table: "Vocnjak");

            migrationBuilder.DropColumn(
                name: "PoljoprivrednoDobroId",
                table: "Vocnjak");

            migrationBuilder.DropColumn(
                name: "VocnjakId",
                table: "PoljoprivrednoDobro");
        }
    }
}
