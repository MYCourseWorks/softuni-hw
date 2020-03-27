select 
	p.PeakName,
	r.RiverName,
	LOWER(p.PeakName + SUBSTRING(r.RiverName, 2, LEN(r.RiverName) - 1)) as Mix
from Peaks as p
inner join Rivers as r
on RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
order by Mix