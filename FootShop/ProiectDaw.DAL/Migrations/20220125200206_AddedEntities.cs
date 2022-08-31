using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW.DAL.Migrations
{
    public partial class AddedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Colour = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Desc = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "date", nullable: true),
                    ShoeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", precision: 2, scale: 0, nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    ShoeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoeOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoeOrder_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoeSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", precision: 5, scale: 0, nullable: false),
                    Size = table.Column<int>(type: "int", precision: 2, scale: 0, nullable: false),
                    ShoeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoeSize_Shoe_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_ShoeId",
                table: "Descriptions",
                column: "ShoeId",
                unique: true,
                filter: "[ShoeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ShoeId",
                table: "Offer",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeOrder_OrderId",
                table: "ShoeOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeOrder_ShoeId",
                table: "ShoeOrder",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSize_ShoeId",
                table: "ShoeSize",
                column: "ShoeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "ShoeOrder");

            migrationBuilder.DropTable(
                name: "ShoeSize");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Shoe");
        }
    }
}
