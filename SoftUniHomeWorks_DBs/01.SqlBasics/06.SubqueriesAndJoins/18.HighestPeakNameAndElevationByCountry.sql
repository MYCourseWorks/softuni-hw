select top 5
	FullInfo.CountryName as Country,
	FullInfo.PeakName as HighestPeakName,
	FullInfo.Elevation as HighestPeakElevation,
	FullInfo.MountainRange as Mountain
from 
	(select C.CountryCode, 
		case
			when max(P.Elevation) is null then 0
			else max(P.Elevation)
		end as HighestPeakElevation
	from Countries as C
	left join MountainsCountries as MC on MC.CountryCode = C.CountryCode
	left join Mountains as M on M.Id = MC.MountainId
	left join Peaks as P on P.MountainId = M.Id
	group by C.CountryCode) as HighestPeaksInCountriesy
join 
	(select 
		C.CountryCode,
		C.CountryName, 
		case 
			when P.PeakName is null then '(no highest peak)'
			else P.PeakName
		end as PeakName,
		case
			when P.Elevation is null then 0
			else P.Elevation
		end as Elevation,
		case
			when M.MountainRange is null then '(no mountain)'
			else M.MountainRange
		end as MountainRange
	from Countries as C
	left join MountainsCountries as MC on MC.CountryCode = C.CountryCode
	left join Mountains as M on M.Id = MC.MountainId
	left join Peaks as P on P.MountainId = M.Id) as FullInfo
on 
	(HighestPeaksInCountriesy.CountryCode = FullInfo.CountryCode) and 
	(HighestPeaksInCountriesy.HighestPeakElevation = FullInfo.Elevation)
order by Country, HighestPeakName