select 
	u.Username, 
	SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email) - CHARINDEX(u.Email, '@')) as [Email Provider]
from Users as u
order by [Email Provider], u.Username