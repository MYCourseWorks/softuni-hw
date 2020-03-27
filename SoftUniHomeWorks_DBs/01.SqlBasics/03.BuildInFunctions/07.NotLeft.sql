select * 
from Towns as t
where NOT(UPPER(LEFT(t.Name, 1)) = 'R') and 
	NOT(UPPER(LEFT(t.Name, 1)) = 'B') and
	NOT(UPPER(LEFT(t.Name, 1)) = 'D')
order by t.Name