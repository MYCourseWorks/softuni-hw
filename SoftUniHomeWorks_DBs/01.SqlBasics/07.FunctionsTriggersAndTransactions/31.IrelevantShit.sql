select
	C.CountryName, CON.ContinentName, count(R.Id) as RiversCount, 
	isnull(sum(R.Length), 0) as TotalLength
from 
	Rivers as R
	join CountriesRivers as CR on CR.RiverId = R.Id
	full join Countries as C on C.CountryCode = CR.CountryCode
	join Continents as CON on CON.ContinentCode = C.ContinentCode
group by
	C.CountryName, CON.ContinentName
order by 
	RiversCount desc, TotalLength desc, C.CountryName