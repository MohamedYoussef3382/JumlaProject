CREATE TABLE [dbo].[WishList] (
    [WishId]    UNIQUEIDENTIFIER CONSTRAINT [DF_WishList_WishId] DEFAULT (newid()) NOT NULL,
    [ProductId] UNIQUEIDENTIFIER NULL,
    [UserId]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_WishList] PRIMARY KEY CLUSTERED ([WishId] ASC),
    CONSTRAINT [FK_WishList_Products] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([ProductId]),
    CONSTRAINT [FK_WishList_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([UserId])
);

