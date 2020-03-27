select top 50 
	g.Name, 
	FORMAT(g.Start,'yyyy-MM-dd') as Start
from Games as g
where g.Start BETWEEN '2011-01-01' AND '2013-01-01'
order by g.Start