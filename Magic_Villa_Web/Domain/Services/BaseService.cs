using Magic_Villa_Web.Domain.Models;
using Magic_Villa_Web.Domain.Models.DTO;
using Newtonsoft.Json;
using System.Text;

namespace Magic_Villa_Web.Domain.Services;

public class BaseService : IBaseService
{
    public IHttpClientFactory HttpClient { get; set; }
    public APIResponse Response { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        HttpClient = httpClient;
        Response = new();
    }

    public async Task<T> SendAsync<T>(APIRequest request)
    {
        try
        {
            var client = HttpClient.CreateClient("MagicAPI");
            var message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(request.Url);
            if (request.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(request.Data), Encoding.UTF8, "application/json");
            }

            message.Method = request.HttpMethod;
            var apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(apiContent);
        }
        catch (Exception ex)
        {
            var dto = new APIResponse
            {
                ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                IsSuccess = false
            };
            var result = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
