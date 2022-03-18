CREATE TABLE [dbo].[Images] (
    [ImageId]     UNIQUEIDENTIFIER CONSTRAINT [DF_Images_ImageId] DEFAULT (newid()) NOT NULL,
    [Url]         NVARCHAR (MAX)   NULL,
    [ProductId]   UNIQUEIDENTIFIER NULL,
    [IsMainImage] BIT              NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([ImageId] ASC),
    CONSTRAINT [FK_Images_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

