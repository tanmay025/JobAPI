/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT Department ON

DECLARE @DepartmentTable TABLE (
	[DepartmentKey] INT NOT NULL
	,[Title] VARCHAR(100) NOT NULL
	)

INSERT INTO @DepartmentTable (
	[DepartmentKey]
	,[Title]
	)
SELECT 2085
	,'Software Development'

UNION ALL

SELECT 2086
	,'Project Management'

MERGE Department AS Target
USING @DepartmentTable AS Source
	ON Source.[DepartmentKey] = Target.[DepartmentKey]
WHEN MATCHED
	THEN
		UPDATE
		SET [Title] = source.[Title]
WHEN NOT MATCHED BY Target
	THEN
		INSERT (
			[DepartmentKey]
			,[Title]
			)
		VALUES (
			Source.[DepartmentKey]
			,Source.[Title]
			);

SET IDENTITY_INSERT Department OFF
GO

SET IDENTITY_INSERT [Location] ON

DECLARE @LocationTable TABLE (
	[LocationKey] INT NOT NULL
	,[Title] VARCHAR(100) NOT NULL
	,[City] VARCHAR(50) NULL
	,[state] VARCHAR(50) NULL
	,[country] VARCHAR(50) NULL
	,[zip] VARCHAR(10) NULL
	)

INSERT INTO @LocationTable (
	[LocationKey]
	,[Title]
	,[City]
	,[state]
	,[country]
	,[zip]
	)
SELECT 10030
	,'US Head Office'
	,'Baltimore'
	,'MD'
	,'United States'
	,21202

UNION ALL

SELECT 10031
	,'India Office'
	,NULL
	,NULL
	,NULL
	,NULL

MERGE [Location] AS Target
USING @LocationTable AS Source
	ON Source.[LocationKey] = Target.[LocationKey]
WHEN MATCHED
	THEN
		UPDATE
		SET [Title] = source.[Title]
			,[City] = source.[City]
			,[state] = source.[state]
			,[country] = source.[country]
			,[zip] = source.[zip]
WHEN NOT MATCHED BY Target
	THEN
		INSERT (
			[LocationKey]
			,[Title]
			,[City]
			,[state]
			,[country]
			,[zip]
			)
		VALUES (
			Source.[LocationKey]
			,Source.[Title]
			,Source.[City]
			,Source.[state]
			,Source.[country]
			,Source.[zip]
			);

SET IDENTITY_INSERT [Location] OFF
GO


