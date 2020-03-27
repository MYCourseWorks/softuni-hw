select 
	SUBSTRING(U.Email, CHARINDEX('@', U.Email) + 1, LEN(U.Email) - CHARINDEX('@', U.Email)) as [Email Provider],
	count(*) as [Number Of Users]
from 
	Users as U
group by
	SUBSTRING(U.Email, CHARINDEX('@', U.Email) + 1, LEN(U.Email) - CHARINDEX('@', U.Email))
order by
	[Number Of Users] desc, [Email Provider]