select * into HighEarningEployes from Employees
where Salary > 30000

delete from HighEarningEployes
where ManagerID = 42

update HighEarningEployes
set Salary += 5000
where DepartmentID = 1

select DepartmentID, avg(Salary) as AverageSalary
from HighEarningEployes
group by DepartmentID

drop table HighEarningEployes