select DepositGroup, MagicWandCreator, min(DepositCharge) as MinDepositCharge 
from WizzardDeposits
group by DepositGroup, MagicWandCreator
order by MagicWandCreator, DepositGroup