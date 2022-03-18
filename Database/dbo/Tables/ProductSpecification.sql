CREATE TABLE [dbo].[ProductSpecification] (
    [ProductSpecificationId] UNIQUEIDENTIFIER CONSTRAINT [DF_ProductSpecification_ProductSpecificationId] DEFAULT (newid()) NOT NULL,
    [Name]                   NVARCHAR (250)   NULL,
    [Value]                  NVARCHAR (250)   NULL,
    [ProductId]              UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ProductSpecification] PRIMARY KEY CLUSTERED ([ProductSpecificationId] ASC),
    CONSTRAINT [FK_ProductSpecification_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

