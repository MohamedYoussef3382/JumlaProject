CREATE TABLE [dbo].[ProductStockDetails] (
    [ProductStockDetailsId] UNIQUEIDENTIFIER CONSTRAINT [DF_ProductStockDetails_ProductStockId] DEFAULT (newid()) NOT NULL,
    [Size]                  NVARCHAR (250)   NULL,
    [Color]                 NVARCHAR (250)   NULL,
    [NumAvailableInStock]   INT              NULL,
    [ProductId]             UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_ProductStockDetails] PRIMARY KEY CLUSTERED ([ProductStockDetailsId] ASC),
    CONSTRAINT [FK_ProductStockDetails_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId])
);

