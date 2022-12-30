using Magic_Villa_VillaAPI.Data;
using Magic_Villa_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Magic_Villa_VillaAPI.Repository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    private readonly AppDBContext _context;

    public VillaRepository(AppDBContext context):base(context)
    {
        _context = context;
    }


    public async Task<Villa> UpdateAsync(Villa villa)
    {
        villa.UpdatedDate = DateTime.Now;
        _context.Villas.Update(villa);
        await SaveChangesAsync();
        return villa;
    }
}
