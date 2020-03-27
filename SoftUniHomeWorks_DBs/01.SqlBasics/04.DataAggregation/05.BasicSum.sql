select DepositGroup, sum(DepositAmount) as TotalSum
from WizzardDeposits
group by DepositGroup