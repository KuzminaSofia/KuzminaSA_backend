using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KuzminaSA_backend.Migrations
{
    /// <inheritdoc />
    public partial class Hotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    desc = table.Column<string>(type: "TEXT", nullable: false),
                    guest = table.Column<string>(type: "TEXT", nullable: false),
                    price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "guest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    last_name = table.Column<string>(type: "TEXT", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: false),
                    happy_b = table.Column<string>(type: "TEXT", nullable: false),
                    hotelid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_guest_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "hotelroom",
                columns: table => new
                {
                    hotelid = table.Column<int>(type: "INTEGER", nullable: false),
                    roomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelroom", x => new { x.hotelid, x.roomId });
                    table.ForeignKey(
                        name: "FK_hotelroom_hotel_hotelid",
                        column: x => x.hotelid,
                        principalTable: "hotel",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotelroom_room_roomId",
                        column: x => x.roomId,
                        principalTable: "room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_guest_hotelid",
                table: "guest",
                column: "hotelid");

            migrationBuilder.CreateIndex(
                name: "IX_hotelroom_roomId",
                table: "hotelroom",
                column: "roomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "guest");

            migrationBuilder.DropTable(
                name: "hotelroom");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "hotel");

            migrationBuilder.DropTable(
                name: "room");
        }
    }
}
