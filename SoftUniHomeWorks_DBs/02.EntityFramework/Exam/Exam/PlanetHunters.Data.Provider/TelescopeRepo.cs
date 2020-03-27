using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class TelescopeRepo : Repository<Telescope>
    {
        public TelescopeRepo(DbContext dataContext) : base(dataContext) { }
    }
}
