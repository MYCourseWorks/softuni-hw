declare @item_id int, @user_game_id int,
	@item_price money, @usr_cash money

select 
	@user_game_id = UG.Id, 
	@usr_cash = UG.Cash
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
where
	G.Name = 'Edinburgh' and U.Username = 'Alex'

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Blackguard'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Bottomless Potion of Amplification'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Eye of Etlich (Diablo III)'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end	

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Gem of Efficacious Toxin'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Golden Gorget of Leoric'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end	

select 
	@item_id = Id, 
	@item_price = Price 
from Items 
where Name = 'Hellfire Amulet'

if (@item_price <= @usr_cash)
begin
	-- Take cash out :
	update UsersGames
	set Cash = Cash - @item_price
	where Id = @user_game_id
	-- Set User cash variable :
	set @usr_cash = @usr_cash - @item_price
	-- Insert item into usres inventory :
	insert into UserGameItems(ItemId, UserGameId) values (@item_id, @user_game_id)
end	

select 
	U.Username as Username, G.Name, UG.Cash, I.Name as [Item Name]
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
	join UserGameItems as UGI on UGI.UserGameId = UG.Id
	join Items as I on I.Id = UGI.ItemId
order by
	I.Name