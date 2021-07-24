CREATE TABLE [dbo].[Rechnung]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Datum] DATE NOT NULL, 
    [Betrag] MONEY NOT NULL, 
    [Dateiname] NVARCHAR(100) NOT NULL, 
    [Url] NVARCHAR(500) NOT NULL, 
)
