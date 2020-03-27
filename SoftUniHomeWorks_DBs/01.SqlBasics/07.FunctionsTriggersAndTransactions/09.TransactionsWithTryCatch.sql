create proc usp_AssignProject(@emloyeeId int, @projectID int)
as
declare @user_error_msg varchar(100) = 'The employee has too many projects!'

begin tran AssignProject
begin try

declare @employeeProjectCount int = (select count(*) 
										from Employees as E
										join EmployeesProjects as EP on EP.EmployeeID = E.EmployeeID
										join Projects as P on P.ProjectID = EP.ProjectID
										where E.EmployeeID = @emloyeeId)
if (@employeeProjectCount >= 3)
begin
	RAISERROR(@user_error_msg, 16, 1)
end

insert into EmployeesProjects 
values (@emloyeeId, @projectID)

commit tran AssignProject

end try
begin catch

if (@@TRANCOUNT > 0)
begin
	rollback tran AssignProject
	
	if (ERROR_MESSAGE() = @user_error_msg)
	begin
		RAISERROR(@user_error_msg, 16, 1)
	end
	else
	begin
		declare @ErrorMessage nvarchar(max)
		declare @ErrorSeverity int
		declare @ErrorState int

		select @ErrorMessage = ERROR_MESSAGE() + ' Line ' + cast(ERROR_LINE() as nvarchar(5)), 
				@ErrorSeverity = ERROR_SEVERITY(), 
				@ErrorState = ERROR_STATE()

		RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
	end
end

end catch
go

exec usp_AssignProject 6, 1

drop proc usp_AssignProject