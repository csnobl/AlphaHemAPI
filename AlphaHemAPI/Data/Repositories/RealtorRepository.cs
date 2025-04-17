using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class RealtorRepository : GenericRepository<Realtor>
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public RealtorRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }
    }
}
