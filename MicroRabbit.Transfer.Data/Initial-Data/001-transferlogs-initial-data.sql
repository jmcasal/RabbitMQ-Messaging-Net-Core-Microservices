
  truncate table [dbo].[TransferLogs]; 

  insert into TransferLogs (FromAccount, ToAccount, TransferAmount) values 
  (1,2, 2.15), 
  (2,1, 21.5); 

select * from dbo.TransferLogs;   