CREATE TABLE [dbo].[OrderPriceDetails] (
    [OrderPriceDetailsId] UNIQUEIDENTIFIER CONSTRAINT [DF_OrderPriceDetails_OrderPriceDetailsId] DEFAULT (newid()) NOT NULL,
    [OrderId]             UNIQUEIDENTIFIER NULL,
    [PriceCurrencyId]     UNIQUEIDENTIFIER NULL,
    [SubTotalPrice]       DECIMAL (18, 2)  NULL,
    [TaxPrice]            DECIMAL (18, 2)  NULL,
    [DiscountPrice]       DECIMAL (18, 2)  NULL,
    [TotalPrice]          DECIMAL (18, 2)  NULL,
    CONSTRAINT [PK_OrderPriceDetails] PRIMARY KEY CLUSTERED ([OrderPriceDetailsId] ASC),
    CONSTRAINT [FK_OrderPriceDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId]),
    CONSTRAINT [FK_OrderPriceDetails_PriceCurrency] FOREIGN KEY ([PriceCurrencyId]) REFERENCES [dbo].[PriceCurrency] ([CurrencyId])
);

