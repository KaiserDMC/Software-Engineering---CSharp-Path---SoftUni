-- Section 1. DDL

CREATE DATABASE Boardgames
GO

USE Boardgames
GO

-- 01. Database design

CREATE TABLE Categories(
    Id INT IDENTITY PRIMARY KEY
    , [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Addresses(
    Id INT IDENTITY PRIMARY KEY
    , StreetName NVARCHAR(100) NOT NULL
    , StreetNumber INT NOT NULL
    , Town VARCHAR(30) NOT NULL
    , Country VARCHAR(50) NOT NULL
    , ZIP INT NOT NULL
)

CREATE TABLE Publishers(
    Id INT IDENTITY PRIMARY KEY
    , [Name] VARCHAR(30) NOT NULL UNIQUE
    , AddressId INT NOT NULL FOREIGN KEY REFERENCES Addresses(Id)
    , Website NVARCHAR(40)
    , Phone NVARCHAR(20)
)

CREATE TABLE PlayersRanges(
    Id INT IDENTITY PRIMARY KEY
    , PlayersMin INT NOT NULL
    , PlayersMax INT NOT NULL
)

CREATE TABLE Boardgames(
    Id INT IDENTITY PRIMARY KEY
    , [Name] NVARCHAR(30) NOT NULL
    , YearPublished INT NOT NULL
    , Rating DECIMAL(18,2) NOT NULL
    , CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id)
    , PublisherId INT NOT NULL FOREIGN KEY REFERENCES Publishers(Id)
    , PlayersRangeId INT NOT NULL FOREIGN KEY REFERENCES PlayersRanges(Id)

)

CREATE TABLE Creators(
    Id INT IDENTITY PRIMARY KEY
    , FirstName NVARCHAR(30) NOT NULL
    , LastName NVARCHAR(30) NOT NULL
    , Email NVARCHAR(30) NOT NULL
)

CREATE TABLE CreatorsBoardgames(
    CreatorId INT NOT NULL FOREIGN KEY REFERENCES Creators(Id)
    , BoardgameId INT NOT NULL FOREIGN KEY REFERENCES Boardgames(Id)
    PRIMARY KEY (CreatorId, BoardgameId)
)

-- Section 2. DML

-- 02. Insert

INSERT INTO Boardgames VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

-- 03. Update

UPDATE PlayersRanges
SET PlayersMax += 1
WHERE (PlayersMin = 2 AND PlayersMax = 2)

UPDATE Boardgames
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished >= 2020

-- 04. Delete

CREATE TABLE TempTableWithAddresses(
    Id INT IDENTITY PRIMARY KEY
    , AddressId INT
)
INSERT INTO TempTableWithAddresses(AddressId)
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'

DECLARE @valueToRemove INT = (
                                 SELECT
                                     AddressId
                                 FROM TempTableWithAddresses
                                 WHERE Id = 1
                                )

DELETE FROM CreatorsBoardgames
        WHERE BoardgameId IN (
                            SELECT
                                b.Id
                            FROM Boardgames AS b
                            LEFT JOIN Publishers AS p ON p.Id = b.PublisherId
                            WHERE p.AddressId IN (@valueToRemove)
                            )

DELETE FROM Boardgames
        WHERE PublisherId IN (
                            SELECT
                                Id
                            FROM Publishers
                            WHERE AddressId IN (@valueToRemove)
                            )

DELETE FROM Publishers
        WHERE AddressId IN (@valueToRemove)

DELETE FROM Addresses
        WHERE Id IN (@valueToRemove)

-- Section 3. Querying

-- 05. Boardgames by Year of Publication

SELECT
    [Name]
    , Rating
FROM Boardgames
ORDER BY YearPublished, [Name] DESC

-- 06. Boardgames by Category

SELECT
    b.[Id]
    , b.[Name]
    , b.YearPublished
    , c.[Name] AS [CategoryName]
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
WHERE c.[Name] IN ('Strategy Games', 'Wargames')
ORDER BY b.YearPublished DESC

-- 07. Creators without Boardgames

SELECT
    c.Id
    , CONCAT(c.FirstName, ' ', c.LastName) AS [CreatorName]
    , c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
WHERE cb.CreatorId IS NULL
ORDER BY CreatorName

-- 08. First 5 Boardgames

SELECT TOP(5)
    b.[Name]
    , b.Rating
    , c.Name AS [CategoryName]
FROM Boardgames AS b
JOIN Categories AS c ON c.Id = b.CategoryId
JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
WHERE (b.Rating > 7.0 AND b.[Name] LIKE '%a%') OR
      (b.Rating > 7.5 AND (pr.PlayersMin = 2 AND pr.PlayersMax = 5))
ORDER BY b.[Name], b.Rating DESC

-- 09. Creators with Emails

SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS [FullName]
    , c.Email
    , MAX(b.Rating) AS [Rating]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email
ORDER BY FullName

-- 10. Creators by Rating

SELECT
    c.LastName
    , CEILING(AVG(b.Rating)) AS [AverageRating]
    , p.[Name]
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

-- Section 4. Programmability

-- 11. Creator with Boardgames

CREATE OR ALTER FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
BEGIN
    DECLARE @creatorId INT = (
        SELECT Id
        FROM Creators
        WHERE FirstName = @name
    )

    RETURN (
        SELECT COUNT(*)
        FROM CreatorsBoardgames
        WHERE CreatorId = @creatorId
    )

END

SELECT dbo.udf_CreatorWithBoardgames('Bruno')

-- 12. Search for Boardgame with Specific Category

CREATE OR ALTER PROCEDURE usp_SearchByCategory
(@category VARCHAR(50))
AS
    BEGIN
        SELECT
            b.[Name]
            , b.YearPublished
            , b.Rating
            , c.[Name] AS [CategoryName]
            , p.[Name] AS [PublisherName]
            , CONCAT(pr.PlayersMin, ' people') AS [MinPlayers]
            , CONCAT(pr.PlayersMax, ' people') AS [MaxPlayers]
        FROM Boardgames AS b
        JOIN PlayersRanges AS pr ON pr.Id = b.PlayersRangeId
        JOIN Categories AS c ON c.Id = b.CategoryId
        JOIN Publishers AS p on p.Id = b.PublisherId
        WHERE c.[Name] = @category
        ORDER BY p.[Name], b.YearPublished DESC

    END

EXEC usp_SearchByCategory 'Wargames'