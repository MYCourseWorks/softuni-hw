select 
	CountryName, 
	CountryCode, 
	case 
		when CurrencyCode = 'EUR'
			then 'Euro'
			else 'Not Euro'
	end as Currency
from Countries
order by CountryName