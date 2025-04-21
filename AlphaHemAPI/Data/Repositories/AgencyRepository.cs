using AlphaHemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class AgencyRepository : GenericRepository<Agency>, IAgencyRepository
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public AgencyRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }

        //Author: Mattias
        public async Task<Agency?> GetAsyncIncludeRealtor(int id)
        {
            return await _ctx.Agencies
                .Include(a => a.Realtors)
                .FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
