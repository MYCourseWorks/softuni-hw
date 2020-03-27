using AutoMapper;
using PlanetHunter.DTO;
using PlanetHunters.Data;
using PlanetHunters.Data.Provider;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PlanetHuner.Import
{
    public class PLDeserializer
    {
        private static readonly IDictionary<Type, string> supportedTypes = new Dictionary<Type, string>
        {
            { typeof(Astronomer), typeof(Astronomer).Name.ToLower() },
            { typeof(Planet), typeof(Planet).Name.ToLower() },
            { typeof(Telescope), typeof(Telescope).Name.ToLower() },
            { typeof(Star), typeof(Star).Name.ToLower() },
            { typeof(Discovery), typeof(Discovery).Name.ToLower() }
        };

        public StringBuilder DebugLog { get; private set; }

        public PLDeserializer()
        {
            this.DebugLog = new StringBuilder();
        }

        public void InportData<T>()
        {
            this.ClearLog();
            string typeName = typeof(T).Name.ToLower();

            if (typeName == supportedTypes[typeof(Astronomer)])
                DeserializeAstronomers();
            else if (typeName == supportedTypes[typeof(Planet)])
                DeserializePlanets();
            else if (typeName == supportedTypes[typeof(Telescope)])
                DeserializeTelescopes();
            else if (typeName == supportedTypes[typeof(Star)])
                DeserializeStars();
            else if (typeName == supportedTypes[typeof(Discovery)])
                DeserializeDiscoveries();
            else
                throw new InvalidOperationException();
        }

        public void ClearLog()
        {
            this.DebugLog.Clear();
        }

        private void DeserializeAstronomers()
        {
            var astronomerDtos = JsonFileOperations.DeserializeJsonCollection<AstronomerDto>(Constants.AstronomerJsonFile);
            using (PlanetHuntersContext ctx = new PlanetHuntersContext())
            {
                AstronomerRepo repo = new AstronomerRepo(ctx);

                foreach (var dto in astronomerDtos)
                {
                    if (dto.FirstName != null && dto.LastName != null)
                    {
                        var a = new Astronomer();
                        Mapper.Map(dto, a);
                        repo.Insert(a);
                        this.DebugLog.AppendLine($"Record {dto.FirstName} {dto.LastName} successfully imported.");
                    }
                    else
                    {
                        this.DebugLog.AppendLine(Constants.InvalidDataFormat);
                    }
                }

                DbUtil.ExecTransaction(ctx);
            }
        }

        private void DeserializePlanets()
        {
            var planetDtos = JsonFileOperations.DeserializeJsonCollection<PlanetDto>(Constants.PlanetJsonFile);
            using (PlanetHuntersContext ctx = new PlanetHuntersContext())
            {
                StarSystemRepo stRepo = new StarSystemRepo(ctx);
                PlanetRepo plRepo = new PlanetRepo(ctx);

                foreach (var dto in planetDtos)
                {
                    if (dto.Mass > 0 && dto.Name != null && dto.StarSystem != null)
                    {
                        var planet = new Planet();
                        Mapper.Map(dto, planet);

                        var starSystem = stRepo.SearchFor(s => s.Name == dto.StarSystem).FirstOrDefault();

                        if (starSystem == null)
                            starSystem = new StarSystem() { Name = dto.StarSystem };

                        starSystem.Planets.Add(planet);
                        planet.HostStarSystem = starSystem;

                        plRepo.Insert(planet);
                        ctx.SaveChanges();

                        this.DebugLog.AppendLine($"Record {dto.Name} successfully imported.");
                    } else
                    {
                        this.DebugLog.AppendLine(Constants.InvalidDataFormat);
                    }
                }
            }
        }

        private void DeserializeTelescopes()
        {
            var telescopeDtos = JsonFileOperations.DeserializeJsonCollection<TelescopeDto>(Constants.TelescopeJsonFile);

            using (PlanetHuntersContext ctx = new PlanetHuntersContext())
            {
                TelescopeRepo repo = new TelescopeRepo(ctx);

                foreach (var dto in telescopeDtos)
                {
                    if (dto.Name != null && dto.Location != null)
                    {
                        if (dto.MirrorDiameter != null && dto.MirrorDiameter <= 0)
                            continue;

                        var t = new Telescope();
                        Mapper.Map(dto, t);
                        repo.Insert(t);
                        this.DebugLog.AppendLine($"Record {dto.Name} successfully imported.");
                    }
                    else
                    {
                        this.DebugLog.AppendLine(Constants.InvalidDataFormat);
                    }
                }

                DbUtil.ExecTransaction(ctx);
            }
        }

        private void DeserializeStars()
        {
            var xmlDocument = XDocument.Load(Constants.StarXmlFile).Root.Elements();

            using (PlanetHuntersContext ctx = new PlanetHuntersContext())
            {
                StarSystemRepo syRepo = new StarSystemRepo(ctx);
                StarRepo stRepo = new StarRepo(ctx);

                foreach (var starElem in xmlDocument)
                {
                    StringReader reader = new StringReader(starElem.ToString());
                    XmlSerializer serializer = new XmlSerializer(typeof(StarDto));
                    var starDto = (StarDto)serializer.Deserialize(reader);
                    
                    if (starDto.Temperature > 2400 && starDto.Name != null && starDto.StarSystem != null)
                    {
                        var starSystem = syRepo.SearchFor(s => s.Name == starDto.StarSystem).FirstOrDefault();
                        if (starSystem == null)
                            starSystem = new StarSystem() { Name = starDto.StarSystem };

                        var star = new Star();
                        Mapper.Map(starDto, star);
                        star.HostStarSystem = starSystem;

                        stRepo.Insert(star);
                        ctx.SaveChanges();

                        this.DebugLog.AppendLine($"Record {star.Name} successfully imported.");
                    }
                    else
                    {
                        this.DebugLog.AppendLine(Constants.InvalidDataFormat);
                    }
                }
            }

        }

        private void DeserializeDiscoveries()
        {
            var xmlDocument = XDocument.Load(Constants.DiscoveryXmlFile).Root.Elements();
            using (PlanetHuntersContext ctx = new PlanetHuntersContext())
            {
                var starRepo = new StarRepo(ctx);
                var discoveryRepo = new DiscoveryRepo(ctx);
                var planetRepo = new PlanetRepo(ctx);
                var telescopeRepo = new TelescopeRepo(ctx);
                var astronomerRepo = new AstronomerRepo(ctx);

                foreach (var discoveryElem in xmlDocument)
                {
                    bool errorFlag = false;
                    var discovery = new Discovery();

                    DateTime date = DateTime.Parse(discoveryElem.Attribute("DateMade").Value);
                    string telescopeName = discoveryElem.Attribute("Telescope").Value;

                    discovery.DateMade = date;

                    var telescope = telescopeRepo.SearchFor(t => t.Name == telescopeName).FirstOrDefault();
                    if (telescope == null)
                        errorFlag = true;
                    else
                        discovery.Telescope = telescope;

                    var starsElement = discoveryElem.Elements("Stars");
                    if (starsElement.Elements().Any())
                    {
                        foreach (var sElem in starsElement)
                        {
                            string starName = sElem.Value;
                            var star = starRepo.SearchFor(s => s.Name == starName).FirstOrDefault();

                            if (star == null)
                            {
                                errorFlag = true;
                                break;
                            }

                            discovery.Stars.Add(star);
                        }
                    }

                    var planetsElement = discoveryElem.Elements("Planets");
                    if (planetsElement.Elements().Any())
                    {
                        foreach (var pElem in planetsElement)
                        {
                            string planetName = pElem.Value;
                            var planet = planetRepo.SearchFor(p => p.Name == planetName).FirstOrDefault();

                            if (planet == null)
                            {
                                errorFlag = true;
                                break;
                            }

                            discovery.Planets.Add(planet);
                        }
                    }
                    
                    var pioneerElement = discoveryElem.Elements("Pioneers").Elements();
                    if (pioneerElement.Any())
                    {
                        foreach (var pElem in pioneerElement)
                        {
                            string[] pName = pElem.Value.Split(',');
                            string firstName = pName[0].Trim();
                            string lastName = pName[1].Trim();

                            var pioneer = astronomerRepo
                                .GetAll()
                                .Where(p => p.FirstName.Equals(firstName) && p.LastName.Equals(lastName))
                                .FirstOrDefault();

                            if (pioneer == null)
                            {
                                errorFlag = true;
                                break;
                            }

                            discovery.Pioneers.Add(pioneer);
                        }
                    }

                    var observersElement = discoveryElem.Elements("Observers");
                    if (observersElement.Elements().Any())
                    {
                        foreach (var oElem in observersElement)
                        {
                            string[] oName = oElem.Value.Split(',');
                            string firstName = oName[0].Trim();
                            string lastName = oName[1].Trim();

                            var observer = astronomerRepo
                                .SearchFor(p => p.FirstName == firstName && p.LastName == lastName)
                                .FirstOrDefault();

                            if (observer == null)
                            {
                                errorFlag = true;
                                break;
                            }

                            discovery.Observers.Add(observer);
                        }
                    }

                    if (errorFlag == false)
                    {
                        discoveryRepo.Insert(discovery);
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}
