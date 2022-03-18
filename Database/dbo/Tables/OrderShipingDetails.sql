CREATE TABLE [dbo].[OrderShipingDetails] (
    [OrderShipingDetailsId] UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_OrderShipingDestailsId] DEFAULT (newid()) NOT NULL,
    [OrderId]               UNIQUEIDENTIFIER NULL,
    [FirstName]             NVARCHAR (250)   NULL,
    [LastName]              NVARCHAR (250)   NULL,
    [Email]                 NVARCHAR (250)   NULL,
    [Phone]                 NVARCHAR (50)    NULL,
    [City]                  NVARCHAR (250)   NULL,
    [District]              NVARCHAR (250)   NULL,
    [Floor]                 NVARCHAR (250)   NULL,
    [Appartment]            NVARCHAR (250)   NULL,
    [Address]               NVARCHAR (250)   NULL,
    [SpecialNotes]          NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_OrderShipingDetails] PRIMARY KEY CLUSTERED ([OrderShipingDetailsId] ASC),
    CONSTRAINT [FK_OrderShipingDetails_Orders] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([OrderId])
);

