-- 01. Create Database

CREATE DATABASE Minions
GO

-- 02. Create Tables
USE Minions
GO

CREATE TABLE Minions
(
    Id INT PRIMARY KEY IDENTITY
    ,
    [Name] VARCHAR
    ,
    Age INT
)

CREATE TABLE Towns
(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY
    ,
    [Name] VARCHAR
)

-- 03. Alter Minions Table

ALTER TABLE Minions
DROP CONSTRAINT FK__Minions__TownId__276EDEB3
GO

ALTER TABLE Minions
DROP COLUMN TownId;

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- 04. Insert Records in Both Tables

SET IDENTITY_INSERT Minions ON
GO

SET IDENTITY_INSERT Towns OFF
GO

INSERT INTO Towns
    (Id, Name)
VALUES
    (1, 'Sofia'),
    (2, 'Plovdiv'),
    (3, 'Varna')

INSERT INTO Minions
VALUES
    (1, 'Kevin', 22 , 1),
    (2, 'Bob', 15, 3),
    (3, 'Steward', NULL, 2)

-- 05. Truncate Table Minions

TRUNCATE TABLE Minions

-- 06. Drop All Tables

DROP TABLE Minions
GO
DROP TABLE Towns

-- 07. Create Table People

CREATE TABLE People
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    ,
    [Name] NVARCHAR(200) NOT NULL
    ,
    Picture IMAGE
    ,
    Height DECIMAL(18,2)
    ,
    [Weight] DECIMAL(18,2)
    ,
    Gender CHAR(1) NOT NULL
        CHECK (Gender = 'm' OR Gender = 'f')
    ,
    Birthdate DATE NOT NULL
    ,
    Biography NVARCHAR(MAX)
)

INSERT INTO People
    ([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
    ('Dido Belqta', 1.78, 90.00, 'm', '1995-02-03', 'THE BEST FRIENDO'),
    ('Bate Toni', 1.80, 80.00, 'm', '2004-06-29', 'THE BEST FRIENDO Numbero du'),
    ('Qze', 1.75, 78.00, 'm', '1993-04-20', 'TUpaka'),
    ('Pesho', 1.75, 78.00, 'm', '2000-05-10', 'ceo'),
    ('Milko', 1.55, 99.00, 'f', '1980-12-20', 'Pilenca pri batko')

-- 08. Create Table Users

CREATE TABLE Users
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    ,
    [Username] VARCHAR(30) NOT NULL
    ,
    [Password] VARCHAR(26) NOT NULL
    ,
    ProfilePicture IMAGE
    ,
    LastLoginTime DATETIME2 NOT NULL
    ,
    IsDeleted BIT NOT NULL
        CHECK (IsDeleted = 0 OR IsDeleted = 1)
)

INSERT INTO Users
    ([Username], [Password], LastLoginTime, IsDeleted)
VALUES
    ('Dido Belqta', 'password', GETDATE(), 0),
    ('Bate Toni', '123456', GETDATE(), 0),
    ('Qze', '11111111111', GETDATE(), 0),
    ('Pesho', 'savemejesus', GETDATE(), 0),
    ('Milko', 'thisisbullshitlol', GETDATE(), 0)

-- 09. Change Primary Key

ALTER TABLE [dbo].[Users] DROP CONSTRAINT [PK__Users__3214EC07C98E3289] WITH ( ONLINE = OFF )
GO

ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [Pk_Composite]
PRIMARY KEY(Id, [Username])

-- 10. Add Check Constriant

ALTER TABLE [Users]
ADD CONSTRAINT Pass_Check
CHECK (LEN([Password]) >= 5)

-- 11. Set Default Value of a Field

ALTER TABLE [Users]
ADD CONSTRAINT df_LoginTime
DEFAULT GETDATE() FOR [LastLoginTime];

-- 12. Set Unique Field

ALTER TABLE [Users]
DROP CONSTRAINT Pk_Composite

ALTER TABLE [Users]
ADD CONSTRAINT Pk_Id_Only
PRIMARY KEY(Id)

ALTER TABLE [Users]
ADD CONSTRAINT Chck_User_Len
CHECK(LEN([Username])>=3)

-- 13. Movies Database

CREATE DATABASE Movies
GO

USE [Movies]
GO

CREATE TABLE Directors
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    ,
    DirectorName VARCHAR(50) NOT NULL
    ,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Directors]
VALUES
    ('Pesho', 'AAA'),
    ('Gosho', 'BBB'),
    ('Milko', 'CCC'),
    ('Sashka', 'DDD'),
    ('Dimitrichko', 'EEE')

CREATE TABLE Genres
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    ,
    GenreName VARCHAR(50) NOT NULL
    ,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Genres]
VALUES
    ('Horror', 'FFFF'),
    ('Thriller', 'DDDDD'),
    ('Comedy', 'AAAAAAAA'),
    ('SitCom', 'DDDDDDD'),
    ('Action', 'bbbb')

CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    ,
    CategoryName VARCHAR(50) NOT NULL
    ,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Categories]
VALUES
    ('A', 'AA'),
    ('B', 'BB'),
    ('C', 'CC'),
    ('D', 'DD'),
    ('E', 'EE')

CREATE TABLE Movies
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , DirectorName VARCHAR(50) NOT NULL
    , DirectorId INT FOREIGN KEY REFERENCES [Directors](Id) NOT NULL
    , CopyrightYear DATE NOT NULL
    , Lenght TIME NOT NULL
    , GenreId INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
    , CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
    , Rating DECIMAL(18,2) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Movies]
VALUES
    ('A', 1, '1999-01-01', '01:12:00', 2, 3, 8.0, NULL),
    ('B', 2, '1999-01-01', '02:22:00', 3, 4, 7.5, NULL),
    ('C', 3, '2000-01-01', '03:32:00', 4, 5, 7.0, NULL),
    ('D', 4, '2010-01-01', '04:42:00', 5, 5, 6.0, NULL),
    ('E', 5, '1989-01-01', '05:52:00', 1, 2, 5.5, NULL)

-- 14. Car Rental Database

CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

CREATE TABLE Categories
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , CategoryName VARCHAR(50) NOT NULL
    , DailyRate DECIMAL(18,2) NOT NULL
    , WeeklyRate DECIMAL(18,2) NOT NULL
    , MonthlyRate DECIMAL(18,2) NOT NULL
    , WeekendRate DECIMAL(18,2) NOT NULL
)

INSERT INTO [Categories]
VALUES
    ('A', 10.0, 20.0, 30.0, 40.0),
    ('B', 10.0, 20.0, 30.0, 40.0),
    ('C', 10.0, 20.0, 30.0, 40.0)

CREATE TABLE Cars
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , PlateNumer NVARCHAR(50) NOT NULL
    , Manufacturer NVARCHAR(50) NOT NULL
    , Model NVARCHAR(50) NOT NULL
    , CarYear DATE NOT NULL
    , CategoryId INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
    , DOORS INT
    , Picture IMAGE 
    , Condition NVARCHAR(50) NOT NULL
    , Available BIT NOT NULL
    CHECK ([Available]=0 OR [Available]=1)
)

INSERT INTO [Cars]
    ([PlateNumer], [Manufacturer], [Model],[CarYear],[CategoryId],[Condition],[Available])
VALUES
    ('CA2020AA', 'BMW', 'M3', '1993-01-01', 1, 'UsedBrakma', 1),
    ('PK2020PK', 'Audi', 'A3', '2000-01-01', 2, 'LessUsedBrakma', 1),
    ('B2020DD', 'Mercedes', 'A Class', '2010-01-01', 3, 'LeastUsedBrakma', 0)

CREATE TABLE Employees
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , FirstName VARCHAR(50) NOT NULL
    , LastName VARCHAR(50) NOT NULL
    , Title VARCHAR(100) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Employees]
VALUES
    ('Gosho', 'Petkanov', 'Shefche', NULL),
    ('Milko', 'Dimitrichkov', 'Debilche', NULL),
    ('Bate', 'Toni', 'SoftUniTO', 'Pichaga :D')

CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , DriverLicenseNumber NVARCHAR(20) NOT NULL
    , FullName VARCHAR(50) NOT NULL
    , [Address] NVARCHAR(200) NOT NULL
    , City NVARCHAR(50) NOT NULL
    , ZIPCode INT NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Customers]
    ([DriverLicenseNumber], [FullName],[Address], [City], [ZIPCode])
VALUES
    ('1231314', 'Gosho Petkanov', 'Ulica' , 'Sofia', 1309),
    ('ajkdh10e1', 'Dimitrichka Georgieva', 'Bulevard' , 'Varna', 9000),
    ('jaskdj8912', 'Pesho TUpaka', 'Jitnica' , 'Petrich', 4510)

CREATE TABLE RentalOrders
(
    Id INT IDENTITY(1,1) PRIMARY KEY
    , EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL
    , CustomerId INT FOREIGN KEY REFERENCES [Customers](Id) NOT NULL
    , CarId INT FOREIGN KEY REFERENCES [Cars](Id) NOT NULL
    , TankLevel INT DEFAULT 30
    , KilometrageStart INT NOT NULL
    , KilometrageEnd INT NOT NULL
    , TotalKilometrage INT NOT NULL
    , StartDate DATE NOT NULL
    , EndDate DATE NOT NULL
    , TotalDays INT NOT NULL
    , RateApplied DECIMAL(18,2) NOT NULL
    , TaxRate DECIMAL(18,2) NOT NULL
    , OrderStatus VARCHAR(20) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]
VALUES
    (1, 3, 2, 100, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending', NULL),
    (2, 1, 1, 90, 190000, 190500, 500, '1994-01-01', '1994-01-21', 20, 50.0, 10.0, 'Pending', NULL),
    (3, 2, 3, 50, 20000, 25000, 5000, '2020-10-01', '2022-12-01', 100, 50.0, 10.0, 'Approved', NULL)

-- 15. Hotel Database

CREATE DATABASE [Hotel]
GO

USE [Hotel]
GO

CREATE TABLE Employees
(
    Id INT IDENTITY PRIMARY KEY
    , FirstName VARCHAR(50) NOT NULL
    , LastName VARCHAR(50) NOT NULL
    , Title NVARCHAR(30) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Employees]
VALUES
    ('Gosho', 'Petkanov', 'Shefche', NULL),
    ('Milko', 'Dimitrichkov', 'Debilche', NULL),
    ('Bate', 'Toni', 'SoftUniTO', 'Pichaga :D')

CREATE TABLE Customers
(
    Id INT IDENTITY(1,1) 
    , AccountNumber NVARCHAR(20) NOT NULL PRIMARY KEY
    , FirstName VARCHAR(50) NOT NULL
    , LastName VARCHAR(50) NOT NULL
    , PhoneNumber INT NOT NULL
    , EmergencyName VARCHAR(50) NOT NULL
    , EmergencyPhone INT NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Customers]
VALUES
    ('ahdahdahdha', 'Gosho', 'Petkov', 2313, 'Grisho', 13719478, NULL),
    ('jdkljgoru', 'Ivan', 'Draganov', 14141, 'Petko', 123214515, NULL),
    ('tewtwr', 'Petkan', 'Ivanov', 25255, 'Zayo', 1423, NULL)

CREATE TABLE RoomStatus
(
    RoomStatus VARCHAR(50) NOT NULL PRIMARY KEY
    , Notes NVARCHAR(MAX)
)

INSERT INTO [RoomStatus]
VALUES
    ('Occupied', NULL),
    ('Free', NULL),
    ('Reserved', NULL)

CREATE TABLE RoomTypes
(
    RoomType VARCHAR(50) NOT NULL PRIMARY KEY
    , Notes NVARCHAR(MAX)
)

INSERT INTO [RoomTypes]
VALUES
    ('Double', NULL),
    ('Single', NULL),
    ('Apartment', NULL)

CREATE TABLE BedTypes
(
    BedType VARCHAR(50) NOT NULL PRIMARY KEY
    , Notes NVARCHAR(MAX)
)

INSERT INTO [BedTypes]
VALUES
    ('King Size', NULL),
    ('Single Bed', NULL),
    ('Double Bed', NULL)

CREATE TABLE Rooms
(
    RoomNumber INT NOT NULL PRIMARY KEY IDENTITY
    , RoomType VARCHAR(50) FOREIGN KEY REFERENCES [RoomTypes](RoomType) NOT NULL
    , BedType VARCHAR(50) FOREIGN KEY REFERENCES [BedTypes](BedType) NOT NULL
    , Rate INT NOT NULL
    , RoomStatus VARCHAR(50) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Rooms]
VALUES
    ('Double', 'King Size', 5, 'Free', NULL),
    ('Single', 'Single Bed', 2, 'Reserved', NULL),
    ('Apartment', 'Double Bed', 7, 'Occupied', NULL)

CREATE TABLE Payments
(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL
    , PaymentDate DATE NOT NULL
    , AccountNumber NVARCHAR(20) FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL
    , FirstDateOccupied DATE NOT NULL
    , LastDateOccupied DATE NOT NULL
    , TotalDays INT NOT NULL
    , AmountCharged DECIMAL(18,2) NOT NULL
    , TaxRate DECIMAL(18,2) NOT NULL
    , TaxAmount DECIMAL(18,2) NOT NULL
    , PaymentTotal DECIMAL(18,2) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Payments]
VALUES
    (1, '2023-01-01', 'ahdahdahdha', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL),
    (2, '2023-01-01', 'jdkljgoru', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL),
    (3, '2023-01-01', 'tewtwr', '2023-01-02', '2023-01-05', 4, 100.0, 20.0, 50.0, 1000.0, NULL)

CREATE TABLE Occupancies(
    Id INT IDENTITY PRIMARY KEY NOT NULL
    , EmployeeId INT FOREIGN KEY REFERENCES [Employees](Id) NOT NULL
    , DateOccupied DATE NOT NULL
    , AccountNumber NVARCHAR(20) FOREIGN KEY REFERENCES [Customers](AccountNumber) NOT NULL
    , RoomNumber INT FOREIGN KEY REFERENCES [Rooms](RoomNumber) NOT NULL
    , RateApplied DECIMAL(18,2) NOT NULL
    , PhoneCharge DECIMAL(18,2) NOT NULL
    , Notes NVARCHAR(MAX)
)

INSERT INTO [Occupancies]
VALUES
(1,'2023-01-01', 'ahdahdahdha', 1, 20.0, 10.0, NULL),
(2,'2023-01-01', 'jdkljgoru', 2, 20.0, 10.0, NULL),
(3,'2023-01-01', 'tewtwr', 3, 20.0, 10.0, NULL)

-- 16. Create SoftUni Database

ALTER DATABASE [SoftUni] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE [SoftUni]
GO

CREATE DATABASE [SoftUni]
GO

USE [SoftUni]
GO

CREATE TABLE Towns(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL
    , [Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL
    , AddressText NVARCHAR(250) NOT NULL
    , TownId INT FOREIGN KEY REFERENCES [Towns](Id) NOT NULL
)

CREATE TABLE Departments(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL
    , [Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL
    , FirstName NVARCHAR(50) NOT NULL
    , MiddleName NVARCHAR(50) NOT NULL
    , LastName NVARCHAR(50) NOT NULL
    , JobTitle NVARCHAR(50) NOT NULL
    , DepartmentId INT FOREIGN KEY REFERENCES [Departments](Id) NOT NULL
    , HireDate DATE NOT NULL
    , Salary DECIMAL(18,2) NOT NULL
    , AddressId INT NOT NULL
)

-- 17. Backup Database

-- 18. Basic Insert
-- TRUNCATE TABLE [Towns]

INSERT INTO [Towns]
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 1, '2013-02-01', 3500.0, 5),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 2, '2004-03-02', 4000.0, 4),
('Maria', 'Petrova', 'Ivanova', 'Intern', 3, '2016-08-28', 525.25, 3),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 4, '2007-12-09', 3000.0, 2),
('Peter', 'Pan', 'Pan', 'Intern', 5, '2016-08-28', 599.88, 1)

-- 19. Basic Select All Fields

SELECT * FROM [Towns]
SELECT * FROM [Departments]
SELECT * FROM [Employees]

-- 20. Basic Select All Fields and Order Them

SELECT * FROM [Towns] ORDER BY [Name]
SELECT * FROM [Departments] ORDER BY [Name]
SELECT * FROM [Employees] ORDER BY [Salary] DESC

-- 21. Basic Select Some Fields

SELECT [Name] FROM [Towns] ORDER BY [Name]
SELECT [Name] FROM [Departments] ORDER BY [Name]
SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary] DESC

-- 22. Increase Employees Salary

UPDATE [Employees]
SET [Salary] *=1.1

SELECT [Salary] FROM [Employees]

-- 23. Decrease Tax Rate

USE [Hotel]

UPDATE [Payments]
SET [TaxRate] *=0.97

SELECT [TaxRate] FROM [Payments]

-- 24. Delete All Records

TRUNCATE TABLE [Occupancies]