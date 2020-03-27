select C.CountryCode, M.MountainRange, P.PeakName, P.Elevation
from Countries as C
inner join MountainsCountries as MC
on C.CountryCode = MC.CountryCode and C.CountryName = 'Bulgaria'
inner join Mountains as M
on M.Id = MC.MountainId
inner join Peaks as P
on P.MountainId = M.Id
where P.Elevation > 2835
order by P.Elevation desc