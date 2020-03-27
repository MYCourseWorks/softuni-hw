select salaries.DepartmentID, salaries.Salary as ThridHighest from 
(
	select DepartmentID, 
		max(Salary) as Salary,
		DENSE_RANK() over (partition by DepartmentId order by Salary desc) as Rank
	from Employees
	group by DepartmentID, Salary
) as salaries
where Rank = 3