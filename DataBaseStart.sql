USE master
GO
IF exists (SELECT * FROM sysdatabases WHERE name='Schulplaner')  -- Prüfen ob Datenbank bereits existiert
BEGIN
	RAISERROR('Die bereits existierende Datenbank Schulplaner wird gelöscht',0,1)
	DROP DATABASE Schulplaner  --Löschen Datenbank
END
GO
CHECKPOINT  -- Prüfpunkt damit Datenbankänderungen wirklich auf Datenträger geschrieben ist
CREATE DATABASE Schulplaner  -- Erstellen Datenbank Schulplaner
GO
CHECKPOINT
USE Schulplaner  -- Datenbank DBname wird aktive Datenbank
GO
CREATE TABLE Benutzer
(
	BenutzerID	int identity(1,1) primary key,
	Vorname		nvarchar(50),
	Nachname	nvarchar(50),
	Passwort	nvarchar(64),
	Email		nvarchar(50),
	Klasse		nvarchar(50),
	RollenID	int

)
GO
CREATE TABLE OeffentlicherKalender
(
	KalenderID int identity(1,1) primary key,
)
GO

CREATE TABLE Beziehung_Benutzer_OeffentlicherKalender
(
	BenutzerID int foreign key references Benutzer(BenutzerID)
)
GO
CREATE TABLE Erinnerungen
(
	ErinnerungsID int identity(1,1) primary key,
	Zeitpunkt	date
)
GO

CREATE TABLE Eintraege
(
	EintragsID	int identity(1,1) primary key,
	Titel		nvarchar(100),
	Beschreibung	nvarchar(200),
	TerminStart		datetime,
	TerminEnde		datetime,
	ErinnerungsID	int foreign key references Erinnerungen(ErinnerungsID),
)

GO
CREATE TABLE Beziehung_Benutzer_Eintraege
(
	BenutzerID int foreign key references Benutzer(BenutzerID),
	EintragsID	int foreign key references Eintraege(EintragsID)
)
GO
CREATE TABLE Beziehung_OeffentlicheKalender_Eintraege
(
	KalenderID int foreign key references OeffentlicherKalender(KalenderID),
	EintragsID	int foreign key references Eintraege(EintragsID)
)
GO

CREATE TABLE Rollen
(
	RollenID int identity(1,1) primary key,
	Beschreibung	nvarchar(200)
)
