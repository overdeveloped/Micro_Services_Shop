using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectCouponModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountAmouht",
                table: "Coupons",
                newName: "DiscountAmount");

            migrationBuilder.RenameColumn(
                name: "CouponDiscount",
                table: "Coupons",
                newName: "CouponCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Coupons",
                newName: "DiscountAmouht");

            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Coupons",
                newName: "CouponDiscount");
        }
    }
}
