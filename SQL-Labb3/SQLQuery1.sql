USE master
GO

IF NOT EXISTS(SELECT * FROM sys.databases
				WHERE name='BibliotekDb') 

	CREATE DATABASE BibliotekDb;
GO
USE BibliotekDb;
GO
CREATE SCHEMA Bibliotek;
GO


IF NOT EXISTS(SELECT * FROM sys.objects
				WHERE name='Bibliotek.Kund') 

CREATE TABLE Bibliotek.Kund
(
KundId int NOT NULL IDENTITY(1,1),
TelefonNr varchar(50) NOT NULL,
FadelseAr varchar(50) NOT NULL ,
ForNamn varchar (50) NOT NULL,
EfterNamn varchar (50) NOT NULL,
[Address] varchar (50) NOT NULL,
Email varchar (50),
Kon varchar (50) NOT NULL,

CONSTRAINT PK_Kund_KundId PRIMARY KEY (KundId),
CONSTRAINT AK_Kund_Email UNIQUE(Email),

);

IF NOT EXISTS(SELECT * FROM sys.objects
				WHERE name='Bibliotek.ForFattare') 

CREATE TABLE Bibliotek.Forfattare
(
ForfattarId int NOT NULL IDENTITY(1,1),
ForNamn varchar (50) NOT NULL,
EfterNamn varchar (50) NOT NULL,
FödelseAr varchar (50) NOT NULL,
DodsAr date  NULL,
Sprak varchar (50) NOT NULL,
Land varchar (50) NOT NULL,

CONSTRAINT PK_Forfattare_ForfattarId PRIMARY KEY (ForfattarId),

);

IF NOT EXISTS(SELECT * FROM sys.objects
				WHERE name='Bibliotek.Bok') 

CREATE TABLE Bibliotek.Bok
(
BokId int NOT NULL IDENTITY(1,1),
ForfattarId int NOT NULL ,
Titel varchar(50) NOT NULL,
PubliceringsAr date NOT NULL,
Genre varchar (50) NOT NULL,
Sprak Varchar (50) NOT NULL,
ISBN varchar(50) NOT NULL ,
CONSTRAINT PK_Bok_BokId PRIMARY KEY (BokId),
CONSTRAINT FK_Bok_Forfattare_ForfattarId
	FOREIGN KEY (ForfattarId) REFERENCES Bibliotek.Forfattare(ForfattarId)
);

IF NOT EXISTS(SELECT * FROM sys.objects
				WHERE name='Bibliotek.Kopia') 

CREATE TABLE Bibliotek.Kopia
(
KopiaId int NOT NULL IDENTITY(1,1),
BokId int NOT NULL,
InkopsPris smallmoney NOT NULL,
InkopsAr date NOT NULL,
[Status] int NOT NULL CONSTRAINT DF_Stauts DEFAULT 1,

CONSTRAINT PK_Kopia_KopiaId PRIMARY KEY (KopiaId),

CONSTRAINT FK_Kopia_Bok_BokId
	FOREIGN KEY (BokId) REFERENCES Bibliotek.Bok(BokId),
);

IF NOT EXISTS(SELECT * FROM sys.objects
				WHERE name='Bibliotek.Lan') 

CREATE TABLE Bibliotek.Lan
(
LanId int NOT NULL IDENTITY(1,1),
kundId int  NULL,
KopiaId int  NULL ,
LaneDatum date NOT NULL CONSTRAINT DF_LaneDatum DEFAULT GETDATE(),
LamnasTillbaka date NOT NULL CONSTRAINT DF_LamnasTillbaka DEFAULT DATEADD(WEEK, 2, GETDATE()),
SparradKund int NULL CONSTRAINT DF_SparradKund DEFAULT 1,

CONSTRAINT PK_Lan_LanId PRIMARY KEY (LanId),

CONSTRAINT FK_Lan_Kopia_KopiaId
	FOREIGN KEY (KopiaId) REFERENCES Bibliotek.Kopia(KopiaId),
CONSTRAINT FK_Lan_Kund_KundId
	FOREIGN KEY (KundId) REFERENCES Bibliotek.Kund(KundId),

);

--ALTER TABLE Bibliotek.Lan
--ADD CONSTRAINT uc_EttLanPerKund UNIQUE (KundId,KopiaId,LaneDatum)

DECLARE @ForfattarId INTEGER,
		@BokId INTEGER,
		@KopiaId INTEGER,
		@LanId INTEGER,
		@KundId INTEGER;



INSERT INTO Bibliotek.Kund (TelefonNr, FadelseAr, ForNamn, EfterNamn, [Address], Email, Kon)
VALUES ('000-0000000', GETDATE(), 'Robin', 'Svensson', 'Svenssonville 4', 'Robin@hotmail.com', 'Man')
SET @KundId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Kund (TelefonNr, FadelseAr, ForNamn, EfterNamn, [Address], Email, Kon)
VALUES ('000-0000000', GETDATE(), 'Emil', 'Svensson', 'Svenssonville 5', 'Emil@hotmail.com', 'Man')
SET @KundId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Kund (TelefonNr, FadelseAr, ForNamn, EfterNamn, [Address], Email, Kon)
VALUES ('000-0000000', GETDATE(), 'Anna', 'Svensson', 'Svenssonville 6', 'Anna@hotmail.com', 'Kvinna')
SET @KundId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Kund (TelefonNr, FadelseAr, ForNamn, EfterNamn, [Address], Email, Kon)
VALUES ('000-0000000', GETDATE(), 'Mia', 'Svensson', 'Svenssonville 7', 'Mia@hotmail.com', 'Kvinna')
SET @KundId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Kund (TelefonNr, FadelseAr, ForNamn, EfterNamn, [Address], Email, Kon)
VALUES ('000-0000000', GETDATE(), 'Gunnel', 'Svensson', 'Svenssonville 8', 'Gunnel@hotmail.com', 'Kvinna')
SET @KundId = SCOPE_IDENTITY();


INSERT INTO Bibliotek.Forfattare (ForNamn, EfterNamn, FödelseAr,Sprak, Land)
VALUES ('Joanne', 'Rowling', '1965-7-31', 'Engelska', 'England');
SET @ForfattarId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Bok (ForfattarId, Titel, PubliceringsAr, Genre, Sprak,ISBN)
VALUES (@ForfattarId, 'Harry Potter & de vises sten', GETDATE(), 'Aventyr', 'Svenska', '1245863254789');

SET @BokId = SCOPE_IDENTITY();
INSERT INTO Bibliotek.Kopia (BokId, InkopsPris, InkopsAr)
VALUES (@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE())

INSERT INTO Bibliotek.Bok (ForfattarId, Titel, PubliceringsAr, Genre, Sprak,ISBN)
VALUES (@ForfattarId, 'Harry Potter & Hemligheternas kammare', GETDATE(), 'Aventyr', 'Svenska', '853245698745');
SET @BokId = SCOPE_IDENTITY();
INSERT INTO Bibliotek.Kopia (BokId, InkopsPris, InkopsAr)
VALUES (@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE())

INSERT INTO Bibliotek.Bok (ForfattarId, Titel, PubliceringsAr, Genre, Sprak,ISBN)
VALUES (@ForfattarId, 'Harry Potter & Fången från Askebar', GETDATE(), 'Aventyr', 'Svenska', '4521365478965');
SET @BokId = SCOPE_IDENTITY();
INSERT INTO Bibliotek.Kopia (BokId, InkopsPris, InkopsAr)
VALUES (@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE())


INSERT INTO Bibliotek.Bok (ForfattarId, Titel, PubliceringsAr, Genre, Sprak,ISBN)
VALUES (@ForfattarId, 'Harry Potter & Phenix Orders', GETDATE(), 'Aventyr', 'Svenska', '6578941236585');
SET @BokId = SCOPE_IDENTITY();
INSERT INTO Bibliotek.Kopia (BokId, InkopsPris, InkopsAr)
VALUES (@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE())


INSERT INTO Bibliotek.Bok (ForfattarId, Titel, PubliceringsAr, Genre, Sprak,ISBN)
VALUES (@ForfattarId, 'Harry Potter & Gyllene Bägaren', GETDATE(), 'Aventyr', 'Svenska', '9654745871258');
SET @BokId = SCOPE_IDENTITY();
INSERT INTO Bibliotek.Kopia (BokId, InkopsPris, InkopsAr)
VALUES (@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE()),
		(@BokId,80, GETDATE())


INSERT INTO Bibliotek.Lan (kundId, KopiaId)
VALUES (@KundId, @KopiaId)
SET @LanId = SCOPE_IDENTITY();

INSERT INTO Bibliotek.Lan (kundId, KopiaId)
VALUES (@KundId, @KopiaId)
SET @LanId = SCOPE_IDENTITY();


INSERT INTO Bibliotek.Lan (kundId, KopiaId, LaneDatum)
	VALUES (@KundId,@KopiaId,GETDATE()),
			(@KundId,@KopiaId,GETDATE()),
			(@KundId,@KopiaId,GETDATE())
--SET @LanId = SCOPE_IDENTITY

SELECT * FROM Bibliotek.Kund

SELECT * FROM Bibliotek.Bok

SELECT * FROM Bibliotek.Kopia

SELECT * FROM Bibliotek.Lan

SELECT * FROM Bibliotek.Forfattare



--IF NOT EXISTS (SELECT name FROM sys.objects WHERE name = 'vUtlanadAvKundOchVaraTillbaka')

GO
CREATE VIEW vUtlanadAvKundOchVaraTillbaka AS


	SELECT Bibliotek.Bok.Titel AS BokTitel
		,	Bibliotek.Kund.ForNamn + ' ' + Bibliotek.Kund.EfterNamn AS Kund
		,	Bibliotek.Lan.LamnasTillbaka
	FROM Bibliotek.Lan  
		INNER JOIN Bibliotek.Kopia  ON Bibliotek.Lan.KopiaId = Bibliotek.Kopia.KopiaId
		INNER JOIN Bibliotek.Kund ON Bibliotek.Lan.kundId = Bibliotek.Kund.KundId
		INNER JOIN Bibliotek.Bok ON Bibliotek.Kopia.BokId = Bibliotek.Bok.BokId 

GO
CREATE VIEW vAntalKopiorTillgangligaUtlaning AS

	SELECT Bibliotek.Bok.Titel, COUNT (Bibliotek.Kopia.KopiaId) AS AntalTillgangliga
	FROM Bibliotek.Kopia
	INNER JOIN Bibliotek.Bok ON Bibliotek.Kopia.BokId = Bibliotek.Bok.BokId
	WHERE Bibliotek.Kopia.[Status] = 1
	GROUP BY Bibliotek.Bok.Titel


GO
CREATE PROCEDURE Utlaning
@KundId int,
@KopiaId int
 AS
 INSERT INTO Bibliotek.Lan (KundId, KopiaID, LaneDatum)
 VALUES (@KundId,@KopiaId,GETDATE())

GO
CREATE PROCEDURE Tillbakalamning (@KopiaId INT)
AS
UPDATE Bibliotek.Kopia
SET STATUS = 1
WHERE KopiaId = @KopiaId
UPDATE Bibliotek.Lan
SET SparradKund = 1
WHERE KopiaId = @KopiaId






