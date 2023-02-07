-- Section 1. DDL

CREATE DATABASE NationalTouristSitesOfBulgaria
GO

USE NationalTouristSitesOfBulgaria
GO

-- 01. Database design

CREATE TABLE Categories(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    , Municipality VARCHAR(50)
    , Province VARCHAR(50)
)

CREATE TABLE Sites(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , [Name] VARCHAR(100) NOT NULL
    , LocationId INT NOT NULL  FOREIGN KEY REFERENCES Locations(Id)
    , CategoryId INT NOT NULL  FOREIGN KEY REFERENCES Categories(Id)
    , Establishment VARCHAR(15)
)

CREATE TABLE Tourists(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    , Age INT NOT NULL
    CHECK (Age BETWEEN 0 AND 120)
    , PhoneNumber VARCHAR(20) NOT NULL
    , Nationality VARCHAR(30) NOT NULL
    , Reward VARCHAR(20)
)

CREATE TABLE SitesTourists(
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id)
    , SiteId INT NOT NULL FOREIGN KEY REFERENCES Sites(Id)
    , PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes(
    TouristId INT NOT NULL FOREIGN KEY REFERENCES Tourists(Id)
    , BonusPrizeId INT NOT NULL FOREIGN KEY REFERENCES BonusPrizes(Id)
    , PRIMARY KEY(TouristId, BonusPrizeId)
)

-- Section 2. DML

-- 02. Insert

INSERT INTO Tourists VALUES
('Borislava Kazakova',	52,	'+359896354244',	'Bulgaria',	NULL),
('Peter Bosh',	48,	'+447911844141',	'UK',	NULL),
('Martin Smith',	29,	'+353863818592',	'Ireland',	'Bronze badge'),
('Svilen Dobrev',	49,	'+359986584786',	'Bulgaria',	'Silver badge'),
('Kremena Popova',	38,	'+359893298604',	'Bulgaria',	NULL)

INSERT INTO Sites VALUES
('Ustra fortress',	90,	7,	'X'),
('Karlanovo Pyramids',	65,	7,	NULL),
('The Tomb of Tsar Sevt',	63,	8,	'V BC'),
('Sinite Kamani Natural Park',	17,	1,	NULL),
('St. Petka of Bulgaria – Rupite',	92,	6,	'1994')

-- 03. Update

UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

-- 04. Delete

DECLARE @BonusPrizeID INT = (
    SELECT Id
    FROM BonusPrizes
    WHERE [Name] = 'Sleeping bag'
)

DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId = @BonusPrizeID

DELETE FROM BonusPrizes
WHERE Id = @BonusPrizeID

-- Section 3. Querying

-- 05. Tourists

SELECT [Name], Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

-- 06. Sites with Their Location and Category

SELECT
    s.[Name] AS [Site]
    , l.[Name] AS [Location]
    , s.Establishment
    , c.[Name] AS [Category]
FROM Sites AS s
JOIN Locations l ON l.Id = s.LocationId
JOIN Categories c ON c.Id = s.CategoryId
ORDER BY Category DESC, Location, Site

-- 07. Count of Sites in Sofia Province

SELECT
    l.Province AS [Province]
    , l.Municipality AS [Municipality]
    , l.[Name] AS [Location]
    , COUNT(s.Id) AS [CountOfSites]
FROM Locations AS l
JOIN Sites s ON l.Id = S.LocationId
GROUP BY l.Province, l.Municipality, l.[Name]
HAVING Province = 'Sofia'
ORDER BY CountOfSites DESC, Location

-- 08. Tourist Sites established BC

SELECT
    s.[Name] AS [Site]
    , l.[Name] AS [Location]
    , l.Municipality AS [Municipality]
    , l.Province AS [Province]
    , s.Establishment AS [Establishment]
FROM Sites AS s
JOIN Locations l ON l.Id = s.LocationId
WHERE l.[Name] NOT LIKE 'B%' AND
      l.[Name] NOT LIKE 'M%' AND
      l.[Name] NOT LIKE 'D%' AND
      s.Establishment LIKE '%BC'
ORDER BY Site

-- 09. Tourists with their Bonus Prizes

SELECT
    t.[Name]
    , t.Age
    , t.PhoneNumber
    , t.Nationality
    , IIF(bp.[Name] IS NULL, '(no bonus prize)', bp.[Name]) AS [Reward]
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes tbp ON tbp.TouristId = t.Id
LEFT JOIN BonusPrizes bp ON bp.Id = tbp.BonusPrizeId
ORDER BY t.[Name]

-- 10. Tourists visiting History and Archaeology sites

SELECT
   DISTINCT(SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) + 1, LEN(t.[Name]))) AS [LastName]
    , t.Nationality
    , t.Age
    , t.PhoneNumber
FROM Tourists AS t
JOIN SitesTourists st ON st.TouristId = t.Id
JOIN Sites s ON s.Id = st.SiteId
JOIN Categories c ON c.Id = s.CategoryId
WHERE c.[Name] = 'History and archaeology'
ORDER BY LastName

-- Section 4. Programmability

-- 11. Tourists Count on a Tourist Site

CREATE OR ALTER FUNCTION udf_GetTouristsCountOnATouristSite(@Site VARCHAR(100))
RETURNS INT
BEGIN
    DECLARE @countTouristsAtSite INT = (
        SELECT COUNT(t.Id)
        FROM Tourists AS t
        JOIN SitesTourists st ON st.TouristId = t.Id
        JOIN Sites s ON s.Id = st.SiteId
        WHERE s.[Name] = @Site
)
RETURN @countTouristsAtSite
END

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')


-- 12. Annual Reward Lottery

CREATE OR ALTER PROCEDURE usp_AnnualRewardLottery
(@TouristName VARCHAR(50))
AS
BEGIN

DECLARE @TouristID INT = (
    SELECT Id
    FROM Tourists
    WHERE [Name] = @TouristName
)

DECLARE @TouristSiteCount INT = (
    SELECT COUNT(t.Id)
    FROM Tourists AS t
    JOIN SitesTourists st ON st.TouristId = t.Id
    WHERE t.Id = @TouristID
)

UPDATE Tourists
SET Reward = (
    CASE
        WHEN @TouristSiteCount >= 100 THEN 'Gold badge'
        WHEN @TouristSiteCount >= 50 THEN 'Silver badge'
        WHEN @TouristSiteCount >= 25 THEN 'Bronze badge'
        ELSE NULL
    END
)
WHERE Id = @TouristID

SELECT
    [Name]
    , Reward
FROM Tourists
WHERE Id = @TouristID

END

EXEC usp_AnnualRewardLottery 'Teodor Petrov'
