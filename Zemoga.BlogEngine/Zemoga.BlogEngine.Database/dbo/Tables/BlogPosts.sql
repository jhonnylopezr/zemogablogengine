CREATE TABLE [dbo].[BlogPosts] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [Title]          NVARCHAR (255) NOT NULL,
    [PostContent]    NVARCHAR (MAX) NOT NULL,
    [UserId]         NVARCHAR (128) NOT NULL,
    [CreatedOn]      SMALLDATETIME  NOT NULL,
    [LastModifiedOn] SMALLDATETIME  NOT NULL,
    [IsPublished] BIT NOT NULL, 
    CONSTRAINT [PK_BlogPosts] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogPosts_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

