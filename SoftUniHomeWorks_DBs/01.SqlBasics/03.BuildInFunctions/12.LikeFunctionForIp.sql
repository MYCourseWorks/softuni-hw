select u.Username, u.IpAddress
from Users as u
where u.IpAddress like '___.1%.%.___'
order by u.Username