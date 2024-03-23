using Shop.Web.Models;
using Shop.Web.Models.DTO;

namespace Shop.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDTO> GetCouponByIdAsync(int id);
        Task<ResponseDTO> GetCouponByCodeAsync(string couponCode);
        Task<ResponseDTO> GetAllCouponsAsync();
        Task<ResponseDTO> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDTO> DeleteCouponAsync(int id);
    }
}
