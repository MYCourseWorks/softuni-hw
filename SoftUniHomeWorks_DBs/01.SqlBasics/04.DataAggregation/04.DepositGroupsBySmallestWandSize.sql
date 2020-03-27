declare @averageMinimum smallint;
set @averageMinimum = (select min(AvgWand)
						from (select DepositGroup, avg(MagicWandSize) as AvgWand
								from WizzardDeposits
								group by DepositGroup) as AggregaedWizzards)

select DepositGroup
from WizzardDeposits
group by DepositGroup
having avg(MagicWandSize) <= @averageMinimum
