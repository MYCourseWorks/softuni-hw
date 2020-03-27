select *
from Towns as t
where UPPER(LEFT(t.Name, 1)) = 'M' or 
	UPPER(LEFT(t.Name, 1)) = 'K' or
	UPPER(LEFT(t.Name, 1)) = 'B' or
	UPPER(LEFT(t.Name, 1)) = 'E'
order by t.Name