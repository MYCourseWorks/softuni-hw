using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class DiscoveryRepo : Repository<Discovery>
    {
        public DiscoveryRepo(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
