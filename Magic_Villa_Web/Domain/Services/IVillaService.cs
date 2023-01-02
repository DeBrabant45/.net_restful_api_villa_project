using Magic_Villa_Web.Domain.Models.DTO;

namespace Magic_Villa_Web.Domain.Services;

public interface IVillaService
{
    public Task<T> GetAllAsync<T>();
    public Task<T> GetAsync<T>(int id);
    public Task<T> CreateAsync<T>(VillaCreateDTO createDTO);
    public Task<T> UpdateAsync<T>(VillaUpdateDTO updateDTO);
    public Task<T> DeleteAsync<T>(int id);
}
