CREATE PROCEDURE [dbo].[User_Signin]
(
 @Email nvarchar(255),
 @Password nvarchar(255)
)
AS
SELECT u.UserId, u.Name, u.Email, u.Address, u.AccountTypeId, t.Name AS AccountType, u.PrivilageId, p.Name AS Privilage
FROM [dbo].[Users] u
LEFT JOIN [dbo].[AccountTypes] t ON u.AccountTypeId = t.AccountTypeId
JOIN [dbo].[Privilages] p ON u.PrivilageId = p.PrivilageId
WHERE u.IsDeleted = 0
  AND u.Email = @Email
  AND u.Password = @Password