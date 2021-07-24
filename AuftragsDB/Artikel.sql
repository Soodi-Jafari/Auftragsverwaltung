CREATE TABLE [dbo].[Artikel]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Bezeichnung] NVARCHAR(50) NOT NULL, 
    [LieferantId] INT NOT NULL, 
    [PreisNetto] MONEY NULL, 
    [MwstSatz] INT NOT NULL, 
    CONSTRAINT [FK_Artikel_Lieferant] FOREIGN KEY ([LieferantId]) REFERENCES [Lieferant]([Id])
)
