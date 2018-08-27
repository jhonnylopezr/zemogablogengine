/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* AspNetRoles */
MERGE INTO AspNetRoles AS Target
USING (VALUES
  (N'Editor', N'Editor'),
  (N'Writer', N'Writer')
)
AS Source (Id, [Name])
ON Target.Id = Source.Id
-- update matched rows
WHEN MATCHED THEN
UPDATE SET [Name] = Source.[Name]
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (Id, [Name])
VALUES (Id, [Name]);

/* AspNetUsers */
MERGE INTO AspNetUsers AS Target
USING (VALUES
  (N'f3807256-4a57-4024-b387-ac057d97669a', N'admin@zemoga.com', 0, N'AL+2RhK4HbFnmYLRtOMl7bBG6FWKK05xqUpBVLxc+D1oHIthwH9D3HndV4WxcCBj6w==', N'8c7f2de8-9fc4-4aea-a69c-654f7a7e52c7', NULL, 0, 0, NULL, 1, 0, N'admin@zemoga.com', N'Jhonny Lopez')
)
AS Source ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName])
ON Target.UserName = Source.UserName
-- update matched rows
WHEN MATCHED THEN
UPDATE SET [FullName] = Source.[FullName]
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName])
VALUES ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName]);


/* AspNetUserRoles */
MERGE INTO AspNetUserRoles AS Target
USING (VALUES
  (N'f3807256-4a57-4024-b387-ac057d97669a', N'Editor')
  
)
AS Source (UserId, RoleId)
ON Target.UserId = Source.UserId AND Target.RoleId = Source.RoleId
-- insert new rows
WHEN NOT MATCHED BY TARGET THEN
INSERT (UserId, RoleId)
VALUES (UserId, RoleId);