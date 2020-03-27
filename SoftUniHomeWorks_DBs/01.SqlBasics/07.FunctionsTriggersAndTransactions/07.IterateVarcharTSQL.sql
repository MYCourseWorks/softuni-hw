create function ufn_IsWordComprised(@setOfLetters nvarchar(255), @word nvarchar(255))
returns bit
as
begin
	declare @length int = LEN(@word)
	declare @currChar nchar(1)
	declare @i int = 1
	declare @ret int = 1

	while(@i <= @length)
	begin
		set @currChar = SUBSTRING(@word, @i, 1)
		if (CHARINDEX(@currChar, @setOfLetters) <= 0)
		begin 
			set @ret = 0
			break
		end

		set @i = @i + 1
	end

	return @ret
end
go

select dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

drop function dbo.ufn_IsWordComprised