USE [RAF_TEST]
GO

ALTER TABLE [dbo].[MISSVISNING]
ALTER COLUMN [MISSVISNING] nvarchar(4) NOT NULL;
GO
---------------------------------------------------------------------------------------
USE [RAF_TEST]
GO

UPDATE [deltagare_ny]
SET 
arbetsgivare = REPLACE(arbetsgivare, 'Eltel Networks', 'AVISEQ')
WHERE
arbetsgivare IS NOT NULL;
---------------------------------------------------------------------------------------
USE [RAF_TEST]
GO

UPDATE [ADDRESSERKOPIOR]
SET 
[KOPIA TILL] = REPLACE([KOPIA TILL], 'Eltel Networks', 'AVISEQ Critical Communication AB')
WHERE
[KOPIA TILL] IS NOT NULL;
---------------------------------------------------------------------------------------
USE [RAF_TEST]
GO

UPDATE [ADDRESSERKOPIOR]
SET 
[KOPIA TILL] = REPLACE([KOPIA TILL], 'AVISEQ Critical Communication AB AB Karlstad', 'AVISEQ Critical Communication AB Karlstad')
WHERE
[KOPIA TILL] IS NOT NULL;
---------------------------------------------------------------------------------------
