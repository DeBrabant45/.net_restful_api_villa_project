using Magic_Villa_VillaAPI.Models;

namespace Magic_Villa_VillaAPI.Repository;

public interface IVillaNumberRepository : IRepository<VillaNumber>
{
    public Task<VillaNumber> UpdateAsync(VillaNumber villaNumber);
}
