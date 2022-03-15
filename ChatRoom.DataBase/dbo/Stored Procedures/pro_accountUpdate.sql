CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@Account VARCHAR(40),--傳入值
	@Password VARCHAR(40),
	@NickName NVARCHAR(20),
	@State	TINYINT,
	@ErrorTimes TINYINT
AS
	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @Password, 
	f_nickName = @NickName,
	f_state = @State,
	f_errorTimes = @ErrorTimes
	OUTPUT inserted.*
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
