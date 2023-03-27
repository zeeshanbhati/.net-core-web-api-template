using EFTemplate.Data;
using EFTemplate.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTemplate.Repository
{
    public class StationRepository
    {
        private readonly EFTemplateContext dbContext;

        public StationRepository(EFTemplateContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Station>> ListStations(int limit, int offset)
        {
            return await dbContext.Station.Take(limit).Skip(offset).ToListAsync();
        }

        public async Task<Guid> CreateStation(Station station)
        {
            dbContext.Station.Add(station);
            await dbContext.SaveChangesAsync();

            return station.StationId;

        }
    }
}
