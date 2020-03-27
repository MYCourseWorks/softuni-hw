select 
	CUR.CurrencyCode as CurrencyCode, CUR.Description as Currency, 
	count(COU.ContinentCode) as NumberOfCountries
from 
	Countries as COU
	right join Currencies as CUR on CUR.CurrencyCode = COU.CurrencyCode
group by
	CUR.CurrencyCode, CUR.Description
order by
	NumberOfCountries desc, CUR.Description