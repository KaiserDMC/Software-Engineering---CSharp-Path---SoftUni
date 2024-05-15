-- Part I - Queries for Gringotts Database

-- 01. Records' Count

SELECT COUNT(*) as Count
FROM WizzardDeposits

-- 02. Longest Magic Wand

SELECT MAX([MagicWandSize]) as [LongestMagicWand]
FROM WizzardDeposits

-- 03. Longest Magic Wand Per Deposit Groups

SELECT
    [DepositGroup]
    , MAX([MagicWandSize]) as [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04. Smallest Deposit Group Per Magic Wand Size

SELECT TOP(2)
    [DepositGroup]
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG([MagicWandSize])

-- 05. Deposits Sum

SELECT
    [DepositGroup]
    , SUM([DepositAmount]) as [TotalSum]
FROM WizzardDeposits
GROUP BY [DepositGroup]

-- 06. Deposits Sum for Ollivander Family

SELECT
    [DepositGroup]
    , SUM([DepositAmount]) as [TotalSum]
FROM WizzardDeposits
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

-- 07. Deposits Filter

SELECT
    [DepositGroup]
    , SUM([DepositAmount]) as [TotalSum]
FROM WizzardDeposits
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

-- 08. Deposit Charge

SELECT
    [DepositGroup]
    , [MagicWandCreator]
    , MIN([DepositCharge]) as [MinDepositCharge]
FROM WizzardDeposits
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator], [DepositGroup]

-- 09. Age Groups

SELECT
    [AgeGroup]
    , COUNT([AgeGroup]) AS [WizardCount]
FROM
(
    SELECT
    CASE
        WHEN [Age] <= 10 THEN '[0-10]'
        WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
        WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
        WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
        WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
        WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
        WHEN [Age] > 60 THEN '[61+]'
    END AS [AgeGroup]
FROM WizzardDeposits
    ) AS [w]
GROUP BY [AgeGroup]

-- 10. First Letter

SELECT
    SUBSTRING([FirstName], 1, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY SUBSTRING([FirstName], 1, 1)
ORDER BY [FirstLetter]

-- 11. Average Interest

SELECT
    [DepositGroup]
    , [IsDepositExpired]
    , AVG([DepositInterest]) AS [AverageInterest]
FROM WizzardDeposits
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired]

-- 12. Rich Wizard, Poor Wizard

SELECT
    SUM(wizz1.DepositAmount - wizz2.DepositAmount) AS [SumDifference]
FROM WizzardDeposits AS [wizz1]
LEFT JOIN WizzardDeposits AS [wizz2] ON wizz1.Id = wizz2.Id - 1

-- Part II - Queries for SoftUni Database

USE SoftUni
GO

-- 13. Departments Total Salaries

SELECT
    [DepartmentID]
    , SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

-- 14. Employees Minimum Salaries

SELECT
    [DepartmentID]
    , MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE [DepartmentID] IN (2, 5, 7) AND
      [HireDate] > '2000-01-01'
GROUP BY [DepartmentID]

-- 15. Employees Average Salaries

SELECT * INTO [TempTable]
FROM Employees
WHERE [Salary] > 30000

DELETE
FROM [TempTable]
WHERE [ManagerID] = 42

UPDATE TempTable
SET [Salary] += 5000
WHERE [DepartmentID] = 1

SELECT
    [DepartmentID]
    , AVG([Salary]) AS [AverageSalary]
FROM TempTable
GROUP BY [DepartmentID]

-- 16. Employees Maximum Salaries

SELECT
    [DepartmentID]
    , MAX([Salary]) AS [MaxSalary]
FROM Employees
GROUP BY [DepartmentID]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000

-- 17. Employees Count Salaries

SELECT
    COUNT([Salary]) AS Count
FROM Employees
WHERE ManagerID IS NULL

-- 18. 3rd Highest Salary

SELECT [DepartmentID]
     , MAX([Salary]) AS [ThirdHighestSalary]
FROM
    (SELECT [DepartmentID]
            , [Salary]
            , DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC ) AS [ThirdHighestSalary]
    FROM Employees
    ) AS [sal]
WHERE ThirdHighestSalary = 3
GROUP BY [DepartmentID]

-- 19. Salary Challenge

SELECT TOP(10)
    FirstName,
    LastName,
    Employees.DepartmentID
FROM Employees
JOIN
(
SELECT
    DepartmentID
    , AVG([Salary]) AS [Average]
FROM Employees
GROUP BY DepartmentID
) as EA
ON Employees.DepartmentID = EA.[DepartmentID]
WHERE [Salary] > [Average]

