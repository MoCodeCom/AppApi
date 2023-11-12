using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace appapi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    line_one = table.Column<string>(type: "TEXT", nullable: true),
                    line_second = table.Column<string>(type: "TEXT", nullable: true),
                    postcode = table.Column<string>(type: "TEXT", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: true),
                    country = table.Column<string>(type: "TEXT", nullable: true),
                    phone = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    userid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false),
                    first_name = table.Column<string>(type: "TEXT", nullable: true),
                    last_name = table.Column<string>(type: "TEXT", nullable: true),
                    id_address = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                    table.ForeignKey(
                        name: "FK_User_Address_id",
                        column: x => x.id,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_userid",
                table: "Address",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_userid",
                table: "Address",
                column: "userid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_userid",
                table: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
