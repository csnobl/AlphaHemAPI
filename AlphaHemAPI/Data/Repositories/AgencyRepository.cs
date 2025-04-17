using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class AgencyRepository : GenericRepository<Agency>
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public AgencyRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }
    }
}
