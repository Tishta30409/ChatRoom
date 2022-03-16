CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@account VARCHAR(40),--傳入值
	@password VARCHAR(40),
	@nickName NVARCHAR(20),
	@state	TINYINT,
	@errorTimes TINYINT
AS
	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @password, 
	f_nickName = @nickName,
	f_state = @state,
	f_errorTimes = @errorTimes
	OUTPUT inserted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
