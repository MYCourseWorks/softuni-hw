select
  W.AgeGroup,
  count(*) as WizzardCount
from (select 
			(case 
				when Age between 0 and 10 then '[0-10]'
				when Age between 11 and 20 then '[11-20]'
				when Age between 21 and 30 then '[21-30]'
				when Age between 31 and 40 then '[31-40]'
				when Age between 41 and 50 then '[41-50]'
				when Age between 51 and 60 then '[51-60]'
				else '[61+]'
			end) as AgeGroup
	 from WizzardDeposits) as W
group by W.AgeGroup