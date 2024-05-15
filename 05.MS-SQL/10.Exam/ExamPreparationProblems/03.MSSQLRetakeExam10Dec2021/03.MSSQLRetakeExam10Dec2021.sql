-- Section 1. DDL

CREATE DATABASE Airport
GO

-- 01. Database design

USE Airport
GO

CREATE TABLE Passengers(
    Id INT PRIMARY KEY IDENTITY
    , FullName VARCHAR(100) UNIQUE NOT NULL
    , Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots(
    Id INT PRIMARY KEY IDENTITY
    , FirstName VARCHAR(30) UNIQUE NOT NULL
    , LastName VARCHAR(30) UNIQUE NOT NULL
    , Age TINYINT NOT NULL
    CHECK (Age BETWEEN 21 AND 62)
    , Rating FLOAT
    CHECK (Rating BETWEEN 0.0 AND 10.0)
)

CREATE TABLE AircraftTypes(
    Id INT PRIMARY KEY IDENTITY
    , TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft(
    Id INT PRIMARY KEY IDENTITY
    , Manufacturer VARCHAR(25) NOT NULL
    , Model VARCHAR(30) NOT NULL
    , [Year] INT NOT NULL
    , FlightHours INT
    , [Condition] CHAR(1) NOT NULL
    , TypeId INT NOT NULL FOREIGN KEY REFERENCES AircraftTypes(Id)
)

CREATE TABLE PilotsAircraft(
    AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id)
    , PilotId INT NOT NULL FOREIGN KEY REFERENCES Pilots(Id)
    PRIMARY KEY (AircraftId, PilotId)
)

CREATE TABLE Airports(
    Id INT PRIMARY KEY IDENTITY
    , AirportName VARCHAR(70) UNIQUE NOT NULL
    , Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations(
    Id INT PRIMARY KEY IDENTITY
    , AirportId INT NOT NULL FOREIGN KEY REFERENCES Airports(Id)
    , [Start] DATETIME NOT NULL
    , AircraftId INT NOT NULL FOREIGN KEY REFERENCES Aircraft(Id)
    , PassengerId INT NOT NULL FOREIGN KEY REFERENCES Passengers(Id)
    , TicketPrice DECIMAL(18,2) NOT NULL DEFAULT 15
)

-- Section 2. DML

-- 02. Insert

INSERT INTO Passengers(FullName, Email)
SELECT
    CONCAT(FirstName, ' ', LastName)
    , CONCAT(FirstName, LastName, '@gmail.com')
FROM Pilots
WHERE Id BETWEEN 5 AND 15

-- 03. Update

UPDATE Aircraft
SET [Condition] = 'A'
WHERE [Condition] IN ('C', 'B') AND
      (FlightHours IS NULL OR Aircraft.FlightHours <= 100) AND
      [Year] >= 2013

-- 04. Delete

DELETE Passengers
WHERE LEN(FullName) <= 10

-- Section 3. Querying

-- 05. Aircraft

SELECT
    Manufacturer
    , Model
    , FlightHours
    , [Condition]
FROM Aircraft
ORDER BY FlightHours DESC

-- 06. Pilots and Aircraft

SELECT
    p.FirstName
    , p.LastName
    , a.Manufacturer
    , a.Model
    , a.FlightHours
FROM Pilots AS p
JOIN PilotsAircraft AS pa ON PA.PilotId = p.Id
JOIN Aircraft AS a ON a.Id = pa.AircraftId
WHERE (a.FlightHours IS NOT NULL AND a.FlightHours < 304)
ORDER BY FlightHours DESC, FirstName

-- 07. Top 20 Flight Destinations

SELECT TOP(20)
    fd.Id AS [DestinationId]
    , IIF(DATEPART(DAY, fd.[Start]) % 2 = 0, fd.[Start], NULL) AS [StartA]
    , p.FullName
    , a.AirportName
    , fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p ON p.Id = fd.PassengerId
JOIN Airports AS a ON a.Id = fd.AirportId
WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName

-- 08. Number of Flights for Each Aircraft

SELECT
    a.Id AS [AircraftId]
    , a.Manufacturer
    , a.FlightHours
    , COUNT(fd.Id) AS [FlightDestinationsCount]
    , ROUND(AVG(fd.TicketPrice), 2) AS [AvgPrice]
FROM Aircraft AS a
LEFT JOIN FlightDestinations AS fd ON fd.AircraftId = a.Id
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY FlightDestinationsCount DESC, AircraftId

-- 09. Regular Passengers

SELECT
    p.FullName
    , COUNT(a.Id) AS [CountOfAircraft]
    , SUM(fd.TicketPrice) AS [TotalPayed]
FROM Passengers AS p
JOIN FlightDestinations AS fd ON fd.PassengerId = p.Id
JOIN Aircraft AS a ON a.Id = fd.AircraftId
GROUP BY p.FullName
HAVING SUBSTRING(p.FullName, 2, 1) = 'a' AND
      COUNT(a.Id) > 1
ORDER BY p.FullName

-- 10. Full Info for Flight Destinations

SELECT
    a.AirportName
    , fd.[Start]
    , fd.TicketPrice
    , p.FullName
    , ac.Manufacturer
    , ac.Model
FROM FlightDestinations AS fd
JOIN Passengers AS p ON p.Id = fd.PassengerId
JOIN Airports AS a ON a.Id = fd.AirportId
JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
WHERE (DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20) AND
      fd.TicketPrice > 2500
ORDER BY ac.Model

-- Section 4. Programmability

-- 11. Find all Destinations by Email Address

CREATE OR ALTER FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
BEGIN
    DECLARE @passengerID INT = (
        SELECT
            Id
        FROM Passengers
        WHERE Email = @email
)

    RETURN (
        SELECT
            COUNT(Id)
        FROM FlightDestinations
        WHERE PassengerId = @passengerID
    )

END

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

-- 12. Full Info for Airports

CREATE OR ALTER PROCEDURE usp_SearchByAirportName
(@airportName VARCHAR(70))
AS
    BEGIN
        DECLARE @airportID INT = (
            SELECT
                Id
            FROM Airports
            WHERE AirportName = @airportName
)
        SELECT
            a.AirportName
            , p.FullName
            , CASE
               WHEN fd.TicketPrice <= 400 THEN 'Low'
               WHEN fd.TicketPrice <= 1500 THEN 'Medium'
               WHEN fd.TicketPrice > 1500 THEN 'High'
            END AS [LevelOfTicketPrice]
            , ac.Manufacturer
            , ac.Condition
            , at.TypeName
        FROM Airports AS a
        JOIN FlightDestinations AS fd ON a.Id = fd.AirportId
        JOIN Passengers AS p ON p.Id = fd.PassengerId
        JOIN Aircraft AS ac ON ac.Id = fd.AircraftId
        JOIN AircraftTypes AS at ON at.Id = ac.TypeId
        WHERE a.Id = @airportID
        ORDER BY ac.Manufacturer, p.FullName

    END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'