using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrarIS.Migrations
{
    /// <inheritdoc />
    public partial class addedpestpolj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PesticidPoljoprivrednoDobro",
                columns: table => new
                {
                    PesticidisId = table.Column<int>(type: "int", nullable: false),
                    PoljoprivrednoDobrosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticidPoljoprivrednoDobro", x => new { x.PesticidisId, x.PoljoprivrednoDobrosId });
                    table.ForeignKey(
                        name: "FK_PesticidPoljoprivrednoDobro_Pesticid_PesticidisId",
                        column: x => x.PesticidisId,
                        principalTable: "Pesticid",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesticidPoljoprivrednoDobro_PoljoprivrednoDobro_PoljoprivrednoDobrosId",
                        column: x => x.PoljoprivrednoDobrosId,
                        principalTable: "PoljoprivrednoDobro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PesticidPoljoprivrednoDobro_PoljoprivrednoDobrosId",
                table: "PesticidPoljoprivrednoDobro",
                column: "PoljoprivrednoDobrosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PesticidPoljoprivrednoDobro");
        }
    }
}
