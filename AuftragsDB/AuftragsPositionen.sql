CREATE TABLE [dbo].[AuftragsPositionen]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [AuftragId] INT NOT NULL, 
    [Position] INT NOT NULL, 
    [ArtikelId] INT NOT NULL, 
    [Menge] INT NOT NULL, 
    CONSTRAINT [FK_AuftragsPositionen_Auftrag] FOREIGN KEY ([AuftragId]) REFERENCES [Auftrag]([Id]), 
    CONSTRAINT [FK_AuftragsPositionen_Artikel] FOREIGN KEY ([ArtikelId]) REFERENCES [Artikel]([Id])
)
