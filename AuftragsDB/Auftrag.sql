CREATE TABLE [dbo].[Auftrag]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    [KundeId] INT NOT NULL, 
    [RechnungId] INT NULL, 
    [Datum] DATE NOT NULL, 
    [Betrag] MONEY NOT NULL, 
    [IstBezahlt] BIT NOT NULL, 
    CONSTRAINT [FK_Auftrag_Kunde] FOREIGN KEY ([KundeId]) REFERENCES [Kunde]([Id]), 
    CONSTRAINT [FK_Auftrag_Rechnung] FOREIGN KEY ([RechnungId]) REFERENCES [Rechnung]([Id]) 
)
