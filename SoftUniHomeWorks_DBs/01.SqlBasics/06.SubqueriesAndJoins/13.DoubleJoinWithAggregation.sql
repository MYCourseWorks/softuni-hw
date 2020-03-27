select C.CountryCode, count(M.Id) as MountainRanges
from Countries as C
inner join MountainsCountries as MC
on MC.CountryCode = C.CountryCode
inner join Mountains as M
on M.Id = MC.MountainId
where C.CountryName in ('United States', 'Russia','Bulgaria')
group by C.CountryCode