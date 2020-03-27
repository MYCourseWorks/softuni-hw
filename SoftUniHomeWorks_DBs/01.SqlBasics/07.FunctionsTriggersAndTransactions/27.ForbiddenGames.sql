select 
	I.Name,
	I.Price,
	I.MinLevel,
	GT.Name as [Forbidden Game Type]
from 
	Items as I
	left join GameTypeForbiddenItems as GTF on GTF.ItemId = I.Id
	left join GameTypes as GT on GT.Id = GTF.GameTypeId
order by
	GT.Name desc, I.Name asc