CREATE TABLE [dbo].[Job]
(
	[JobKey] INT NOT NULL PRIMARY KEY IDENTITY(1000,1),
	[DepartmentKey] INT NOT NULL,
	[LocationKey] INT NOT NULL,
	[Code] Varchar(10)NOT NULL,
	[Title] Varchar(100) NOT NULL,
	[Description] Varchar(200) NULL,
	[PostedDate] Datetime NOT NULL DEFAULT(getdate()),
	[ClosingDate] Datetime NOT NULL,
	Constraint [FK_Job_Department] FOREIGN KEY ([DepartmentKey]) REFERENCES  [Department]([DepartmentKey]),
	Constraint [FK_Job_Location] FOREIGN KEY ([LocationKey]) REFERENCES  [Location]([LocationKey]),
)
