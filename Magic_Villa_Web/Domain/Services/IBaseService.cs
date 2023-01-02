using Magic_Villa_Web.Domain.Models;
using Magic_Villa_Web.Domain.Models.DTO;

namespace Magic_Villa_Web.Domain.Services;

public interface IBaseService
{
    public APIResponse Response { get; set; }
    public Task<T> SendAsync<T>(APIRequest response);
}
