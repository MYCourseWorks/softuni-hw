using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class StarRepo : Repository<Star>
    {
        public StarRepo(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
