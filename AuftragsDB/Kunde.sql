CREATE TABLE [dbo].[Kunde]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Vorname] NVARCHAR(100) NULL, 
    [Nachname] NVARCHAR(100) NULL, 
    [Strasse] NVARCHAR(100) NULL, 
    [Plz] NVARCHAR(10) NULL, 
    [Ort] NVARCHAR(100) NULL, 
    [Telefon] NVARCHAR(100) NULL
)
