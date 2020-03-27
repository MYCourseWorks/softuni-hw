using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class PlanetRepo : Repository<Planet>
    {
        public PlanetRepo(DbContext dataContext) : base(dataContext) { }
    }
}
