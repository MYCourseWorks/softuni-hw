select FirstLetter
from (select distinct SUBSTRING(FirstName, 0, 2) as FirstLetter
		from WizzardDeposits
		where DepositGroup = 'Troll Chest') as W
group by FirstLetter
order by FirstLetter
