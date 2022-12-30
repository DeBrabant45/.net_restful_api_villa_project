using Magic_Villa_VillaAPI.Models;

namespace Magic_Villa_VillaAPI.Repository;

public interface IVillaRepository : IRepository<Villa>
{
    public Task<Villa> UpdateAsync(Villa villa);
}
