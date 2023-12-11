CREATE TABLE [dbo].[tblWithdrawal]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [Date] DATETIME NOT NULL
)
