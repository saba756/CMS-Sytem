using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class foriegn_key_payment_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpaymethodcode",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "paymethodcode",
                table: "PaymentMethods",
                newName: "payment_method_code");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodpaymethodcode",
                table: "Customer",
                newName: "PaymentMethodpayment_method_code");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_PaymentMethodpaymethodcode",
                table: "Customer",
                newName: "IX_Customer_PaymentMethodpayment_method_code");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpayment_method_code",
                table: "Customer",
                column: "PaymentMethodpayment_method_code",
                principalTable: "PaymentMethods",
                principalColumn: "payment_method_code");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpayment_method_code",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "payment_method_code",
                table: "PaymentMethods",
                newName: "paymethodcode");

            migrationBuilder.RenameColumn(
                name: "PaymentMethodpayment_method_code",
                table: "Customer",
                newName: "PaymentMethodpaymethodcode");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_PaymentMethodpayment_method_code",
                table: "Customer",
                newName: "IX_Customer_PaymentMethodpaymethodcode");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_PaymentMethods_PaymentMethodpaymethodcode",
                table: "Customer",
                column: "PaymentMethodpaymethodcode",
                principalTable: "PaymentMethods",
                principalColumn: "paymethodcode");
        }
    }
}
