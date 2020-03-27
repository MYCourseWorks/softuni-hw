using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoMapping
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1 and 2 :");
            Task1();
            Console.WriteLine();
            Console.WriteLine("Task 3 :");
            Task2();
        }

        public static void Task1()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, ManagerDto>()
                    .ForMember(dto => dto.FirstName, dto => dto.MapFrom(src => src.FirstName))
                    .ForMember(dto => dto.LastName, dto => dto.MapFrom(src => src.LastName))
                    .ForMember(dto => dto.Employees, dto => dto.MapFrom(src => src.Employees))
                    .ForMember(dto => dto.EmployeeCount, dto => dto.MapFrom(src => src.Employees.Count));
            });

            EmployeeContext ctx = new EmployeeContext();
            var emps = ctx.Employees.ToList();
            var managerDtoCollction = Mapper.Map<List<Employee>, List<ManagerDto>>(emps).Where(x => x.EmployeeCount > 0);

            foreach (var manager in managerDtoCollction)
            {
                Console.WriteLine(manager);

                foreach (var em in manager.Employees)
                {
                    Console.WriteLine($"  -{em.FirstName} {em.LastName} {em.Salary}");
                }
            }
        }

        public static void Task2()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                    .ForMember(dto => dto.ManagerLastName, dto => dto.MapFrom(x => x.Manager.LastName));
            });

            EmployeeContext ctx = new EmployeeContext();
            var emps = ctx.Employees
                .Where(e => e.BirthDay.Year < 1990)
                .ProjectTo<EmployeeDto>()
                .ToList();

            foreach (var em in emps)
            {
                Console.WriteLine(em);
            }
        }
    }
}
