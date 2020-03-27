select M.MountainRange, P.PeakName, P.Elevation
from Mountains as M
join Peaks as P
on P.MountainId = M.Id
where M.MountainRange = 'Rila'
order by Elevation desc
