CREATE TABLE [dbo].[OrderProcductDetails] (
    [OrderProcductDetailsId] UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_OrderProcductId] DEFAULT (newid()) NOT NULL,
    [ProcductId]             UNIQUEIDENTIFIER NULL,
    [ProductStockDetailsId]  UNIQUEIDENTIFIER NULL,
    [OrderId]                UNIQUEIDENTIFIER NULL,
    [Profit]                 DECIMAL (18, 2)  NULL,
    [Count]                  INT              NULL,
    CONSTRAINT [PK_OrderProcductDetails] PRIMARY KEY CLUSTERED ([OrderProcductDetailsId] ASC),
    CONSTRAINT [FK_OrderProcductDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]),
    CONSTRAINT [FK_OrderProcductDetails_Products] FOREIGN KEY ([ProcductId]) REFERENCES [dbo].[Products] ([ProductId]),
    CONSTRAINT [FK_OrderProcductDetails_ProductStockDetails1] FOREIGN KEY ([ProductStockDetailsId]) REFERENCES [dbo].[ProductStockDetails] ([ProductStockDetailsId])
);

