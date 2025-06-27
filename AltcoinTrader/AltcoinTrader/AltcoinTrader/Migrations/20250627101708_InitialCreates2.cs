using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AltcoinTrader.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreates2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    CoinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoinTicker = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoinPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoinVote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.CoinID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
