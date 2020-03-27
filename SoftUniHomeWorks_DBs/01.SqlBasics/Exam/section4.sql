# task 16 :
create view v_UserWithCountries 
as
 select 
	C.FirstName + ' ' + C.LastName as CustomerName, 
	C.Age, C.Gender, COU.Name as CountryName
 from 
	Customers as C
	join Countries as COU on COU.Id = C.CountryId
go

select top 5 *
from v_UserWithCountries
order by Age 

drop view v_UserWithCountries

# task 17 :

create function dbo.udf_GetRating(@Name nvarchar(255))
returns
nvarchar(20)
as
begin
	declare @avgRate decimal(10, 2)

	select 
		@avgRate = avg(F.Rate)
	from 
		Feedbacks as F
		join Products as P on P.Id = F.ProductId
	where 
		P.Name = @Name

	if(@avgRate is null)
		return 'No rating'
	if (@avgRate < 5)
		return 'Bad'
	if (@avgRate between 5 and 8)
		return 'Average'
	
	return 'Good'
end
go

SELECT TOP 5 Id, Name, dbo.udf_GetRating(Name)
  FROM Products
 ORDER BY Id

drop function dbo.udf_GetRating

# task 18 :

create proc usp_SendFeedback 
(@cusomersId int, @productId int, @rate decimal(10, 2), @description nvarchar(255))
as

begin tran
declare @countOfFeedbacks int

select 
	@countOfFeedbacks = count(*)
from 
	Feedbacks 
where 
	CustomerId = @cusomersId

if (@countOfFeedbacks >= 3 and @countOfFeedbacks is not null)
begin
	--RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
	rollback tran;
end

insert into Feedbacks (CustomerId, ProductId, Rate, Description)
values (@cusomersId, @productId, @rate, @description)

commit tran

go

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;

drop proc usp_SendFeedback

# task 19 :

create trigger AutoIncrement_Trigger on Products
instead of delete 
as
declare cursor_for_ins cursor for (select d.Id from deleted as d)
	
open cursor_for_ins
	declare @curr_procut_id int
	fetch next from cursor_for_ins into @curr_procut_id 

	while @@FETCH_STATUS = 0
	begin
		
		delete Feedbacks
		where ProductId = @curr_procut_id

		delete ProductsIngredients
		where ProductId = @curr_procut_id

		delete Products
		where Id = @curr_procut_id

		fetch next from cursor_for_ins into @curr_procut_id
	end

close cursor_for_ins
deallocate cursor_for_ins