CREATE TABLE [dbo].[Products] (
    [ProductId]         UNIQUEIDENTIFIER CONSTRAINT [DF_Products_ProductId] DEFAULT (newid()) NOT NULL,
    [InventoryStatusId] UNIQUEIDENTIFIER NULL,
    [CategoryId]        UNIQUEIDENTIFIER NULL,
    [PriceCurrencyId]   UNIQUEIDENTIFIER NULL,
    [Name]              NVARCHAR (250)   NULL,
    [Description]       NVARCHAR (MAX)   NULL,
    [Price]             DECIMAL (18, 2)  NULL,
    [OldPrice]          DECIMAL (18, 2)  NULL,
    [ShipingPrice]      DECIMAL (18, 2)  NULL,
    [ServicePrice]      DECIMAL (18, 2)  NULL,
    [Rating]            INT              NULL,
    [CreatedBy]         UNIQUEIDENTIFIER NULL,
    [CreatedDate]       DATETIME         NULL,
    [UpdatedBy]         UNIQUEIDENTIFIER NULL,
    [UpdatedDate]       DATETIME         NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [FK_Products_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]),
    CONSTRAINT [FK_Products_InventoryStatus] FOREIGN KEY ([InventoryStatusId]) REFERENCES [dbo].[InventoryStatuses] ([InventoryStatusId]),
    CONSTRAINT [FK_Products_PriceCurrency] FOREIGN KEY ([PriceCurrencyId]) REFERENCES [dbo].[PriceCurrency] ([CurrencyId])
);

