CREATE TABLE [dbo].[tblCustomer]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SSN] VARCHAR(12) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [DOB] DATE NOT NULL
)
