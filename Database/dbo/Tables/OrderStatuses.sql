CREATE TABLE [dbo].[OrderStatuses] (
    [OrderStatusId] INT            NOT NULL,
    [Name]          NVARCHAR (250) NULL,
    [Code]          NVARCHAR (250) NULL,
    [IsDeleted]     BIT            NOT NULL,
    CONSTRAINT [PK_OrderStatues] PRIMARY KEY CLUSTERED ([OrderStatusId] ASC)
);

