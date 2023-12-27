using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WaterBill.DAL.Data.Migrations
{
    public partial class initalCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NWC_Default_Slice_Values",
                columns: table => new
                {
                    NWC_Default_Slice_Values_Code = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    NWC_Default_Slice_Values_Name = table.Column<string>(type: "nvarchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NWC_Default_Slice_Values_Condtion = table.Column<int>(type: "int", nullable: false),
                    NWC_Default_Slice_Values_Water_Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    NWC_Default_Slice_Values_Sanitation_Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    NWC_Default_Slice_Values_Reasons = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Default_Slice_Values", x => x.NWC_Default_Slice_Values_Code);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Rreal_Estate_Types",
                columns: table => new
                {
                    NWC_Rreal_Estate_Types_Code = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    NWC_Rreal_Estate_Types_Name = table.Column<string>(type: "nvarchar(15)", unicode: false, maxLength: 15, nullable: false),
                    NWC_Rreal_Estate_Types_Reasons = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Rreal_Estate_Types", x => x.NWC_Rreal_Estate_Types_Code);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscriber_File",
                columns: table => new
                {
                    NWC_Subscriber_File_Id = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    NWC_Subscriber_File_Name = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NWC_Subscriber_File_City = table.Column<string>(type: "nvarchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NWC_Subscriber_File_Area = table.Column<string>(type: "nvarchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NWC_Subscriber_File_Mobile = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    NWC_Subscriber_File_Reasons = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscriber_File", x => x.NWC_Subscriber_File_Id);
                });

            migrationBuilder.CreateTable(
                name: "NWC_Subscription_File",
                columns: table => new
                {
                    NWC_Subscriber_File_Id = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    NWC_Subscription_File_Unit_No = table.Column<int>(type: "int", nullable: false),
                    NWC_Subscription_File_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    NWC_Subscription_File_Last_Reading_Meter = table.Column<int>(type: "int", nullable: false),
                    NWC_Subscription_File_Reasons = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NWC_Subscription_File_Rreal_Estate_Types_Code = table.Column<string>(type: "char(1)", nullable: false),
                    NWC_Subscription_File_Subscriber_Code = table.Column<string>(type: "char(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Subscription_File", x => x.NWC_Subscriber_File_Id);
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_File_NWC_Rreal_Estate_Types",
                        column: x => x.NWC_Subscription_File_Rreal_Estate_Types_Code,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "NWC_Rreal_Estate_Types_Code");
                    table.ForeignKey(
                        name: "FK_NWC_Subscription_File_NWC_Subscriber_File",
                        column: x => x.NWC_Subscription_File_Subscriber_Code,
                        principalTable: "NWC_Subscriber_File",
                        principalColumn: "NWC_Subscriber_File_Id");
                });

            migrationBuilder.CreateTable(
                name: "NWC_Invoices",
                columns: table => new
                {
                    NWC_Invoices_No = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    NWC_Invoices_Year = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    NWC_Invoices_Rreal_Estate_Types = table.Column<string>(type: "char(1)", nullable: false),
                    NWC_Invoices_Subscription_No = table.Column<string>(type: "char(10)", nullable: false),
                    NWC_Invoices_Subscriber_No = table.Column<string>(type: "char(10)", nullable: false),
                    NWC_Invoices_Date = table.Column<DateTime>(type: "date", nullable: false),
                    NWC_Invoices_From = table.Column<DateTime>(type: "date", nullable: false),
                    NWC_Invoices_To = table.Column<DateTime>(type: "date", nullable: false),
                    NWC_Invoices_Previous_Consumption_Amount = table.Column<int>(type: "int", nullable: false),
                    NWC_Invoices_Current_Consumption_Amount = table.Column<int>(type: "int", nullable: false),
                    NWC_Invoices_Amount_Consumption = table.Column<int>(type: "int", nullable: false),
                    NWC_Invoices_Service_Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Tax_Rate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    NWC_Invoices_Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Wastewater_Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Total_Invoice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Tax_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Total_Bill = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NWC_Invoices_Total_Reasons = table.Column<string>(type: "nvarchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NWC_Invoices", x => x.NWC_Invoices_No);
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Rreal_Estate_Types_NWC_Invoices_Rreal_Estate_Types",
                        column: x => x.NWC_Invoices_Rreal_Estate_Types,
                        principalTable: "NWC_Rreal_Estate_Types",
                        principalColumn: "NWC_Rreal_Estate_Types_Code");
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscriber_File_NWC_Invoices_Subscriber_No",
                        column: x => x.NWC_Invoices_Subscriber_No,
                        principalTable: "NWC_Subscriber_File",
                        principalColumn: "NWC_Subscriber_File_Id");
                    table.ForeignKey(
                        name: "FK_NWC_Invoices_NWC_Subscription_File_NWC_Invoices_Subscription_No",
                        column: x => x.NWC_Invoices_Subscription_No,
                        principalTable: "NWC_Subscription_File",
                        principalColumn: "NWC_Subscriber_File_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Rreal_Estate_Types",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Rreal_Estate_Types");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Subscriber_No",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Subscriber_No");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Invoices_NWC_Invoices_Subscription_No",
                table: "NWC_Invoices",
                column: "NWC_Invoices_Subscription_No");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_File_NWC_Subscription_File_Rreal_Estate_Types_Code",
                table: "NWC_Subscription_File",
                column: "NWC_Subscription_File_Rreal_Estate_Types_Code");

            migrationBuilder.CreateIndex(
                name: "IX_NWC_Subscription_File_NWC_Subscription_File_Subscriber_Code",
                table: "NWC_Subscription_File",
                column: "NWC_Subscription_File_Subscriber_Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NWC_Default_Slice_Values");

            migrationBuilder.DropTable(
                name: "NWC_Invoices");

            migrationBuilder.DropTable(
                name: "NWC_Subscription_File");

            migrationBuilder.DropTable(
                name: "NWC_Rreal_Estate_Types");

            migrationBuilder.DropTable(
                name: "NWC_Subscriber_File");
        }
    }
}
