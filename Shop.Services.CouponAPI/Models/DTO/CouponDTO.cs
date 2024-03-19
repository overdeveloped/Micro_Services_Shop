namespace Shop.Services.CouponAPI.Models.DTO
{
    // DTO
    public class CouponDTO
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }

        public CouponDTO FromEntity(Coupon coupon)
        {
            this.CouponId = coupon.CouponId; ;
            this.CouponCode = coupon.CouponCode;
            this.DiscountAmount = coupon.DiscountAmount;
            this.MinAmount = coupon.MinAmount;
            return this;
        }

    }
}
