using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddedItemCountForOrderItemAndCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderItemCount",
                table: "OrderItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartItemCount",
                table: "CartItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderItemCount",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CartItemCount",
                table: "CartItem");
        }
    }
}
