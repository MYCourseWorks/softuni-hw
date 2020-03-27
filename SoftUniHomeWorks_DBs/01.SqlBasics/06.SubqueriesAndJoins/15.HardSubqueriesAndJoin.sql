select B.ContinentCode, C.CurrencyCode, C.CurrencyUsage
from (select A.ContinentCode, max(A.CurrencyUsage) as MaxUsage
		from (select CON.ContinentCode, CUR.CurrencyCode, count(COU.CountryCode) as CurrencyUsage
				from Countries as COU
				join Currencies as CUR on CUR.CurrencyCode = COU.CurrencyCode
				join Continents as CON on CON.ContinentCode = COU.ContinentCode
				group by CON.ContinentCode, CUR.CurrencyCode
				having count(COU.CountryCode) > 1) as A
		group by A.ContinentCode) as B
inner join (select CON.ContinentCode, CUR.CurrencyCode, count(COU.CountryCode) as CurrencyUsage
		from Countries as COU
		join Currencies as CUR on CUR.CurrencyCode = COU.CurrencyCode
		join Continents as CON on CON.ContinentCode = COU.ContinentCode
		group by CON.ContinentCode, CUR.CurrencyCode
		having count(COU.CountryCode) > 1) as C
on C.ContinentCode = B.ContinentCode and C.CurrencyUsage = B.MaxUsage
order by B.ContinentCode