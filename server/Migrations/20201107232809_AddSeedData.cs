using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Email", "Name", "Password", "Phone" },
                values: new object[] { 1, "admin@example.com", "admin", "$s2$16384$8$1$kve5s3vEqi8SD93fllHGH4U9GylAr7GJx98Dy7L8c3Q=$hf4Z9+SG9f+kTuWU5fWFiieRSpsIqbuM8/cdgtK7v4g=", "1234567890" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "camera" },
                    { 2, "watch" },
                    { 3, "glasses" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password", "Phone" },
                values: new object[] { 1, "ryuichi@example.com", "Ryuichi", "Nishi", "$s2$16384$8$1$iBv8lgtOZpHidMGhzqB9bq986GSX1LMtqzHtxqQZRKE=$mCc79YWOAbFQ75l8qmbcRRVzDRf0jsEUShJLiv/XHRk=", "0123456789" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "Inventory", "Name", "Price" },
                values: new object[] { 1, 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.", "https://images.unsplash.com/photo-1496335506811-1e4380d47d18?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1350&q=80", 10, "Instamatic 133 Camera Kodak", 45f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "Inventory", "Name", "Price" },
                values: new object[] { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.", "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1289&q=80", 5, "Minimum design watch (white)", 60f });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Image", "Inventory", "Name", "Price" },
                values: new object[] { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi nisi urna, lacinia in lacinia in, suscipit a sem. Curabitur vitae elit quis tellus egestas porttitor porttitor mollis orci. Pellentesque euismod erat aliquam risus placerat maximus ac sit amet dolor. Praesent malesuada tellus id justo bibendum congue.", "https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=800&q=80", 4, "Quite simple sunglasses", 30f });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Addresses_AddressId",
                table: "Orders",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
