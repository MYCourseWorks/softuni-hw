using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class StarSystemRepo : Repository<StarSystem>
    {
        public StarSystemRepo(DbContext dataContext) : base(dataContext) { }
    }
}
