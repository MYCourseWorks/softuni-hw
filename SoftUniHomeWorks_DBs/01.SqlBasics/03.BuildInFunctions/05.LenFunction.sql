select Name
from Towns
where LEN(Name) = 6 or LEN(Name) = 5
order by Name