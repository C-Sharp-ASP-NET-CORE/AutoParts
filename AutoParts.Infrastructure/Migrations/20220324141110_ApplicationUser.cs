using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoParts.Infrastructure.Migrations
{
    public partial class ApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Contragents_ContragentId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Categories_CategoryId",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DealsSubjects",
                table: "DealsSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DealsSubjects_DealId",
                table: "DealsSubjects");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Parts",
                type: "decimal(12,10)",
                precision: 12,
                scale: 10,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DealsSubjects",
                table: "DealsSubjects",
                columns: new[] { "DealId", "PartId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contragents_CustomerNumber",
                table: "Contragents",
                column: "CustomerNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Contragents_ContragentId",
                table: "Deals",
                column: "ContragentId",
                principalTable: "Contragents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Categories_CategoryId",
                table: "Parts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Contragents_ContragentId",
                table: "Deals");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Categories_CategoryId",
                table: "Parts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DealsSubjects",
                table: "DealsSubjects");

            migrationBuilder.DropIndex(
                name: "IX_Contragents_CustomerNumber",
                table: "Contragents");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Parts",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,10)",
                oldPrecision: 12,
                oldScale: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DealsSubjects",
                table: "DealsSubjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DealsSubjects_DealId",
                table: "DealsSubjects",
                column: "DealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Contragents_ContragentId",
                table: "Deals",
                column: "ContragentId",
                principalTable: "Contragents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Categories_CategoryId",
                table: "Parts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
