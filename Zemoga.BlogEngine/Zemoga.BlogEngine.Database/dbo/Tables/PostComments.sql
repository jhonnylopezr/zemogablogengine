CREATE TABLE [dbo].[PostComments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BlogPostId] INT NOT NULL, 
    [AuthorName] NVARCHAR(255) NOT NULL, 
    [AuthorEmail] NVARCHAR(255) NOT NULL, 
    [Comment] NVARCHAR(1500) NOT NULL, 
    [CreatedOn] SMALLDATETIME NOT NULL, 
    CONSTRAINT [FK_PostComments_BlogPosts] FOREIGN KEY (BlogPostId) REFERENCES BlogPosts(Id) 
)
