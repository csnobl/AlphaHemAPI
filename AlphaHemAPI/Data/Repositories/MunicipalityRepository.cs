using AlphaHemAPI.Data.Models;
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
    }
}
