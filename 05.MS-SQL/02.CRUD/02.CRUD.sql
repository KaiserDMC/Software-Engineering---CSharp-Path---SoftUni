-- Part I - Queries for SoftUni Database

-- 01. Examine the Databases

-- 02. Find All the Information About Departments

SELECT * FROM [Departments]

-- 03. Find all Department Names

SELECT [Name] FROM [Departments]

-- 04. Find Salary of Each Employee

SELECT [FirstName], [LastName], [Salary] 
FROM [Employees]

-- 05. Find Full Name of Each Employee

SELECT [FirstName], [MiddleName], [LastName] 
FROM [Employees]

-- 06. Find Email Address of Each Employee

SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address]
FROM [Employees]

-- 07. Find All Different Employees' Salaries

SELECT DISTINCT [Salary] AS Salary
FROM [Employees]

-- 08. Find All Information About Employees

SELECT * FROM [Employees]
WHERE JobTitle = 'Sales Representative'

-- 09. Find Names of All Employees by Salary in Range

SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees]
WHERE Salary BETWEEN 20000 AND 30000

-- 10. Find Names of All Employees

SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [Full Name]
FROM [Employees]
WHERE Salary IN (12500, 14000, 23600, 25000)

-- 11. Find All Employees Without a Manager

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [ManagerID] IS NULL

-- 12. Find All Employees with a Salary More Than 50000

SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE Salary > 50000
ORDER BY Salary DESC

-- 13. Find 5 Best Paid Employees

SELECT TOP(5) [FirstName], [LastName]
FROM [Employees]
ORDER BY Salary DESC

-- 14. Find All Employees Except Marketing

SELECT [FirstName], [LastName]
FROM [Employees]
WHERE DepartmentID NOT IN (4)

-- 15. Sort Employees Table

SELECT * FROM [Employees]
ORDER BY Salary DESC, FirstName, LastName DESC, MiddleName 

-- 16. Create View Employees with Salaries

CREATE VIEW V_EmployeesSalaries AS 
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]

-- 17. Create View Employees with Job Titles

CREATE VIEW V_EmployeeNameJobTitle AS 
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS [Full Name], JobTitle
FROM [Employees]

-- 18. Distinct Job Titles

SELECT DISTINCT [JobTitle]
FROM dbo.[Employees]

-- 19. Find First 10 Started Projects

SELECT TOP(10) * FROM [Projects]
ORDER BY [StartDate], [Name]

-- 20. Last 7 Hired Employees

SELECT TOP(7) [FirstName], [LastName], [HireDate]
FROM [Employees]
ORDER BY HireDate DESC

-- 21. Increase Salaries

UPDATE [Employees]
SET [Salary] *=1.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]

--ROLLBACK
UPDATE [Employees]
SET [Salary] /=1.12

-- Part II - Queries for SoftUni Database

-- 22. All Mountain Peaks

USE [Geography]

SELECT [PeakName] FROM Peaks
ORDER BY PeakName 

-- 23. Biggest Countries by Population

SELECT TOP(30) [CountryName], [Population]
FROM [Countries]
WHERE ContinentCode =  'EU'
ORDER BY [Population] DESC, [CountryName]

-- 24. Countries and Currency (Euro / Not Euro)

SELECT [CountryName], [CountryCode],
    CASE
        WHEN CurrencyCode = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END AS [Currency]
 FROM [Countries]
 ORDER BY [CountryName]

-- Part III - Queries for Diablo Database

-- 25. All Diablo Characters

USE [Diablo]

SELECT [Name]
FROM [Characters]
ORDER BY [Name]