select 
	U.Username,
	G.Name as Game,
	count(I.Id) as [Items Count],
	sum(I.Price) as [Items Price]
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
	join UserGameItems as UGI on UGI.UserGameId = UG.Id
	join Items as I on I.Id = UGI.ItemId
group by
	U.Username, G.Name
having
	count(I.Id) >= 10
order by
	[Items Count] desc, 
	[Items Price] desc, 
	U.Username