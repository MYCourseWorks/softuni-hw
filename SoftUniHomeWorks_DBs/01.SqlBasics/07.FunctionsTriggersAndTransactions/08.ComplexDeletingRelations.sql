-- make department ManagerId nullable :
alter table Departments
alter column ManagerId int null

-- delete all Production and Production Control EmployeesProjects relations :
delete from EmployeesProjects
where EmployeeID in (select E.EmployeeID 
						from Employees as E
						join Departments as D on E.DepartmentID = D.DepartmentID
						where D.Name in ('Production', 'Production Control'))

-- delete all Production and Production Control self relations :
update Employees
set ManagerID = null
where ManagerID in (select E.EmployeeID 
						from Employees as E
						join Departments as D on E.DepartmentID = D.DepartmentID
						where D.Name in ('Production', 'Production Control'))

-- delete all Production and Production Control Managers from the Departments relation :
update Departments
set ManagerID = null
where ManagerID in (select E.EmployeeID 
						from Employees as E
						join Departments as D on E.DepartmentID = D.DepartmentID
						where D.Name in ('Production', 'Production Control'))

-- Finally delete the Employees and Departments :
delete from Employees
where EmployeeID in (select E.EmployeeID 
						from Employees as E
						join Departments as D on E.DepartmentID = D.DepartmentID
						where D.Name in ('Production', 'Production Control'))

delete from Departments
where Name in ('Production', 'Production Control')