declare @stamat_game_id int,
	@stamat_cash money

select @stamat_game_id = UG.Id,
	@stamat_cash = UG.Cash
from Users as U
join UsersGames as UG on UG.UserId = U.Id
join Games as G on G.Id = UG.GameId
where U.Username = 'Stamat' and G.Name = 'Safflower'

declare @curr_lvl_range int = 0

while @curr_lvl_range < 22 
begin
	set @curr_lvl_range = @curr_lvl_range + 1

	if ((@curr_lvl_range between 11 and 12) or 
		(@curr_lvl_range between 19 and 21))
	begin
		begin tran
		begin try
			declare item_cursor cursor for 
				(select I.Id, I.Price 
					from Items as I 
					where I.MinLevel = @curr_lvl_range)

			open item_cursor
				declare @cur_item_id int,
					@cur_item_price money
				fetch next from item_cursor into @cur_item_id, @cur_item_price
		
				while @@FETCH_STATUS = 0
				begin
					if (@cur_item_price > @stamat_cash)
					begin
						rollback tran
						break
					end
			
					-- take out money :
					update UsersGames
					set Cash = Cash - @cur_item_price
					where Id = @stamat_game_id
					-- update stamat's cash variable :
					set @stamat_cash = @stamat_cash - @cur_item_price
					-- insert item into stamat's inventory :
					insert into UserGameItems(ItemId, UserGameId)
					values(@cur_item_id, @stamat_game_id)
			
					fetch next from item_cursor into @cur_item_id, @cur_item_price
				end
			close item_cursor
			deallocate item_cursor

			commit tran
		end try
		begin catch
			if (@@TRANCOUNT > 0)
			begin
				rollback tran
				declare @ErrorMessage nvarchar(max)
				declare @ErrorSeverity int
				declare @ErrorState int

				select @ErrorMessage = ERROR_MESSAGE() + ' Line ' + cast(ERROR_LINE() as nvarchar(5)), 
						@ErrorSeverity = ERROR_SEVERITY(), 
						@ErrorState = ERROR_STATE()

				RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState)
			end
		end catch
	end
end

select I.Name as [Item Name]
from Users as U
join UsersGames as UG on UG.UserId = U.Id
join Games as G on G.Id = UG.GameId
join UserGameItems as UGI on UGI.UserGameId = UG.Id
join Items as I on I.Id = UGI.ItemId
where U.Username = 'Stamat' and G.Name = 'Safflower'