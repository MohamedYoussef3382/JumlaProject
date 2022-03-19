CREATE TABLE [dbo].[AccountTypes] (
    [AccountTypeId] UNIQUEIDENTIFIER CONSTRAINT [DF_AccountTypes_AccountTypeId] DEFAULT (newid()) NOT NULL,
    [Name]          NVARCHAR (250)   NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [IsDeleted]     BIT              NOT NULL,
    CONSTRAINT [PK_AccountTypes] PRIMARY KEY CLUSTERED ([AccountTypeId] ASC)
);

