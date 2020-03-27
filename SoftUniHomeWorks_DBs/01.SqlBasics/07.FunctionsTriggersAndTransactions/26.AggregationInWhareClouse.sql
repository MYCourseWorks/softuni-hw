select 
	I.Name,
	I.Price,
	I.MinLevel,
	S.Strength,
	S.Defence,
	S.Speed,
	S.Luck,
	S.Mind
from 
	Items as I
	join [Statistics] as S on S.Id = I.StatisticId
where
	(select avg(Mind) from [Statistics]) < S.Mind and
	(select avg(Luck) from [Statistics]) < S.Luck and
	(select avg(Speed) from [Statistics]) < S.Speed
order by
	I.Name