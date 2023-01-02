using Magic_Villa_Utility;
using Magic_Villa_Web.Domain.Models;
using Magic_Villa_Web.Domain.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Magic_Villa_Web.Domain.Services;

public class VillaSerivce : BaseService, IVillaService
{
    private string _villaUrl;

    public VillaSerivce(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
    {
        _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

    public Task<T> CreateAsync<T>(VillaCreateDTO createDTO)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.POST,
            HttpMethod = HttpMethod.Post,
            Data = createDTO,
            Url = _villaUrl + "/api/VillaAPI"
        });
    }

    public Task<T> DeleteAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.DELETE,
            HttpMethod = HttpMethod.Delete,
            Url = _villaUrl + "/api/VillaAPI/" + id,
        });
    }

    public Task<T> GetAllAsync<T>()
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.GET,
            HttpMethod = HttpMethod.Get,
            Url = _villaUrl + "/api/VillaAPI"
        });
    }

    public Task<T> GetAsync<T>(int id)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.GET,
            HttpMethod = HttpMethod.Get,
            Url = _villaUrl + "/api/VillaAPI/" + id,
        });
    }

    public Task<T> UpdateAsync<T>(VillaUpdateDTO updateDTO)
    {
        return SendAsync<T>(new APIRequest()
        {
            ApiType = StaticDetail.ApiType.PUT,
            HttpMethod = HttpMethod.Put,
            Data = updateDTO,
            Url = _villaUrl + "/api/VillaAPI/" + updateDTO.Id,
        });
    }
}
