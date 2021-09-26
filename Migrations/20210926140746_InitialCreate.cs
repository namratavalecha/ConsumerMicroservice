using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsumerMicroservice.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "businesses",
                columns: table => new
                {
                    BusinessId = table.Column<string>(nullable: false),
                    BusinessType = table.Column<string>(nullable: true),
                    AnnualTurnOver = table.Column<int>(nullable: false),
                    TotalEmployees = table.Column<int>(nullable: false),
                    CapitalInvested = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_businesses", x => x.BusinessId);
                });

            migrationBuilder.CreateTable(
                name: "consumers",
                columns: table => new
                {
                    ConsumerId = table.Column<string>(nullable: false),
                    ConsumerName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Pan = table.Column<string>(nullable: true),
                    BusinessOverview = table.Column<string>(nullable: true),
                    ValidityofConsumer = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    AgentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consumers", x => x.ConsumerId);
                });

            migrationBuilder.CreateTable(
                name: "properties",
                columns: table => new
                {
                    PropertyId = table.Column<string>(nullable: false),
                    BuildingSqft = table.Column<int>(nullable: false),
                    BuildingType = table.Column<string>(nullable: true),
                    BuildingStoreys = table.Column<int>(nullable: false),
                    BuildingAge = table.Column<int>(nullable: false),
                    CostOfTheAsset = table.Column<int>(nullable: false),
                    SalvageValue = table.Column<int>(nullable: false),
                    UsefulLifeOfTheAsset = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_properties", x => x.PropertyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "businesses");

            migrationBuilder.DropTable(
                name: "consumers");

            migrationBuilder.DropTable(
                name: "properties");
        }
    }
}
