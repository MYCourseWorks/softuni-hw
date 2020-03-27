select 
	G.Name as [Game],
	GT.Name as [Game Type],
	U.Username,
	UG.Level,
	UG.Cash,
	C.Name as [Character]
from 
	Users as U
	join UsersGames as UG on UG.UserId = U.Id
	join Games as G on G.Id = UG.GameId
	join GameTypes as GT on GT.Id = G.GameTypeId
	join Characters as C on C.Id = UG.CharacterId
order by
	UG.Level desc, U.Username asc, G.Name asc