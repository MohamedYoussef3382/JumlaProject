CREATE TABLE [dbo].[Orders] (
    [OrderId]       UNIQUEIDENTIFIER CONSTRAINT [DF_Orders_OrderId] DEFAULT (newid()) NOT NULL,
    [OrderStatusId] INT              NULL,
    [OrderedBy]     UNIQUEIDENTIFIER NULL,
    [ApprovedBy]    UNIQUEIDENTIFIER NULL,
    [OrderedDate]   DATETIME         NULL,
    [UpdatedBy]     UNIQUEIDENTIFIER NULL,
    [UpdatedDate]   DATETIME         NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Orders_OrderStatuses] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatuses] ([OrderStatusId]),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([OrderedBy]) REFERENCES [dbo].[Users] ([UserId]),
    CONSTRAINT [FK_Orders_Users1] FOREIGN KEY ([ApprovedBy]) REFERENCES [dbo].[Users] ([UserId])
);


GO
ALTER TABLE [dbo].[Orders] NOCHECK CONSTRAINT [FK_Orders_Users1];

