-- Insert Lieferanten
SET IDENTITY_INSERT [dbo].[Lieferant] ON
INSERT INTO [dbo].[Lieferant] ([Id],[Name],[Strasse],[Plz],[Ort],[Telefon]) VALUES (1, 'Metall Zulieferung AG', 'Bahnhofplatz 5', '80335', 'München', '089 / 12345678')
INSERT INTO [dbo].[Lieferant] ([Id],[Name],[Strasse],[Plz],[Ort],[Telefon]) VALUES (2, 'Holz GmbH', 'Bayerstr. 17', '80335', 'München', '089 / 87654321')
INSERT INTO [dbo].[Lieferant] ([Id],[Name],[Strasse],[Plz],[Ort],[Telefon]) VALUES (2, 'Buchhandlung GbR', 'Schillerstr. 43', '80335', 'München', '089 / 56788765')
SET IDENTITY_INSERT [dbo].[Lieferant] OFF

-- Insert Artikel
SET IDENTITY_INSERT [dbo].[Artikel] ON
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (1, 'Schraube M4 - 100 Stück', 1, 2.7, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (2, 'Schraube M5 - 100 Stück', 1, 3.55, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (3, 'Schraube M6 - 50 Stück', 1, 6.89, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (4, 'Schraube M8 - 50 Stück', 1, 9.99, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (5, 'Holzbrett 30x100', 1, 1.8, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (6, 'Holzbrett 40x100', 1, 2.3, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (7, 'Holzbrett 50x100', 1, 3.95, 19)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (8, 'Bastelanleitung', 1, 7.95, 7)
INSERT INTO [dbo].[Artikel] ([Id],[Bezeichnung],[LieferantId],[PreisNetto],[MwstSatz]) VALUES (9, 'Holzbearbeitung', 1, 11.95, 7)
SET IDENTITY_INSERT [dbo].[Artikel] OFF

-- Insert Kunden
SET IDENTITY_INSERT [dbo].[Kunde] ON
INSERT INTO [dbo].[Kunde] ([Id],[Vorname],[Nachname],[Strasse],[Plz],[Ort],[Telefon]) VALUES (1,'Hans','Mustermann','Blumenstr. 20','80331','München','')
INSERT INTO [dbo].[Kunde] ([Id],[Vorname],[Nachname],[Strasse],[Plz],[Ort],[Telefon]) VALUES (2,'Michaela','Musterfrau','Corneliusstr. 31','80331','München','')
SET IDENTITY_INSERT [dbo].[Kunde] OFF

-- Insert Aufträge
SET IDENTITY_INSERT [dbo].[Auftrag] ON
INSERT INTO [dbo].[Auftrag] ([Id],[KundeId],[RechnungId],[Datum],[Betrag],[IstBezahlt]) VALUES (1, 1, null, '2021-07-01',23.32, 0)
INSERT INTO [dbo].[Auftrag] ([Id],[KundeId],[RechnungId],[Datum],[Betrag],[IstBezahlt]) VALUES (2, 2, null, '2021-07-02',19.21, 0)
INSERT INTO [dbo].[Auftrag] ([Id],[KundeId],[RechnungId],[Datum],[Betrag],[IstBezahlt]) VALUES (3, 1, null, '2021-07-03',53.76, 0)
SET IDENTITY_INSERT [dbo].[Auftrag] OFF

SET IDENTITY_INSERT [dbo].[AuftragsPositionen] ON
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (1, 1, 1, 2, 3)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (2, 1, 2, 5, 1)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (3, 1, 3, 8, 1)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (4, 2, 1, 1, 2)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (5, 2, 2, 9, 1)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (6, 3, 1, 3, 1)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (7, 3, 2, 4, 1)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (8, 3, 3, 6, 2)
INSERT INTO [dbo].[AuftragsPositionen] ([Id],[AuftragId],[Position],[ArtikelId],[Menge]) VALUES (9, 3, 4, 7, 6)
SET IDENTITY_INSERT [dbo].[AuftragsPositionen] OFF


