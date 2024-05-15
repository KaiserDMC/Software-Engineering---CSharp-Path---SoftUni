-- Part I - Queries for Bank Database

-- 01. Create Table Logs

CREATE TABLE Logs(
    LogId INT IDENTITY(1,1) PRIMARY KEY
    , AccountId INT FOREIGN KEY REFERENCES Accounts(Id)
    , OldSum DECIMAL(18,4) NOT NULL
    , NewSum DECIMAL(18,4) NOT NULL
)

CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
    INSERT INTO Logs(AccountId, OldSum, NewSum)
    SELECT i.Id, d.Balance, i.Balance
    FROM inserted AS i
    JOIN deleted AS d ON i.Id = d.Id
    WHERE i.Balance != d.Balance
GO

-- 02. Create Table Emails

CREATE TABLE NotificationEmails(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , Recipient INT FOREIGN KEY REFERENCES Accounts(Id)
    , [Subject] NVARCHAR(255) NOT NULL
    , Body NVARCHAR(255) NOT NULL
)

CREATE TRIGGER tr_NewEmailWhenNewRecordIsInserted
ON Logs AFTER INSERT
AS
    INSERT INTO NotificationEmails(Recipient, [Subject], Body)
    SELECT
            [AccountId]
            , 'Balance change for account: ' + CAST([AccountId] AS NVARCHAR(255))
            , 'On ' + FORMAT(GETDATE(), 'MMM dd yyyy h:mmtt') + ' your balance was changed from '
                  + CAST([OldSum] AS NVARCHAR(255)) + ' to ' + CAST([NewSum] AS NVARCHAR(255)) + '.'
    FROM inserted

-- 03. Deposit Money

CREATE OR ALTER PROCEDURE usp_DepositMoney
(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
    IF(@MoneyAmount > 0.0000)
        UPDATE Accounts
        SET [Balance] += @MoneyAmount
        WHERE [Id] = @AccountId

EXEC usp_DepositMoney 1, -10

-- 04. Withdraw Money Procedure

CREATE OR ALTER PROCEDURE usp_WithdrawMoney
(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
    IF(@MoneyAmount > 0.0000)
        UPDATE Accounts
        SET [Balance] -= @MoneyAmount
        WHERE [Id] = @AccountId

-- 05. Money Transfer

CREATE OR ALTER PROCEDURE usp_TransferMoney
(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS
    BEGIN TRANSACTION

    BEGIN TRY
        EXEC usp_WithdrawMoney @SenderId, @Amount
        EXEC usp_DepositMoney @ReceiverId, @Amount
    END TRY

    BEGIN CATCH
        ROLLBACK
    END CATCH

    COMMIT

EXEC usp_TransferMoney 5, 1, 5000

-- Part II - Queries for Diablo Database

USE Diablo
GO

-- 06. Massive Shopping
DECLARE @userGameID INT = (
    SELECT ug.[Id]
    FROM UsersGames AS ug
    JOIN Users u ON u.Id = ug.UserId
    JOIN Games AS g ON g.[Id] = ug.[GameId]
    WHERE g.[Name] = 'Safflower' AND u.[Username] = 'Stamat'
)

DECLARE @totalItemCost DECIMAL(18,4)

DECLARE @minLevelOne INT = 11
DECLARE @maxLevelOne INT = 12
DECLARE @availablePlayerCash DECIMAL(18,4) = (
    SELECT [Cash]
    FROM UsersGames
    WHERE Id = @userGameID
)

SET @totalItemCost = (
    SELECT SUM(Price)
    FROM Items
    WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
    BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @totalItemCost
    WHERE [Id] = @userGameID

    INSERT INTO UserGameItems
    SELECT [Id], @userGameID
    FROM Items
    WHERE [MinLevel] BETWEEN @minLevelOne AND @maxLevelOne

    COMMIT TRANSACTION
END

DECLARE @minLevelTwo INT = 19
DECLARE @maxLevelTwo INT = 21
SET @availablePlayerCash = (
    SELECT [Cash]
    FROM UsersGames
    WHERE Id = @userGameID
)

SET @totalItemCost = (
    SELECT SUM(Price)
    FROM Items
    WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo
)

IF(@availablePlayerCash >= @totalItemCost)
BEGIN
    BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @totalItemCost
    WHERE [Id] = @userGameID

    INSERT INTO UserGameItems
    SELECT [Id], @userGameID
    FROM Items
    WHERE [MinLevel] BETWEEN @minLevelTwo AND @maxLevelTwo

    COMMIT TRANSACTION
END

SELECT i.[Name] AS [Item Name]
FROM [UserGameItems] AS [ugi]
JOIN Items i ON i.Id = ugi.ItemId
JOIN UsersGames ug on ug.Id = ugi.UserGameId
JOIN Games g on g.Id = ug.GameId
JOIN Users U on u.Id = ug.UserId
WHERE g.[Name] = 'Safflower' AND u.[Username] = 'Stamat'
ORDER BY i.[Name]

-- Part III - Queries for SoftUni Database

USE SoftUni
GO

-- 07. Employees with Three Projects

CREATE OR ALTER PROCEDURE usp_AssignProject
(@employeeId INT, @projectID INT)
AS
    BEGIN TRANSACTION
    DECLARE @projectsForGivenEmployee INT = (
        SELECT COUNT([EmployeeID])
        FROM EmployeesProjects
        WHERE EmployeeID = @employeeId
    )

    IF(@projectsForGivenEmployee >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1);
    END

    INSERT INTO EmployeesProjects VALUES
    (@employeeId, @projectID)

    COMMIT TRANSACTION

-- 09. Delete Employees

CREATE TABLE Deleted_Employees(
    EmployeeId INT IDENTITY PRIMARY KEY
    , FirstName VARCHAR(50)
    , LastName VARCHAR(50)
    , MiddleName VARCHAR(50)
    , JobTitle VARCHAR(50)
    , DepartmentId INT
    , Salary MONEY
)

CREATE OR ALTER TRIGGER tr_OnDeletedEmployee
ON Employees FOR DELETE
AS
    INSERT INTO Deleted_Employees
    SELECT [FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentId], [Salary]
    FROM deleted


