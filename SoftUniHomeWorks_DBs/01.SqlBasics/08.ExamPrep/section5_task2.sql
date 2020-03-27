create proc usp_PurchaseTicket
(@CustomerID int, @FlightID int, @TicketPrice decimal(8, 2), @Class varchar(6), @Seat varchar(5))
as
	declare @customer_balance decimal(10, 2)
	select @customer_balance = Balance from CustomerBankAccounts where CustomerID = @CustomerID

	if (@customer_balance < @TicketPrice or @customer_balance is null)
	begin
		raiserror('Insufficient bank account balance for ticket purchase.', 16, 1)
		return
	end

	declare @ticket_id int = (select count(*) from Tickets) + 1
	
	insert into Tickets (TicketID, Price, Class, Seat, CustomerID, FlightID)
	values (@ticket_id, @TicketPrice, @Class, @Seat, @CustomerID, @FlightID)

	update CustomerBankAccounts
	set Balance = Balance - @TicketPrice
	where CustomerID = @CustomerID
