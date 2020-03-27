using System.Data.Entity;

namespace PlanetHunters.Data.Provider
{
    public class AstronomerRepo : Repository<Astronomer>
    {
        public AstronomerRepo(DbContext context) : base(context) { } 
    }
}
