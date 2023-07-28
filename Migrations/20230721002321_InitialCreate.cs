using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veterinaria.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TNXT");

            migrationBuilder.EnsureSchema(
                name: "Master");

            migrationBuilder.EnsureSchema(
                name: "Pyment");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Method",
                schema: "Pyment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo_tarjeta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Efectivo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Method", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre_Punto_venta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address_Customer",
                schema: "TNXT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Master_customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Customer_Customer_Master_customerId",
                        column: x => x.Master_customerId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetsCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Mascota = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Edad = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    Master_customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetsCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetsCustomer_Customer_Master_customerId",
                        column: x => x.Master_customerId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trade_transaction",
                schema: "TNXT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Payment_MethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade_transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trade_transaction_Method_Payment_MethodId",
                        column: x => x.Payment_MethodId,
                        principalSchema: "Pyment",
                        principalTable: "Method",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Doctor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Especialidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Master",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "Master",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Producto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                    table.ForeignKey(
                        name: "FK_Product_Store_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "Master",
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_cita = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    Master_customerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Date_Customer_Master_customerId",
                        column: x => x.Master_customerId,
                        principalSchema: "Master",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Date_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalSchema: "Master",
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_order",
                schema: "TNXT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Master_productId = table.Column<int>(type: "int", nullable: false),
                    Address_CustomerId = table.Column<int>(type: "int", nullable: false),
                    Trade_transactionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_order_Address_Customer_Address_CustomerId",
                        column: x => x.Address_CustomerId,
                        principalSchema: "TNXT",
                        principalTable: "Address_Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_order_Product_Master_productId",
                        column: x => x.Master_productId,
                        principalSchema: "Master",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_order_Trade_transaction_Master_productId",
                        column: x => x.Master_productId,
                        principalSchema: "TNXT",
                        principalTable: "Trade_transaction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "Master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_proveedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Master_productId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Product_Master_productId",
                        column: x => x.Master_productId,
                        principalSchema: "Master",
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address_Supplier",
                schema: "TNXT",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Master_supplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Supplier_Supplier_Master_supplierId",
                        column: x => x.Master_supplierId,
                        principalSchema: "Master",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Customer_Master_customerId",
                schema: "TNXT",
                table: "Address_Customer",
                column: "Master_customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_Supplier_Master_supplierId",
                schema: "TNXT",
                table: "Address_Supplier",
                column: "Master_supplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Date_DoctorsId",
                schema: "Master",
                table: "Date",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Date_Master_customerId",
                schema: "Master",
                table: "Date",
                column: "Master_customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_StoreId",
                schema: "Master",
                table: "Doctors",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_PetsCustomer_Master_customerId",
                table: "PetsCustomer",
                column: "Master_customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StoreId",
                schema: "Master",
                table: "Product",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_order_Address_CustomerId",
                schema: "TNXT",
                table: "Purchase_order",
                column: "Address_CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_order_Master_productId",
                schema: "TNXT",
                table: "Purchase_order",
                column: "Master_productId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Master_productId",
                schema: "Master",
                table: "Supplier",
                column: "Master_productId");

            migrationBuilder.CreateIndex(
                name: "IX_Trade_transaction_Payment_MethodId",
                schema: "TNXT",
                table: "Trade_transaction",
                column: "Payment_MethodId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_Supplier",
                schema: "TNXT");

            migrationBuilder.DropTable(
                name: "Date",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "PetsCustomer");

            migrationBuilder.DropTable(
                name: "Purchase_order",
                schema: "TNXT");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Doctors",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Address_Customer",
                schema: "TNXT");

            migrationBuilder.DropTable(
                name: "Trade_transaction",
                schema: "TNXT");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Master");

            migrationBuilder.DropTable(
                name: "Method",
                schema: "Pyment");

            migrationBuilder.DropTable(
                name: "Store",
                schema: "Master");
        }
    }
}
