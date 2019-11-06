using Microsoft.EntityFrameworkCore.Migrations;

namespace I4DAB_LAB2.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Price = table.Column<float>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Address = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Address);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    Number = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    Salery = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Stars = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    RestaurantAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Stars);
                    table.ForeignKey(
                        name: "FK_Reviews_Restaurants_RestaurantAddress",
                        column: x => x.RestaurantAddress,
                        principalTable: "Restaurants",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantAddress",
                table: "Reviews",
                column: "RestaurantAddress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
