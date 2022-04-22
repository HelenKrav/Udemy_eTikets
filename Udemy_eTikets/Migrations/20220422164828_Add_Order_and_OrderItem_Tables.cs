using Microsoft.EntityFrameworkCore.Migrations;

namespace Udemy_eTikets.Migrations
{
    public partial class Add_Order_and_OrderItem_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Movies_MovieId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MovieId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "OrderItems");
        }
    }
}
