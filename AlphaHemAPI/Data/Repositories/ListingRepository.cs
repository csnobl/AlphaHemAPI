using AlphaHemAPI.Data.Models;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class ListingRepository : GenericRepository<Listing>
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public ListingRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }
    }
}
