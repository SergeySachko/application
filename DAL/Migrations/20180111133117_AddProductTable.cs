using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class AddProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Height = table.Column<double>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    Length = table.Column<double>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    RegularPrice = table.Column<double>(nullable: false),
                    SalePrice = table.Column<double>(nullable: false),
                    SalePriceDateFrom = table.Column<DateTime>(nullable: true),
                    SalePriceDateTo = table.Column<DateTime>(nullable: true),
                    StrockStatus = table.Column<byte>(nullable: false),
                    Weight = table.Column<double>(nullable: true),
                    Width = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
