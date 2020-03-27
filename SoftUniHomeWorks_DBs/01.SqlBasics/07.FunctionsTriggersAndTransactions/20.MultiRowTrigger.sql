alter trigger TR_Users on UserGameItems
instead of insert
as
begin
	declare cursor_for_ins cursor for (select i.ItemId, i.UserGameId from inserted as i)
	
	open cursor_for_ins
		declare @currItemId int, @currUserGameId int
		fetch next from cursor_for_ins into @currItemId, @currUserGameId
		
		while @@FETCH_STATUS = 0
		begin
			declare @usr_cash money, @user_lvl int
			select @usr_cash = UG.Cash, 
				@user_lvl = UG.Level 
			from UsersGames as UG
			where UG.Id = @currUserGameId

			declare @item_price money, @item_min_lvl int
			select @item_price = I.Price, 
				@item_min_lvl = I.MinLevel
			from Items as I
			where I.Id = @currItemId

			-- buy item if the user has enoug money and min level :
			if (@item_price < @usr_cash and @item_min_lvl < @user_lvl)
			begin
				-- take out cash :
				update UsersGames
				set Cash = Cash - @item_price
				where Id = @currUserGameId
				-- insert item in users inventory :
				insert into UserGameItems(ItemId, UserGameId)
				values(@currItemId, @currUserGameId)
			end

			fetch next from cursor_for_ins into @currItemId, @currUserGameId
		end
	close cursor_for_ins
	deallocate cursor_for_ins
end
go

-- Add bonus cash of 50000 to users :
update 
	UsersGames
set 
	Cash = Cash + 50000
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
where 
	U.Username in ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') and
	G.Name = 'Bali'

-- Buy all items with ids in ([251...299] and [501 and 539]) 
-- for all users in ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') 
-- that are plaing in the game 'Bali' :
insert into UserGameItems(ItemId, UserGameId)
select 
	I.Id, UG.Id
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
	join Items as I on 1 = 1
where
	U.Username in ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') and
	G.Name = 'Bali' and
	(I.Id between 251 and 299 or I.Id between 501 and 539)
order by
	I.Id

-- Display the final result :
select 
	U.Username,
	G.Name,
	UG.Cash,
	I.Name as [Item Name]
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
	join UserGameItems as UGI on UGI.UserGameId = UG.Id
	join Items as I on I.Id = UGI.ItemId
where
	U.Username in ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') and
	G.Name = 'Bali'
order by
	U.Username, [Item Name]
