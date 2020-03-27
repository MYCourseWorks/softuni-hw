select top 5 C.CountryName, R.RiverName
from Countries as C
left join CountriesRivers as CR
on CR.CountryCode = C.CountryCode
left join Rivers as R
on R.Id = CR.RiverId
where C.ContinentCode = 'AF'
order by C.CountryName