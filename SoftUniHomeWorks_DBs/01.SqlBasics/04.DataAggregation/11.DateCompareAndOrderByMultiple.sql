select DepositGroup, IsDepositExpired, avg(DepositInterest) as AverageInterest
from WizzardDeposits
where DepositStartDate > '01/01/1985'
group by DepositGroup, IsDepositExpired
order by DepositGroup desc, IsDepositExpired asc