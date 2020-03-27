select top 5 C.CountryName, 
		max(P.Elevation) as HighestPeakElevation, 
		max(R.Length) as LongestRiverLength
from Countries as C
left join MountainsCountries as MC on MC.CountryCode = C.CountryCode 
left join Mountains as M on M.Id = MC.MountainId 
left join Peaks as P on P.MountainId = M.Id
left join CountriesRivers as CR on CR.CountryCode = C.CountryCode 
left join Rivers as R on R.Id = CR.RiverId
group by C.CountryName
order by  HighestPeakElevation desc, LongestRiverLength desc, C.CountryName