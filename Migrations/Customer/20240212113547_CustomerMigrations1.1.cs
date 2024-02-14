using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.Migrations.Customer
{
    /// <inheritdoc />
    public partial class CustomerMigrations11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    address_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.address_id);
                });

            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    address_type_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address_type_description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.address_type_code);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PayMethodDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodCode);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<int>(type: "int", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OtherPaymentDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBecameCustomer = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customer_PaymentMethods_PaymentMethodCode",
                        column: x => x.PaymentMethodCode,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAddresses",
                columns: table => new
                {
                    customerId = table.Column<int>(type: "int", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false),
                    date_from = table.Column<TimeSpan>(type: "time", nullable: false),
                    address_type_code = table.Column<int>(type: "int", nullable: false),
                    date_to = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddresses", x => new { x.date_from, x.customerId, x.address_id });
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_AddressTypes_address_type_code",
                        column: x => x.address_type_code,
                        principalTable: "AddressTypes",
                        principalColumn: "address_type_code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Address_address_id",
                        column: x => x.address_id,
                        principalTable: "Address",
                        principalColumn: "address_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAddresses_Customer_customerId",
                        column: x => x.customerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PaymentMethodCode",
                table: "Customer",
                column: "PaymentMethodCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_address_id",
                table: "CustomerAddresses",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_address_type_code",
                table: "CustomerAddresses",
                column: "address_type_code");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_customerId",
                table: "CustomerAddresses",
                column: "customerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAddresses");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
