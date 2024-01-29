using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations
{
    /// <inheritdoc />
    public partial class payment_foriegn_key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    customer_phone = table.Column<int>(type: "int", maxLength: 250, nullable: false),
                    customer_email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    payment_detail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    payment_method_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    other_payment_detail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    date_became_customer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customerId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    paymethodcode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pay_method_description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.paymethodcode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
