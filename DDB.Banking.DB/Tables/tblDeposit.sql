CREATE TABLE [dbo].[tblDeposit]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [CustomerId] INT NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [Date] DATETIME NOT NULL
)
