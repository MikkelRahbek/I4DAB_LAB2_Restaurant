using Microsoft.EntityFrameworkCore.Migrations;

namespace I4DAB_LAB2.Migrations
{
    public partial class FinishedAllModelsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantAddress",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestaurantAddress",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RestaurantAddress",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Waiters",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Waiters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Waiters",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Tables",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "Tables",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "Reviews",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "People",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Guests",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Guests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewId",
                table: "Guests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Guests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Dishes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ReviewId",
                table: "Dishes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tables",
                table: "Tables",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guests",
                table: "Guests",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GuestDishes",
                columns: table => new
                {
                    DishId = table.Column<int>(nullable: false),
                    GuestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestDishes", x => new { x.DishId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestDishes_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantDishes",
                columns: table => new
                {
                    RestaurantId = table.Column<string>(nullable: false),
                    DishId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantDishes", x => new { x.RestaurantId, x.DishId });
                    table.ForeignKey(
                        name: "FK_RestaurantDishes_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantDishes_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Address",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaiterTables",
                columns: table => new
                {
                    WaiterId = table.Column<int>(nullable: false),
                    TableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaiterTables", x => new { x.TableId, x.WaiterId });
                    table.ForeignKey(
                        name: "FK_WaiterTables_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaiterTables_Waiters_WaiterId",
                        column: x => x.WaiterId,
                        principalTable: "Waiters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_PersonName",
                table: "Waiters",
                column: "PersonName",
                unique: true,
                filter: "[PersonName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_PersonName",
                table: "Guests",
                column: "PersonName",
                unique: true,
                filter: "[PersonName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_ReviewId",
                table: "Guests",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_TableId",
                table: "Guests",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ReviewId",
                table: "Dishes",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestDishes_GuestId",
                table: "GuestDishes",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDishes_DishId",
                table: "RestaurantDishes",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_WaiterTables_WaiterId",
                table: "WaiterTables",
                column: "WaiterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Reviews_ReviewId",
                table: "Dishes",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Text",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_People_PersonName",
                table: "Guests",
                column: "PersonName",
                principalTable: "People",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Reviews_ReviewId",
                table: "Guests",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "Text",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Guests_Tables_TableId",
                table: "Guests",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Number",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                table: "Reviews",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Waiters_People_PersonName",
                table: "Waiters",
                column: "PersonName",
                principalTable: "People",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Reviews_ReviewId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_People_PersonName",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Reviews_ReviewId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Guests_Tables_TableId",
                table: "Guests");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Restaurants_RestaurantId",
                table: "Tables");

            migrationBuilder.DropForeignKey(
                name: "FK_Waiters_People_PersonName",
                table: "Waiters");

            migrationBuilder.DropTable(
                name: "GuestDishes");

            migrationBuilder.DropTable(
                name: "RestaurantDishes");

            migrationBuilder.DropTable(
                name: "WaiterTables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Waiters",
                table: "Waiters");

            migrationBuilder.DropIndex(
                name: "IX_Waiters_PersonName",
                table: "Waiters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tables",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_RestaurantId",
                table: "Tables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RestaurantId",
                table: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guests",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_PersonName",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_ReviewId",
                table: "Guests");

            migrationBuilder.DropIndex(
                name: "IX_Guests_TableId",
                table: "Guests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ReviewId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Waiters");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Waiters");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Waiters");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Guests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Dishes");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Tables",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Stars",
                table: "Reviews",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "RestaurantAddress",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reviews",
                table: "Reviews",
                column: "Stars");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RestaurantAddress",
                table: "Reviews",
                column: "RestaurantAddress");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Restaurants_RestaurantAddress",
                table: "Reviews",
                column: "RestaurantAddress",
                principalTable: "Restaurants",
                principalColumn: "Address",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
