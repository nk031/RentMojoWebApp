using System;
using System.IO;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentMojoWebApp.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentTypes",
                columns: table => new 
                {
                    TypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(maxLength: 100, nullable: false),
                    Extension = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTypes", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "RentSubTypes",
                columns: table => new
                {
                    SubTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTypeName = table.Column<string>(maxLength: 100, nullable: false),
                    Extension = table.Column<string>(maxLength: 20, nullable: false),
                    TypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentSubTypes", x => x.SubTypeID);
                    table.ForeignKey(
                        name: "FK_RentSubTypes_RentTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "RentTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    TagLine = table.Column<string>(maxLength: 200, nullable: false),
                    Deposit = table.Column<int>(nullable: false),
                    MonthlyRent = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 20, nullable: false),
                    SubTypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_RentSubTypes_SubTypeID",
                        column: x => x.SubTypeID,
                        principalTable: "RentSubTypes",
                        principalColumn: "SubTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(maxLength: 1000, nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<string>(maxLength: 200, nullable: false),
                    Deposit = table.Column<int>(nullable: false),
                    MonthlyRent = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductID",
                table: "Orders",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubTypeID",
                table: "Products",
                column: "SubTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RentSubTypes_TypeID",
                table: "RentSubTypes",
                column: "TypeID");

            var sqlFile = Path.Combine(".\\Scripts", @"backup.sql");
            migrationBuilder.Sql(File.ReadAllText(sqlFile));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RentSubTypes");

            migrationBuilder.DropTable(
                name: "RentTypes");
        }
    }
}
