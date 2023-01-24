/*============================================================================
	File:		ManyIndices.sql

	Summary:	The script demonstrates what is the effect on the DML operations
				when there are a lot of indexes on the table.

				THIS SCRIPT IS PART OF THE Lecture: 
				"Performance Tuning" for SoftUni, Sofia;
				"Joins, Subqueries, CTE and Indices"

	Date:		February 2015, January 2017

	SQL Server Version: 2008 / 2012 / 2014 / 2016
------------------------------------------------------------------------------
	Written by Boris Hristov, SQL Server MVP

	This script is intended only as a supplement to demos and lectures
	given by SoftUni Team.  
  
	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF 
	ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED 
	TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
	PARTICULAR PURPOSE.
============================================================================*/

USE tempdb
GO
-- Create Table
CREATE TABLE FirstIndex (ID INT, 
						FirstName VARCHAR(100), 
						LastName VARCHAR(100), 
						City VARCHAR(100))
GO
-- Insert One Hundred Thousand Records
-- INSERT 1
INSERT INTO FirstIndex (ID,FirstName,LastName,City)
SELECT TOP 100000 ROW_NUMBER() OVER (ORDER BY a.name) RowID, 
					'Bob', 
					CASE WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%2 = 1 THEN 'Smith' 
					ELSE 'Brown' END,
					CASE WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'New York' 
						WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'San Marino' 
						WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Los Angeles' 
					ELSE 'Houston' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO
-- Truncate Table
TRUNCATE TABLE FirstIndex
GO
-- Create 10 indexes
CREATE NONCLUSTERED INDEX [IX_FirstIndex_ID] ON [dbo].[FirstIndex] 
(
	[ID] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_FirstName] ON [dbo].[FirstIndex] 
(
	[FirstName] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_LastName] ON [dbo].[FirstIndex] 
(
	[LastName] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_City] ON [dbo].[FirstIndex] 
(
	[City] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_ID_FirstName] ON [dbo].[FirstIndex] 
(
	[ID] ASC,
	[FirstName] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_ID_LastName] ON [dbo].[FirstIndex] 
(
	[ID] ASC,
	[LastName] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_ID_City] ON [dbo].[FirstIndex] 
(
	[ID] ASC,
	[City] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_FirstName_LastName] ON [dbo].[FirstIndex] 
(
	[FirstName] ASC,
	[LastName] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_FirstName_City] ON [dbo].[FirstIndex] 
(
	[FirstName] ASC,
	[City] ASC
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_FirstIndex_LastName_City] ON [dbo].[FirstIndex] 
(
	[LastName] ASC,
	[City] ASC
) ON [PRIMARY]
GO
-- Insert One Hundred Thousand Records
-- INSERT 2
INSERT INTO FirstIndex (ID,FirstName,LastName,City)
SELECT TOP 100000 ROW_NUMBER() OVER (ORDER BY a.name) RowID, 
					'Bob', 
					CASE WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%2 = 1 THEN 'Smith' 
					ELSE 'Brown' END,
					CASE WHEN ROW_NUMBER() OVER (ORDER BY a.name)%10 = 1 THEN 'New York' 
						WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 5 THEN 'San Marino' 
						WHEN  ROW_NUMBER() OVER (ORDER BY a.name)%10 = 3 THEN 'Los Angeles' 
					ELSE 'Houston' END
FROM sys.all_objects a
CROSS JOIN sys.all_objects b
GO
/*
Question 1: Which insert took most the time INSERT 1 or INSERT 2
WHY?
*/
-- Truncate Table
TRUNCATE TABLE FirstIndex
GO
