CREATE TABLE [dbo].[Users] (
    [UserId]           UNIQUEIDENTIFIER NOT NULL,
    [PrivilageId]      UNIQUEIDENTIFIER NULL,
    [AccountTypeId]    UNIQUEIDENTIFIER NULL,
    [ProfilePictureId] UNIQUEIDENTIFIER NULL,
    [Name]             NVARCHAR (255)   NULL,
    [Email]            NVARCHAR (255)   NULL,
    [Password]         NVARCHAR (255)   NULL,
    [Address]          NVARCHAR (255)   NULL,
    [IsDeleted]        BIT              NOT NULL,
    [CreatedBy]        UNIQUEIDENTIFIER NULL,
    [CreatedDate]      DATETIME         NULL,
    [UpdatedBy]        UNIQUEIDENTIFIER NULL,
    [UpdatedDate]      DATETIME         NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_Users_AccountTypes] FOREIGN KEY ([AccountTypeId]) REFERENCES [dbo].[AccountTypes] ([AccountTypeId]),
    CONSTRAINT [FK_Users_Images] FOREIGN KEY ([ProfilePictureId]) REFERENCES [dbo].[Images] ([ImageId]),
    CONSTRAINT [FK_Users_Privilages] FOREIGN KEY ([PrivilageId]) REFERENCES [dbo].[Privilages] ([PrivilageId])
);

