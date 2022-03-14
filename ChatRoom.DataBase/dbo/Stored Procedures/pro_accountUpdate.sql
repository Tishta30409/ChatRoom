CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@Account VARCHAR(40),--傳入值
	@Password VARCHAR(40),
	@NickName NVARCHAR(20)
AS
	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @Password, 
	f_nickName = @NickName
	OUTPUT inserted.*
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
