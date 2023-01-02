using Magic_Villa_Web.Domain.Models.DTO;

namespace Magic_Villa_Web.Domain.Services;

public interface IVillaNumberService
{
    public Task<T> GetAllAsync<T>();
    public Task<T> GetAsync<T>(int id);
    public Task<T> CreateAsync<T>(VillaNumberCreateDTO createDTO);
    public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO updateDTO);
    public Task<T> DeleteAsync<T>(int id);
}
