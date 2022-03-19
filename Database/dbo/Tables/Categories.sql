CREATE TABLE [dbo].[Categories] (
    [CategoryId]       UNIQUEIDENTIFIER CONSTRAINT [DF_Categories_CategoryId] DEFAULT (newid()) NOT NULL,
    [Name]             NVARCHAR (250)   NULL,
    [Descirption]      NVARCHAR (MAX)   NULL,
    [ParentCategoryId] UNIQUEIDENTIFIER NULL,
    [CreatedBy]        UNIQUEIDENTIFIER NULL,
    [CreatedDate]      DATETIME         NULL,
    [UpdatedBy]        UNIQUEIDENTIFIER NULL,
    [UpdatedDate]      DATETIME         NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_Categories_Categories] FOREIGN KEY ([ParentCategoryId]) REFERENCES [dbo].[Categories] ([CategoryId])
);


GO
ALTER TABLE [dbo].[Categories] NOCHECK CONSTRAINT [FK_Categories_Categories];

