using Magic_Villa_VillaAPI.Data;
using Magic_Villa_VillaAPI.Models;

namespace Magic_Villa_VillaAPI.Repository;

public class VillaNumberRespository : Repository<VillaNumber>, IVillaNumberRepository
{
    private readonly AppDBContext _context;

    public VillaNumberRespository(AppDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<VillaNumber> UpdateAsync(VillaNumber villaNumber)
    {
        villaNumber.UpdatedDate = DateTime.Now;
        _context.VillaNumbers.Update(villaNumber);
        await SaveChangesAsync();
        return villaNumber;
    }
}
