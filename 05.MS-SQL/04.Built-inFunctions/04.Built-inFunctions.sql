-- Part I - Queries for SoftUni Database

USE SoftUni
GO

-- 01. Find Names of All Employees by First Name

SELECT [FirstName], [LastName]
FROM Employees
--WHERE LEFT(FirstName,2) = 'Sa'
WHERE FirstName LIKE 'Sa%'

-- 02. Find Names of All Employees by Last Name

SELECT [FirstName], [LastName]
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03. Find First Names of All Employees

SELECT [FirstName]
FROM Employees
WHERE
    [DepartmentID] IN (3, 10) AND
    DATEPART(YEAR, [HireDate]) BETWEEN 1995 AND 2005

-- 04. Find All Employees Except Engineers

SELECT [FirstName], [LastName]
FROM Employees
WHERE [JobTitle] NOT LIKE '%engineer%'

-- 05. Find Towns with Name Length

SELECT [Name]
FROM Towns
WHERE
    LEN([Name]) = 5 OR
    LEN([Name]) = 6
ORDER BY [Name]

-- 06. Find Towns Starting With

SELECT *
FROM Towns
WHERE
    [Name] LIKE 'M%' OR
    [Name] LIKE 'K%' OR
    [Name] LIKE 'B%' OR
    [Name] LIKE 'E%'
ORDER BY [Name]

-- 07. Find Towns Not Starting With

SELECT *
FROM Towns
WHERE
    LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

-- 08. Create View Employees Hired After 2000 Year

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE DATEPART(YEAR, [HireDate]) > 2000

-- 09. Length of Last Name

SELECT [FirstName], [LastName]
FROM Employees
WHERE LEN([LastName]) = 5

-- 10. Rank Employees by Salary

SELECT [EmployeeID], [FirstName], [LastName], [Salary],
    DENSE_RANK() OVER
    (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM Employees
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- 11. Find All Employees with Rank 2
SELECT * FROM (
    SELECT [EmployeeID], [FirstName], [LastName], [Salary],
    DENSE_RANK() OVER
    (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
    FROM Employees
)
AS [Selection]
WHERE [Salary] BETWEEN 10000 AND 50000 AND
      [Rank] = 2
ORDER BY [Salary] DESC

-- Part II - Queries for Geography Database

USE Geography
GO

-- 12. Countries Holding 'A' 3 or More Times

SELECT [CountryName], [IsoCode]
FROM Countries
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

-- 13. Mix of Peak and River Names

SELECT [PeakName],  [RiverName],
       LOWER(CONCAT(SUBSTRING([PeakName], 1, LEN([PeakName]) - 1), [RiverName])) AS [Mix]
FROM [Peaks], [Rivers]
WHERE RIGHT([PeakName], 1) = LEFT([RiverName], 1)
ORDER BY [Mix]

-- Part III - Queries for Diablo Database

USE Diablo
GO

-- 14. Games from 2011 and 2012 Year

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

-- 15. User Email Providers

SELECT
    [Username],
    SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email]) - CHARINDEX('@', [Email])) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], [Username]

-- 16. Get Users with IP Address Like Pattern

SELECT [Username], [IpAddress]
FROM Users
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

-- 17. Show All Games with Duration and Part of the Day

SELECT [Name],
       CASE
           WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
           WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
           WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
        END AS [Part of the Day],
        CASE
           WHEN [Duration] BETWEEN 0 AND 3 THEN 'Extra Short'
           WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
           WHEN [Duration] > 6 THEN 'Long'
           WHEN [Duration] IS NULL THEN 'Extra Long'
        END AS [Duration]
FROM Games
ORDER BY [Name], [Duration], [Part of the Day]

-- Part IV - Date Functions Queries

USE Orders
GO

-- 18. Orders Table

SELECT [ProductName], [OrderDate],
       DATEADD(DAY, 3, [OrderDate]) AS [Pay Due],
       DATEADD(MONTH, 1, [OrderDate]) AS [Deliver Due]
FROM Orders

-- 19. People Table

CREATE TABLE [People](
    Id INT IDENTITY(1,1) PRIMARY KEY
    , [Name] VARCHAR(50) NOT NULL
    , Birthdate DATE NOT NULL
)

INSERT INTO People VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT [Name],
       DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years],
       DATEDIFF(MONTH , [Birthdate], GETDATE()) AS [Age in Months],
       DATEDIFF(DAY , [Birthdate], GETDATE()) AS [Age in Days],
       DATEDIFF(MINUTE , [Birthdate], GETDATE()) AS[Age in Minutes]
FROM People

--SELECT DATEADD(MINUTE , 8286787, '2000-12-07')