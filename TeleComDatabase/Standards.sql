CREATE TABLE [dbo].[Standards]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL, 
    [Service] INT NOT NULL
)
