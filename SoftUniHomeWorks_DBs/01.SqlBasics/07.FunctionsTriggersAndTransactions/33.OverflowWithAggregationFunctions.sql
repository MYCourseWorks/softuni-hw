select 
	CON.ContinentName, sum(COU.AreaInSqKm) as CountriesArea, 
	sum(convert(bigint, COU.Population)) as CountriesPopulation
from 
	Countries as COU
	join Continents as CON on CON.ContinentCode = COU.ContinentCode
group by
	CON.ContinentName
order by 
	CountriesPopulation desc