create proc usp_SubmitReview 
(@CustomerID int, @ReviewContent varchar(255), @ReviewGrade int, @AirlineName varchar(30))
as
	declare @airline_id as int
    select @airline_id = A.AirlineID from Airlines as A where A.AirlineName = @AirlineName

	if (@airline_id is null)
	begin
		raiserror('Airline does not exist.', 16, 1)
	end

	declare @review_id int = (select count(*) from CustomerReviews)

	insert into CustomerReviews (ReviewID, ReviewContent, CustomerID, ReviewGrade, AirlineID)
	values (@review_id, @ReviewContent, @CustomerID, @ReviewGrade, @airline_id)

go
drop proc usp_SubmitReview