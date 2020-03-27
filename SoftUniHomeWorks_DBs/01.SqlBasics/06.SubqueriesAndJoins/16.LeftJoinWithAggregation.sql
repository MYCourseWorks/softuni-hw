select count(*) as CountryCode
from Countries as C 
left join MountainsCountries as MC
on C.CountryCode = MC.CountryCode
left join Mountains as M
on  M.Id = MC.MountainId
where M.Id is null