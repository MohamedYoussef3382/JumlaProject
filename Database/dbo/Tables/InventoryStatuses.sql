CREATE TABLE [dbo].[InventoryStatuses] (
    [InventoryStatusId] UNIQUEIDENTIFIER CONSTRAINT [DF_InventoryStatus_InventoryStatusId] DEFAULT (newid()) NOT NULL,
    [Name]              NVARCHAR (255)   NULL,
    [Code]              NVARCHAR (50)    NULL,
    [IsDeleted]         BIT              NOT NULL,
    CONSTRAINT [PK_InventoryStatus] PRIMARY KEY CLUSTERED ([InventoryStatusId] ASC)
);

