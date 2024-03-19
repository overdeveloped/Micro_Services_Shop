using Newtonsoft.Json;
using Shop.Web.Models;
using Shop.Web.Service.IService;
using System.Net.Http;
using System.Text;
using Shop.Web.Utility;
using System.Net;

namespace Shop.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDTO?> SendAsync(RequestDTO requestDTO)
        {
            HttpClient client = _httpClientFactory.CreateClient("ShopAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            // TODO: TOKEN
            message.RequestUri = new Uri(requestDTO.Url);
            // Check for body:
            if (requestDTO.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? apiResponse = null;

            try
            {
                switch (requestDTO.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsGreatSuccess = false, Message = "404, not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsGreatSuccess = false, Message = "403, forbidden" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsGreatSuccess = false, Message = "401, unauthorised" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsGreatSuccess = false, Message = "500, server error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDto;
                }

            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO()
                {
                    Message = ex.Message.ToString(),
                    IsGreatSuccess = false
                };

                return dto;
            }
        }
    }
}
