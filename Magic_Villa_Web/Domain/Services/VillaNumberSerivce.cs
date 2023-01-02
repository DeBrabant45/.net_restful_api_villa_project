using Magic_Villa_Utility;
using Magic_Villa_Web.Domain.Models;
using Magic_Villa_Web.Domain.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Magic_Villa_Web.Domain.Services;

public class VillaNumberSerivce : BaseService, IVillaNumberService
{
    private string _villaUrl;

    public VillaNumberSerivce(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
    {
        _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

    public Task<T> CreateAsync<T>(VillaNumberCreateDTO createDTO)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.POST,
            HttpMethod = HttpMethod.Post,
            Data = createDTO,
            Url = _villaUrl + "/api/VillaNumberAPI"
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.DELETE,
            HttpMethod = HttpMethod.Delete,
            Url = _villaUrl + "/api/VillaNumberAPI/" + id,
        });
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.GET,
            HttpMethod = HttpMethod.Get,
            Url = _villaUrl + "/api/VillaNumberAPI"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.GET,
            HttpMethod = HttpMethod.Get,
            Url = _villaUrl + "/api/VillaNumberAPI/" + id,
        });
    }

    public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO updateDTO)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.PUT,
            HttpMethod = HttpMethod.Put,
            Data = updateDTO,
            Url = _villaUrl + "/api/VillaNumberAPI/" + updateDTO.Number,
        });
    }
}
