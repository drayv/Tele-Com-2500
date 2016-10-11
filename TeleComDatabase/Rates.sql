CREATE TABLE [dbo].[Rates]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Amount] DECIMAL(18, 2) NOT NULL, 
    [Service] INT NOT NULL, 
    [StartDate] DATE NOT NULL
)
