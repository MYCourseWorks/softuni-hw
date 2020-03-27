select 
	P.PeakName, M.MountainRange as Mountain, P.Elevation
from 
	Mountains as M
	join Peaks as P on P.MountainId = M.Id
order by
	P.Elevation desc, P.PeakName