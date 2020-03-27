create proc usp_GetHoldersWithBalanceHigherThan (@balance money)
as
	select 
		TBT.FirstName, TBT.LastName 
	from 
		(select AH.FirstName, AH.LastName, sum(AC.Balance) as TotalBalance
			from AccountHolders as AH
			join Accounts as AC on AC.AccountHolderId =  AH.Id
			group by AH.FirstName, AH.LastName
			having sum(AC.Balance) >= @balance) as TBT -- Total Balance Table
go

exec usp_GetHoldersWithBalanceHigherThan 200000.00
drop proc usp_GetHoldersWithBalanceHigherThan