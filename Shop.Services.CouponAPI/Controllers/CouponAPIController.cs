using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Services.CouponAPI.Data;
using Shop.Services.CouponAPI.Models;
using Shop.Services.CouponAPI.Models.DTO;

namespace Shop.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _autoMapper;
        private ResponseDTO _response;

        public CouponAPIController(AppDbContext db, IMapper autoMapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _autoMapper = autoMapper;
        }

        [HttpGet]
        public ResponseDTO GetAll()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO GetById(int id)
        {
            try
            {
                Coupon ent = _db.Coupons.First(c => c.CouponId == id);
                _response.Result = _autoMapper.Map<CouponDTO>(ent);

                // Alternative to mapper that will not be used:
                //_response.Result = new CouponDTO().FromEntity(obj);
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon ent = _db.Coupons.First(c => c.CouponCode.ToLower() == code.ToLower());
                _response.Result = _autoMapper.Map<CouponDTO>(ent);
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public ResponseDTO Create([FromBody] CouponDTO dto)
        {
            try
            {
                Coupon ent = _autoMapper.Map<Coupon>(dto);
                _db.Coupons.Add(ent);
                _db.SaveChanges();
                _response.Result = _autoMapper.Map<CouponDTO>(ent);
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPut]
        public ResponseDTO Update([FromBody] CouponDTO dto)
        {
            try
            {
                // Not needed. The mapper and update method do all this:
                //Coupon ent = _db.Coupons.First(c => c.CouponId == dto.CouponId);

                //ent.CouponCode = dto.CouponCode;
                //ent.DiscountAmount = dto.DiscountAmount;
                //ent.MinAmount = dto.MinAmount;

                Coupon ent = _autoMapper.Map<Coupon>(dto);
                _db.Coupons.Update(ent);
                _db.SaveChanges();
                _response.Result = _autoMapper.Map<CouponDTO>(ent);
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;

        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDTO DeleteById(int id)
        {
            try
            {
                Coupon ent = _db.Coupons.First(c => c.CouponId == id);
                _db.Coupons.Remove(ent);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsGreatSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
