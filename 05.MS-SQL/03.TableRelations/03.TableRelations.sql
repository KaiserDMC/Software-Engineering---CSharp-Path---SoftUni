CREATE DATABASE [TableRelations]
GO

USE [TableRelations]
GO

-- 01. One-To-One Relationship

CREATE TABLE [Passports](
    PassportID INT NOT NULL IDENTITY (101,1)
    , PassportNumber VARCHAR(8) NOT NULL
)

ALTER TABLE [Passports]
ADD CONSTRAINT PK_PassportID
PRIMARY KEY (PassportID)

INSERT INTO [Passports] VALUES
    ('N34FG21B'),
    ('K65LO4R7'),
    ('ZE657QP2')

CREATE TABLE [Persons](
    PersonID INT NOT NULL IDENTITY (1,1)
    , FirstName NVARCHAR(50) NOT NULL
    , Salary DECIMAL(18,2) NOT NULL
    , PassportID INT NOT NULL
)

ALTER TABLE [Persons]
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonID)

ALTER TABLE [Persons]
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID)
REFERENCES [Passports](PassportID)

INSERT INTO [Persons] VALUES
('Roberto', 43300.00,102),
('Tom', 56100.00,103),
('Yana', 60200.00,101)

-- 02. One-To-Many Relationship

CREATE TABLE [Manufacturers](
    ManufacturerID INT NOT NULL IDENTITY (1,1)
    , [Name] VARCHAR(50) NOT NULL
    , EstablishedOn DATE NOT NULL
    CONSTRAINT PK_Manufacturers PRIMARY KEY (ManufacturerID)
)

INSERT INTO Manufacturers VALUES
('BMW', '1916-03-07'),
('Tesla', '2003-01-01'),
('Lada', '1966-05-01')

CREATE TABLE [Models](
    ModelID INT NOT NULL IDENTITY(101,1)
    , [Name] VARCHAR(30) NOT NULL
    , ManufacturerID INT NOT NULL
    CONSTRAINT PK_Models PRIMARY KEY (ModelID)
    CONSTRAINT FK_ManufacturerID FOREIGN KEY REFERENCES Manufacturers (ManufacturerID)
)

INSERT INTO [Models] VALUES
('X1',1),
('i6',1),
('Model S',2),
('Model X',2),
('Model 3',2),
('Nova',3)

-- 03. Many-To-Many Relationship

CREATE TABLE [Students](
    StudentID INT NOT NULL IDENTITY(1,1)
    , [Name] NVARCHAR(20) NOT NULL
    CONSTRAINT PK_StudentID PRIMARY KEY (StudentID)
)

INSERT INTO [Students] VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE [Exams](
    ExamID INT NOT NULL IDENTITY(101,1)
    , [Name] NVARCHAR(50) NOT NULL
    CONSTRAINT PK_ExamID PRIMARY KEY (ExamID)
)

INSERT INTO [Exams] VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

CREATE TABLE [StudentsExams](
    StudentID INT NOT NULL FOREIGN KEY REFERENCES Students (StudentID)
    , ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams (ExamID)
    CONSTRAINT PK_StudentExamID PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO [StudentsExams] VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

-- 04. Self-Referencing

CREATE TABLE [Teachers](
    TeacherID INT IDENTITY(101, 1) PRIMARY KEY
    , [Name] VARCHAR(50) NOT NULL
    , ManagerID INT FOREIGN KEY REFERENCES [Teachers](TeacherID)
)

INSERT INTO [Teachers] VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

-- 05. Online Store Database

CREATE TABLE [Cities](
    CityID INT NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    CONSTRAINT PK_CityID PRIMARY KEY (CityID)
)

CREATE TABLE [Customers](
    CustomerID INT NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    , Birthday DATE NOT NULL
    , CityID INT NOT NULL
    CONSTRAINT FK_CityID FOREIGN KEY REFERENCES [Cities](CityID)
    CONSTRAINT PK_CustomerID PRIMARY KEY (CustomerID)
)

CREATE TABLE [Orders](
    OrderID INT NOT NULL
    , CustomerID INT NOT NULL
    CONSTRAINT FK_CustomerID FOREIGN KEY REFERENCES [Customers](CustomerID)
    CONSTRAINT PK_OrderID PRIMARY KEY (OrderID)
)

CREATE TABLE [ItemTypes](
    ItemTypeID INT NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    CONSTRAINT PK_ItemTypeID PRIMARY KEY (ItemTypeID)
)

CREATE TABLE [Items](
    ItemID INT NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    , ItemTypeID INT NOT NULL
    CONSTRAINT FK_ItemTypeID FOREIGN KEY REFERENCES [ItemTypes](ItemTypeID)
    CONSTRAINT PK_ItemID PRIMARY KEY (ItemID)
)

CREATE TABLE [OrderItems](
    OrderID INT NOT NULL FOREIGN KEY REFERENCES [Orders](OrderID)
    , ItemID INT NOT NULL FOREIGN KEY REFERENCES [Items](ItemID)
    CONSTRAINT PK_OrderItems PRIMARY KEY (OrderID, ItemID)
)

-- 06. University Database
CREATE DATABASE [TableRelations2]
GO

USE TableRelations2

CREATE TABLE [Majors](
    MajorID INT NOT NULL
    , [Name] VARCHAR(50) NOT NULL
    CONSTRAINT PK_MajorID PRIMARY KEY (MajorID)
)

CREATE TABLE [Students](
    StudentID INT NOT NULL
    , StudentNumber INT NOT NULL
    , StudentName VARCHAR(50) NOT NULL
    , MajorID INT NOT NULL
    CONSTRAINT FK_MajorID FOREIGN KEY REFERENCES [Majors](MajorID)
    CONSTRAINT PK_StudentID PRIMARY KEY (StudentID)
)

CREATE TABLE [Payments](
    PaymentID INT NOT NULL
    , PaymentDate DATE NOT NULL
    , PaymentAmount DECIMAL(18,2) NOT NULL
    , StudentID INT NOT NULL
    CONSTRAINT FK_StudentID FOREIGN KEY REFERENCES [Students](StudentID)
    CONSTRAINT PK_PaymentID PRIMARY KEY (PaymentID)
)

CREATE TABLE [Subjects](
    SubjectID INT NOT NULL
    , SubjectName VARCHAR(50) NOT NULL
    CONSTRAINT PK_SubjectID PRIMARY KEY (SubjectID)
)

CREATE TABLE [Agenda](
    StudentID INT NOT NULL FOREIGN KEY REFERENCES [Students](StudentID)
    , SubjectID INT NOT NULL FOREIGN KEY REFERENCES [Subjects](SubjectID)
    CONSTRAINT PK_Agenda PRIMARY KEY (StudentID, SubjectID)
)

-- 07. SoftUnit Design

-- 08. Geography Design

-- 09. Peaks in Rila

USE [Geography]
GO

SELECT [MountainRange], [PeakName], [Elevation] FROM [Peaks]
JOIN Mountains ON Mountains.Id = Peaks.MountainId
WHERE MountainRange = 'Rila'
ORDER BY Elevation DESC