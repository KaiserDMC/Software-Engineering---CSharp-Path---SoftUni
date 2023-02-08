-- Section 1. DDL

CREATE DATABASE Zoo
GO

USE Zoo
GO

-- 01. Database design

CREATE TABLE Owners(
    Id INT PRIMARY KEY IDENTITY
    , [Name] VARCHAR(50) NOT NULL
    , PhoneNumber VARCHAR(15) NOT NULL
    , [Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
    Id INT PRIMARY KEY IDENTITY
    , AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
    Id INT PRIMARY KEY IDENTITY
    , AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE Animals(
    Id INT PRIMARY KEY IDENTITY
    , [Name] VARCHAR(30) NOT NULL
    , BirthDate DATE NOT NULL
    , OwnerId INT FOREIGN KEY REFERENCES Owners(Id)
    , AnimalTypeId INT NOT NULL FOREIGN KEY REFERENCES AnimalTypes(Id)
)

CREATE TABLE AnimalsCages(
    CageId INT NOT NULL FOREIGN KEY REFERENCES Cages(Id)
    , AnimalId INT NOT NULL FOREIGN KEY REFERENCES Animals(Id)
    PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
    Id INT PRIMARY KEY IDENTITY
    , DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
    Id INT PRIMARY KEY IDENTITY
    , [Name] VARCHAR(50) NOT NULL
    , PhoneNumber VARCHAR(15) NOT NULL
    , [Address] VARCHAR(50)
    , AnimalId INT FOREIGN KEY REFERENCES Animals(Id)
    , DepartmentId INT NOT NULL FOREIGN KEY REFERENCES VolunteersDepartments(Id)
)

-- Section 2. DML

-- 02. Insert

INSERT INTO Volunteers VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', NULL, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', NULL, 31, 5)

INSERT INTO Animals VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', NULL, 1),
('Tuatara', '2021-06-30', 2, 4)

-- 03. Update

UPDATE Animals
SET OwnerId = (
    SELECT Id
    FROM Owners
    WHERE [Name] = 'Kaloqn Stoqnov'
    )
WHERE OwnerId IS NULL

-- 04. Delete

DECLARE @departmentToDelete INT = (
    SELECT Id
    FROM VolunteersDepartments
    WHERE DepartmentName = 'Education program assistant'
)

DELETE Volunteers
WHERE DepartmentId = @departmentToDelete

DELETE FROM VolunteersDepartments
WHERE Id = @departmentToDelete

-- Section 3. Querying

-- 05. Volunteers

SELECT
    [Name]
    , PhoneNumber
    , [Address]
    , AnimalId
    , DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

-- 06. Animals data

SELECT
    a.[Name]
    , at.AnimalType
    , FORMAT(a.BirthDate, 'dd.MM.yyyy') AS [BirthDate]
FROM Animals AS a
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
ORDER BY a.[Name]

-- 07. Owners and Their Animals

SELECT TOP(5)
    o.[Name]
    , COUNT(a.Id) AS [CountOfAnimals]
FROM Owners AS o
LEFT JOIN Animals AS a ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC, o.[Name]

-- 08. Owners, Animals and Cages

SELECT
    CONCAT(o.[Name], '-', a.[Name]) AS [OwnersAnimals]
    , o.PhoneNumber
    , c.Id AS [CageId]
FROM Owners AS o
JOIN Animals AS a ON a.OwnerId = o.Id
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
JOIN AnimalsCages AS ac ON  ac.AnimalId = a.Id
JOIN Cages AS c ON c.Id = ac.CageId
WHERE at.AnimalType = 'Mammals'
ORDER BY o.[Name], a.[Name] DESC

-- 09. Volunteers in Sofia

SELECT
    v.[Name]
    , v.PhoneNumber
    , SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 2, LEN(v.[Address])) AS [Address]
FROM Volunteers AS v
JOIN VolunteersDepartments AS vd ON vd.Id = v.DepartmentId
WHERE v.[Address] LIKE '%Sofia%' AND
      vd.DepartmentName = 'Education program assistant'
ORDER BY v.[Name]

-- 10. Animals for Adoption

SELECT
    a.[Name]
    , DATEPART(YEAR, a.BirthDate) AS [BirthYear]
    , at.AnimalType AS [AnimalType]
FROM Animals AS a
JOIN Owners AS o ON o.Id = a.OwnerId
JOIN AnimalTypes AS at ON at.Id = a.AnimalTypeId
WHERE a.BirthDate >= '2018-01-01' AND
      at.AnimalType <> 'Birds'
ORDER BY a.[Name]

-- Section 4. Programmability

-- 11. All Volunteers in a Department

CREATE OR ALTER FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
BEGIN
    DECLARE @departmentID INT = (
        SELECT Id
        FROM VolunteersDepartments
        WHERE DepartmentName = @VolunteersDepartment
    )

    RETURN (
        SELECT COUNT(*)
        FROM Volunteers
        WHERE DepartmentId = @departmentID
    )
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

CREATE OR ALTER PROCEDURE usp_AnimalsWithOwnersOrNot
(@animalName VARCHAR(30))
AS
BEGIN
    DECLARE @ownerId INT = (
        SELECT OwnerId
        FROM Animals
        WHERE [Name] = @animalName
    )

    SELECT
        a.[Name] AS [Name]
        ,IIF(@ownerId IS NOT NULL, o.[Name], 'For adoption') AS [OwnersName]
    FROM Animals AS a
    LEFT JOIN Owners AS o on o.Id = a.OwnerId
    WHERE a.[Name] = @animalName

END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'