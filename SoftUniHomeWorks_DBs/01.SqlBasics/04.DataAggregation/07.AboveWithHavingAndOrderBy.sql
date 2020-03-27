select DepositGroup, sum(DepositAmount) as TotalSum
from WizzardDeposits
where MagicWandCreator = 'Ollivander family'
group by DepositGroup
having sum(DepositAmount) < 150000
order by TotalSum desc