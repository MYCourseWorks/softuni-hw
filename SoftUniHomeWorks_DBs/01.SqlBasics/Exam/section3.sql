--task 5 :
select Name, Price, Description 
from Products
order by Price desc, Name 

--task 6 :
select Name, Description, OriginCountryId
from Ingredients
where OriginCountryId in (1, 10, 20)
order by Id asc

--task 7 :
select top 15
	I.Name, I.Description, C.Name as CountryName
from 
	Ingredients as I
	join Countries as C on C.Id = I.OriginCountryId
where
	C.Name in ('Greece', 'Bulgaria')
order by
	I.Name, C.Name

--task 8 :
select top 10
	P.Name, P.Description, 
	avg(F.Rate) as AverageRate, count(F.Id) as FeedbacksAmount
from 
	Products as P
	join Feedbacks as F on F.ProductId = P.Id
group by
	P.Name, P.Description
order by
	AverageRate desc, FeedbacksAmount desc

--task 9 :
select 
	F.ProductId, F.Rate, F.Description, F.CustomerId, C.Age, C.Gender
from
	Feedbacks as F
	join Customers as C on C.Id = F.CustomerId
where
	F.Rate < 5.0
order by
	F.ProductId desc, F.Rate asc

--task 10 :
select 
	C.FirstName + ' ' + C.LastName as CustomerName, C.PhoneNumber, C.Gender
from
	Feedbacks as F
	right join Customers as C on C.Id = F.CustomerId
where
	F.Id is null
order by
	C.Id

--task 11 :
select
	F.ProductId, 
	C.FirstName + ' ' + C.LastName as CustomerName, 
	F.Description as FeedbackDescription
from
	Customers as C
	join Feedbacks as F on F.CustomerId = C.Id
where
	C.Id in (select C.Id 
			from Customers as C 
			join Feedbacks as F on F.CustomerId = C.Id
			group by C.Id
			having count(*) >= 3)
order by 
	F.ProductId, CustomerName, F.Id

--task 12 :
select
	C.FirstName, C.Age, C.PhoneNumber
from
	Customers as C
	join Countries as COU on COU.Id = C.CountryId
where
	(Age >= 21 and FirstName like '%an%') or
	(PhoneNumber like '%38' and COU.Name != 'Greece')
order by 
	C.FirstName asc, C.Age desc

--task 13 :
select
	D.Name as DistributorName, 
	I.Name as IngredientName,
	P.Name as ProductName,
	APF.AverageRate
from
	(select P.Id, avg(F.Rate) as AverageRate
		from Products as P
		join Feedbacks as F on F.ProductId = P.Id
		group by P.Id
		having (avg(F.Rate) between 5 and 8)) as APF
	join Products as P on P.Id = APF.Id
	join ProductsIngredients as PIN on PIN.ProductId = P.Id
	join Ingredients as I on I.Id = PIN.IngredientId
	join Distributors as D on D.Id = I.DistributorId
order by
	D.Name, I.Name, P.Name

--tast 14 :
declare @maxFeedbackRate decimal(10, 2)

select 
	@maxFeedbackRate = max(Q.FeedbackRate)
from
	(select 
		COU.Name as CountryName, 
		avg(F.Rate) as FeedbackRate
	from 
		Feedbacks as F
		join Customers as C on C.Id = F.CustomerId
		join Countries as COU on COU.Id = C.CountryId
	group by
		COU.Name) as Q

select 
	COU.Name as CountryName, 
	avg(F.Rate) as FeedbackRate
from 
	Feedbacks as F
	join Customers as C on C.Id = F.CustomerId
	join Countries as COU on COU.Id = C.CountryId
group by
	COU.Name
having
	avg(F.Rate) = @maxFeedbackRate