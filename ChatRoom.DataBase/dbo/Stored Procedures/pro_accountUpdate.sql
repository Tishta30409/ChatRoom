CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@account VARCHAR(40),--傳入值
	@password VARCHAR(40),
	@nickName NVARCHAR(20),
	@isLocked	TINYINT,
	@isMuted TINYINT, 
	@errorTimes TINYINT,
	@LoginIdentifier NVARCHAR(32)
AS

	DECLARE @passwordMD5 VARCHAR(32) = SUBSTRING(sys.fn_sqlvarbasetostr(HASHBYTES('MD5',@password)), 3, 32)

	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @passwordMD5, 
	f_nickName = @nickName,
	f_isLocked = @isLocked,
	f_isMuted = @isMuted,
	f_errorTimes = @errorTimes,
	f_loginIdentifier = @LoginIdentifier
	OUTPUT inserted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
