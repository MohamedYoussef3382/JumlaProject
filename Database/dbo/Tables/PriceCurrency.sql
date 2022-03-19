CREATE TABLE [dbo].[PriceCurrency] (
    [CurrencyId] UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_PriceCurrencyId] DEFAULT (newid()) NOT NULL,
    [Name]       NVARCHAR (255)   NULL,
    [Code]       NVARCHAR (50)    NULL,
    [IsDeleted]  BIT              NOT NULL,
    CONSTRAINT [PK_PriceCurrency] PRIMARY KEY CLUSTERED ([CurrencyId] ASC)
);

