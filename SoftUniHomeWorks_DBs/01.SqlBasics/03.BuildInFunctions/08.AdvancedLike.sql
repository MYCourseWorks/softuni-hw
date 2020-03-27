select CountryName, IsoCode
from Countries as c
where LOWER(c.CountryName) like '%a%a%a%'
order by IsoCode