namespace Shop.Services.CouponAPI.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool IsGreatSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
