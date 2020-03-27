using AutoMapper;
using PlanetHuner.Import;
using PlanetHunter.DTO;
using PlanetHunters.Data;
using System;

namespace PlanetHunters.App
{
    public class Engine
    {
        public void Run()
        {
            MapperInit();

            var plDeserializer = new PLDeserializer();

            plDeserializer.InportData<Astronomer>();
#if DEBUG
            Console.WriteLine("Astronomer Import :");
            Console.WriteLine(plDeserializer.DebugLog.ToString());
#endif
            plDeserializer.InportData<Planet>();
#if DEBUG
            Console.WriteLine("Planet Import :");
            Console.WriteLine(plDeserializer.DebugLog.ToString());
#endif

            plDeserializer.InportData<Telescope>();
#if DEBUG
            Console.WriteLine("Telescope Import :");
            Console.WriteLine(plDeserializer.DebugLog.ToString());
#endif

            plDeserializer.InportData<Star>();
#if DEBUG
            Console.WriteLine("Star Import :");
            Console.WriteLine(plDeserializer.DebugLog.ToString());
#endif

            plDeserializer.InportData<Discovery>();
        }

        private static void MapperInit()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AstronomerDto, Astronomer>()
                    .ForMember(dto => dto.FirstName, dto => dto.MapFrom(src => src.FirstName))
                    .ForMember(dto => dto.LastName, dto => dto.MapFrom(src => src.LastName));
                cfg.CreateMap<PlanetDto, Planet>()
                    .ForMember(dto => dto.Name, dto => dto.MapFrom(src => src.Name))
                    .ForMember(dto => dto.Mass, dto => dto.MapFrom(src => src.Mass));
                cfg.CreateMap<StarDto, Star>()
                    .ForMember(dto => dto.Name, dto => dto.MapFrom(src => src.Name))
                    .ForMember(dto => dto.Temperature, dto => dto.MapFrom(src => src.Temperature));
                cfg.CreateMap<TelescopeDto, Telescope>()
                    .ForMember(dto => dto.Name, dto => dto.MapFrom(src => src.Name))
                    .ForMember(dto => dto.Location, dto => dto.MapFrom(src => src.Location))
                    .ForMember(dto => dto.MirrorDiameter, dto => dto.MapFrom(src => src.MirrorDiameter));
            });
        }
    }
}
