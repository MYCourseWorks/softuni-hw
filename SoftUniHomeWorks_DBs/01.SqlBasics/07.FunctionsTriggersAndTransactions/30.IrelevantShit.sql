select 
	P.PeakName, M.MountainRange as Mountain, C.CountryName, CON.ContinentName
from 
	Countries as C
	join Continents as CON on CON.ContinentCode = C.ContinentCode
	join MountainsCountries as MC on MC.CountryCode = C.CountryCode
	join Mountains as M on M.Id = MC.MountainId
	join Peaks as P on P.MountainId = M.Id
order by
	P.PeakName, C.CountryName