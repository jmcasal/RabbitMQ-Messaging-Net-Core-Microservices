
  truncate table [dbo].[Accounts]; 

  declare @count int = 10; 
  while (@count > 0) begin

  declare @accountNo varchar(100) = format( 1 + (select count(1) from dbo.Accounts), '0000'); 

  insert into Accounts (AccountType, AccountNumber, AccountBalance) select 
	concat('TYPE-', @AccountNo) as AccountType,  
	concat('NUMBER-', @AccountNo) as AccountNumber
	, rand() * 9999 as AccountBalance 

	set @count = @count -1; 

end; 
 
 select * from Accounts order by 1 desc; 
  