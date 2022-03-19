CREATE TABLE [dbo].[Privilages] (
    [PrivilageId] UNIQUEIDENTIFIER CONSTRAINT [DF_Privilages_PrivilageId] DEFAULT (newid()) NOT NULL,
    [Name]        NVARCHAR (250)   NULL,
    [Description] NVARCHAR (MAX)   NULL,
    [IsDeleted]   BIT              NOT NULL,
    CONSTRAINT [PK_Privilages] PRIMARY KEY CLUSTERED ([PrivilageId] ASC)
);

