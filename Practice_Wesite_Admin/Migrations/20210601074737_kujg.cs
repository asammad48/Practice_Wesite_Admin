using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice_Wesite_Admin.Migrations
{
    public partial class kujg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubCategoryName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.SubCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "subSubCategories",
                columns: table => new
                {
                    SubSubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubsUBCategoryName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subSubCategories", x => x.SubSubCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "variants",
                columns: table => new
                {
                    VariantID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VariantName = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variants", x => x.VariantID);
                });

            migrationBuilder.CreateTable(
                name: "Category_subCategory",
                columns: table => new
                {
                    SubCategory_SubSubcategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryID = table.Column<int>(nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_subCategory", x => x.SubCategory_SubSubcategoryID);
                    table.ForeignKey(
                        name: "FK_Category_subCategory_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_subCategory_subCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "subCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SubSubCategoryID = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_products_subSubCategories_SubSubCategoryID",
                        column: x => x.SubSubCategoryID,
                        principalTable: "subSubCategories",
                        principalColumn: "SubSubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory_SubSubcategory",
                columns: table => new
                {
                    SubCategory_SubSubcategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SubSubCategoryID = table.Column<int>(nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory_SubSubcategory", x => x.SubCategory_SubSubcategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategory_SubSubcategory_subCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "subCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategory_SubSubcategory_subSubCategories_SubSubCategoryID",
                        column: x => x.SubSubCategoryID,
                        principalTable: "subSubCategories",
                        principalColumn: "SubSubCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_Variants",
                columns: table => new
                {
                    product_variant_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VariantID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    Var_Stock = table.Column<int>(nullable: false),
                    Var_Price = table.Column<decimal>(nullable: false),
                    Var_Discount = table.Column<decimal>(nullable: false),
                    Var_Reviews = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Variants", x => x.product_variant_ID);
                    table.ForeignKey(
                        name: "FK_product_Variants_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_Variants_variants_VariantID",
                        column: x => x.VariantID,
                        principalTable: "variants",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specifications",
                columns: table => new
                {
                    SpecID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    SpecName = table.Column<string>(nullable: true),
                    SpecValue = table.Column<string>(nullable: true),
                    VariantID = table.Column<int>(nullable: false),
                    top = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specifications", x => x.SpecID);
                    table.ForeignKey(
                        name: "FK_specifications_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_specifications_variants_VariantID",
                        column: x => x.VariantID,
                        principalTable: "variants",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_subCategory_CategoryID",
                table: "Category_subCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Category_subCategory_SubCategoryID",
                table: "Category_subCategory",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_product_Variants_ProductID",
                table: "product_Variants",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_product_Variants_VariantID",
                table: "product_Variants",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_products_SubSubCategoryID",
                table: "products",
                column: "SubSubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_specifications_ProductID",
                table: "specifications",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_specifications_VariantID",
                table: "specifications",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_SubSubcategory_SubCategoryID",
                table: "SubCategory_SubSubcategory",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_SubSubcategory_SubSubCategoryID",
                table: "SubCategory_SubSubcategory",
                column: "SubSubCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category_subCategory");

            migrationBuilder.DropTable(
                name: "product_Variants");

            migrationBuilder.DropTable(
                name: "specifications");

            migrationBuilder.DropTable(
                name: "SubCategory_SubSubcategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "variants");

            migrationBuilder.DropTable(
                name: "subCategories");

            migrationBuilder.DropTable(
                name: "subSubCategories");
        }
    }
}
