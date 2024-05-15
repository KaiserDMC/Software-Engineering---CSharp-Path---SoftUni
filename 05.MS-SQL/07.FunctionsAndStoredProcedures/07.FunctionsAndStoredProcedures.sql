-- Part I - Queries for SoftUni Database

-- 01. Employees with Salary Above 35000

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000
AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE [Salary] > 35000

EXEC usp_GetEmployeesSalaryAbove35000

-- 02. Employees with Salary Above Number

CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber
(@number DECIMAL(18,4))
AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE [Salary] >= @number

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- 03. Town Names Starting With

CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith
(@initialString VARCHAR(50))
AS
SELECT [Name]
FROM Towns
WHERE SUBSTRING([Name], 1, LEN(@initialString)) = @initialString

EXEC usp_GetTownsStartingWith b

-- 04. Employees from Town

CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown
(@townName VARCHAR(50))
AS
SELECT [FirstName], [LastName]
FROM Employees AS e
JOIN Addresses AS a ON a.AddressID = e.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
WHERE t.[Name] = @townName

EXEC usp_GetEmployeesFromTown Sofia

-- 05. Salary Lever Function

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
BEGIN
    DECLARE @salaryLevel VARCHAR(20)

    IF(@salary < 30000)
        SET @salaryLevel = 'Low'
    ELSE IF (@salary BETWEEN 30000 AND 50000)
        SET @salaryLevel = 'Average'
    ELSE
        SET @salaryLevel = 'High'
RETURN @salaryLevel
END;

SELECT [FirstName]
     , [LastName]
     , [Salary]
     , dbo.ufn_GetSalaryLevel([Salary]) AS [Salary Level]
  FROM Employees

-- 06. Employees by Salary Level

CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel
(@salLevel VARCHAR(20))
AS
SELECT [FirstName], [LastName]
FROM Employees
WHERE dbo.ufn_GetSalaryLevel([Salary]) = @salLevel

EXEC usp_EmployeesBySalaryLevel High

-- 07. Define Function

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(30), @word NVARCHAR(30))
RETURNS BIT
BEGIN
    DECLARE @index INT = 1
    DECLARE @letter CHAR(1)

    WHILE (@index <= LEN(@word))
    BEGIN
        SET @letter = SUBSTRING(@word, @index, 1)
        IF(CHARINDEX(@letter, @setOfLetters) > 0)
            SET @index +=1
        ELSE
           RETURN 0
    END
    RETURN 1
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')

-- 08. Delete Employees and Departments

CREATE OR ALTER PROCEDURE usp_DeleteEmployeesFromDepartment
(@departmentId INT)
AS
BEGIN
    ALTER TABLE Departments
    ALTER COLUMN [ManagerID] INT NULL

    DELETE FROM EmployeesProjects
    WHERE [EmployeeID] IN (
        SELECT [EmployeeID]
        FROM Employees
        WHERE [DepartmentID] = @departmentId
        )

    UPDATE Employees
    SET [ManagerID] = NULL
    WHERE [ManagerID] IN (
        SELECT [EmployeeID]
        FROM Employees
        WHERE [DepartmentID] = @departmentId
        )

    UPDATE Departments
    SET [ManagerID] = NULL
    WHERE [DepartmentID] = @departmentId

    DELETE FROM Employees
    WHERE [DepartmentID] = @departmentId

    DELETE FROM Departments
    WHERE [DepartmentID] = @departmentId

    SELECT COUNT(*) FROM Employees
    WHERE [DepartmentID] = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 3

-- Part II - Queries for Bank Database

USE Bank
GO

-- 09. Find Full Name

CREATE OR ALTER PROCEDURE usp_GetHoldersFullName
AS
SELECT
    CONCAT([FirstName], ' ', [LastName])
FROM AccountHolders

EXEC usp_GetHoldersFullName

-- 10. People with Balance Higher Than

CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan
(@balance DECIMAL(18,4))
AS
SELECT [FirstName], [LastName]
FROM AccountHolders AS ah
JOIN (SELECT [AccountHolderId],
             SUM([Balance]) AS [TotalBalance]
      FROM Accounts
      GROUP BY [AccountHolderId]
) AS a
ON ah.[Id] = a.[AccountHolderId]
WHERE a.[TotalBalance] > @balance
ORDER BY ah.[FirstName], ah.[LastName]

EXEC usp_GetHoldersWithBalanceHigherThan 200

-- 11. Future Value Function

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18,4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18,4)
BEGIN
    DECLARE @futureValue DECIMAL(18,4)

    SET @futureValue = @sum * (POWER(1+@yearlyInterestRate, @years))

    RETURN @futureValue
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- 12. Calculating Interest

CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount
(@accountId INT, @interestRate FLOAT)
AS
SELECT
    a.[AccountHolderId] AS [Account Id]
    , ah.[FirstName] AS [First Name]
    , ah.[LastName] AS [Last Name]
    , a.[Balance] AS [Current Balance]
    , dbo.ufn_CalculateFutureValue(a.[Balance], @interestRate, 5) AS [Balance in 5 years]
FROM Accounts AS a
JOIN AccountHolders AS ah ON a.[AccountHolderId] = ah.[Id]
WHERE a.[Id] = @accountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1

-- Part III - Queries for Diablo Database

USE Diablo
GO

-- 13. Scalar Function: Cash in User Games Odd Rows

CREATE OR ALTER FUNCTION ufn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS TABLE
AS
RETURN SELECT
    SUM([Cash]) AS [SumCash]
FROM
(
    SELECT
            ug.[GameId]
           , ug.[Cash]
           , ROW_NUMBER() OVER(ORDER BY ug.[Cash] DESC) AS [NumberOfRow]
    FROM UsersGames AS ug
    JOIN Games AS g ON g.[Id] = ug.[GameId]
    WHERE g.[Name] = @gameName
    GROUP BY ug.[GameId], ug.[Cash]
) AS tab
WHERE tab.[NumberOfRow] % 2 = 1

SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')

