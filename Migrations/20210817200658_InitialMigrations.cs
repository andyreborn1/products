using Microsoft.EntityFrameworkCore.Migrations;

namespace meus_produtos.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Status", "Value" },
                values: new object[] { 1, "Borracha", true, 0.50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Status", "Value" },
                values: new object[] { 2, "Lápis", false, 0.90m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "andy@gmail.com", "Anderson Vinicius", "1234578" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "bruno@gmail.com", "Bruno Josep", "67897845" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
