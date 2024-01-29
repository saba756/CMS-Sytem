using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class foriegn_key_payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodpaymethodcode",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentMethodpaymethodcode",
                table: "Customer",
                column: "PaymentMethodpaymethodcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpaymethodcode",
                table: "Customer",
                column: "PaymentMethodpaymethodcode",
                principalTable: "PaymentMethods",
                principalColumn: "paymethodcode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpaymethodcode",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PaymentMethodpaymethodcode",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PaymentMethodpaymethodcode",
                table: "Customer");
        }
    }
}
