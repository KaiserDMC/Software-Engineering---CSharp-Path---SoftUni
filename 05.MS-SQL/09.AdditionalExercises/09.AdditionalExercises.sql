-- Part I - Queries for Diablo Database

USE Diablo
GO

-- 01. Number of Users for Email Provider

SELECT
    [Email Provider]
    , COUNT([Email Provider]) AS [Number Of Users]
FROM
(
SELECT
     SUBSTRING([Email], (CHARINDEX('@', [Email]) + 1), LEN([Email])) AS [Email Provider]
 FROM Users
 ) AS [ep]
GROUP BY [Email Provider]
ORDER BY [Number Of Users] DESC, [Email Provider]

-- 02. All User in Games

SELECT
    g.[Name] AS [Game]
    , gt.[Name] AS [Game Type]
    , u.[Username] AS [Username]
    , ug.[Level] AS [Level]
    , ug.[Cash] AS [Cash]
    , c.[Name] AS [Character]
FROM Games AS g
JOIN GameTypes gt on gt.Id = g.GameTypeId
JOIN UsersGames ug on ug.GameId = g.Id
JOIN Users u on ug.UserId = u.Id
JOIN Characters c on ug.CharacterId = c.Id
ORDER BY [Level] DESC, [Username], [Game]

-- 03. User in Games with Their Items

SELECT
    u.[Username] AS [Username]
    , g.[Name] AS [Game]
    , COUNT(ugi.ItemId) AS [Items Count]
    , SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames ug on ug.UserId = u.Id
JOIN Games g on g.Id = ug.GameId
JOIN UserGameItems ugi on ugi.UserGameId = ug.Id
JOIN Items i on i.Id = ugi.ItemId
GROUP BY u.[Username], g.[Name]
HAVING COUNT(ugi.ItemId) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username

-- 04. User in Games with Their Statistics


-- 05. All Items with Greater than Average Statistics

DECLARE @averageMind DECIMAL(18,2) = (
    SELECT AVG(Mind)
    FROM [Statistics]
    )

DECLARE @averageLuck DECIMAL(18,2) = (
    SELECT AVG(Luck)
    FROM [Statistics]
    )

DECLARE @averageSpeed DECIMAL(18,2) = (
    SELECT AVG(Speed)
    FROM [Statistics]
    )

SELECT
    i.Name
    , i.Price
    , i.MinLevel
    , s.Strength
    , s.Defence
    , s.Speed
    , s.Luck
    , s.Mind
FROM Items AS i
JOIN [Statistics] s ON s.Id = i.StatisticId
WHERE
    s.Luck > @averageLuck AND
    s.Mind > @averageMind AND
    s.Speed > @averageSpeed
ORDER BY i.Name

-- 06. Display All Items with Information about Forbidden Game Type

SELECT
    i.Name AS [Item]
    , i.Price AS [Price]
    , i.MinLevel AS [MinLevel]
    , gt.Name AS [Forbidden Game Type]
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems gtfi on gtfi.ItemId = i.Id
LEFT JOIN GameTypes gt on gt.Id = gtfi.GameTypeId
ORDER BY gt.Name DESC, i.Name

-- 07. Buy Items for User in Game

DECLARE @userGameID INT = (
    SELECT ug.[Id]
    FROM UsersGames AS ug
    JOIN Users u ON u.Id = ug.UserId
    JOIN Games AS g ON g.[Id] = ug.[GameId]
    WHERE g.[Name] = 'Edinburgh' AND u.[Username] = 'Alex'
)

DECLARE @totalItemCost MONEY = (
    SELECT SUM(Price)
    FROM Items
    WHERE [Id] IN (51, 71, 157, 184, 197, 223)
)

UPDATE UsersGames
    SET [Cash] -= @totalItemCost
    WHERE [Id] = @userGameID

INSERT INTO UserGameItems
    SELECT [Id], @userGameID
    FROM Items
    WHERE [Id] IN (51, 71, 157, 184, 197, 223)

SELECT
    u.Username
    , g.Name
    , ug.Cash
    , i.Name AS [Item Name]
FROM Users AS u
JOIN UsersGames ug on ug.UserId= u.Id
JOIN Games g on g.Id = ug.GameId
JOIN UserGameItems ugi on ugi.UserGameId = ug.Id
JOIN Items i on i.Id = ugi.ItemId
WHERE g.[Name] = 'Edinburgh'
ORDER BY [Item Name]

-- Part II - Queries for Geography Database

USE Geography
GO

-- 08. Peaks and Mountains

SELECT
    p.PeakName
    , m.MountainRange AS [Mountain]
    , p.Elevation
FROM Mountains AS m
JOIN Peaks p ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, p.PeakName

-- 09. Peaks with Their Mountain, Country and Continent

SELECT
    p.PeakName
    , m.MountainRange
    , c.CountryName
    , cc.ContinentName
FROM Mountains AS m
JOIN Peaks p ON p.MountainId = m.Id
JOIN MountainsCountries mc on mc.MountainId = m.Id
JOIN Countries c on c.CountryCode = mc.CountryCode
JOIN Continents cc ON cc.ContinentCode = c.ContinentCode
ORDER BY p.PeakName, c.CountryName

-- 10. Rivers by Country

SELECT
    c.CountryName
    , cc.ContinentName
    , COUNT(r.Id)                                    AS [RiverCount]
    , IIF(SUM(r.Length) IS NULL, '0', SUM(r.Length)) AS TotalLength
FROM Countries AS c
LEFT JOIN Continents cc on cc.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers cr on cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r on r.Id = cr.RiverId
GROUP BY c.CountryName, cc.ContinentName
ORDER BY RiverCount DESC, TotalLength DESC, CountryName

-- 11. Count of Countries by Currency

SELECT
    cur.CurrencyCode
    , cur.Description AS [Currency]
    , COUNT(c.CountryName) AS [NumberOfCountries]
FROM Countries AS c
RIGHT JOIN Currencies cur on cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY NumberOfCountries DESC, Currency

-- 12. Population and Area by Continent

SELECT
    cc.ContinentName
    , SUM(CAST((c.AreaInSqKm) AS BIGINT)) AS [CountriesArea]
    , SUM(CAST((c.Population) AS BIGINT)) AS [CountriesPopulation]
FROM Continents AS cc
LEFT JOIN Countries c on c.ContinentCode = cc.ContinentCode
GROUP BY cc.ContinentName
ORDER BY CountriesPopulation DESC

-- 13. Monasteries by Country

CREATE TABLE Monasteries(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , [Name] VARCHAR(100)
    , CountryCode CHAR(2) FOREIGN KEY REFERENCES Countries(CountryCode)
)
--GO

INSERT INTO Monasteries VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'),
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--ALTER TABLE Countries
--ADD IsDeleted BIT

--UPDATE Countries
--SET Countries.IsDeleted = 0

UPDATE Countries
SET Countries.IsDeleted = 1
WHERE CountryCode IN (
    SELECT c.CountryCode
        FROM Countries AS c
    JOIN
(
        SELECT
            cr.CountryCode
            , COUNT(cr.RiverId) AS [RiverCount]
            FROM Countries AS c
            JOIN CountriesRivers cr on cr.CountryCode = c.CountryCode
            GROUP BY cr.CountryCode
            ) AS [rivers] ON c.CountryCode = [rivers].CountryCode
        WHERE [RiverCount] > 3
    )

SELECT
    mon.Name
    , c.CountryName AS [Country]
FROM Monasteries AS mon
JOIN Countries c on c.CountryCode = mon.CountryCode
WHERE IsDeleted = 0
ORDER BY mon.Name

-- 14. Monasteries By Continents and Countries

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = 'Myanmar'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Hanga Abbey', CountryCode
FROM Countries
WHERE CountryName = 'Tanzania'

INSERT INTO Monasteries(Name, CountryCode)
SELECT 'Myin-Tin-Daik', CountryCode
FROM Countries
WHERE CountryName = 'Myanmar'

SELECT
    cc.ContinentName
    , c.CountryName
    , COUNT(m.Id) AS [MonasteriesCount]
FROM Countries AS c
LEFT JOIN Continents cc on cc.ContinentCode = c.ContinentCode
LEFT JOIN Monasteries m on m.CountryCode = c.CountryCode
WHERE c.IsDeleted = 0
GROUP BY cc.ContinentName, c.CountryName
ORDER BY MonasteriesCount DESC, c.CountryName
