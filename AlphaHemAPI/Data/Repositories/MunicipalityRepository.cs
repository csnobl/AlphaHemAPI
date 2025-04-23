using AlphaHemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class MunicipalityRepository : GenericRepository<Municipality>
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public MunicipalityRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }

        //Author: Christoffer
        public async Task<IEnumerable<Municipality>> GetAllAsync()
        {
            return await _ctx.Municipalities
                .ToListAsync();
        }
    }
}
