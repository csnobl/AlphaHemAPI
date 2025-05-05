using AlphaHemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AlphaHemAPI.Data.Repositories
{
    //Author : ALL
    public class RealtorRepository : GenericRepository<Realtor>, IRealtorRepository
    {
        private readonly AlphaHemAPIDbContext _ctx;

        public RealtorRepository(AlphaHemAPIDbContext ctx) :base(ctx)
        {
            this._ctx = ctx;
        }

        // Author : Niklas
        public async Task<Realtor?> GetByEmailAsync(string email)
        {
            return await _ctx.Realtors.FirstOrDefaultAsync(e => e.Email == email);
        }

        //Author : Dominika
        public async Task<List<Realtor>> GetAllWithAgencyAsync()
        {
            return await _ctx.Realtors
                .Include(r => r.Agency)
                .ToListAsync();
        }

        //Author : Smilla
        public async Task<Realtor?> GetByIdWithAgencyAsync(string id)
        {
            return await _ctx.Realtors
                .Include(r => r.Agency)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Realtor?> GetAsync(string id)
        {
            return await _ctx.Realtors.FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
