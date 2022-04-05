CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@account VARCHAR(40),--傳入值
	@nickName NVARCHAR(20),
	@isLocked	TINYINT,
	@isMuted TINYINT, 
	@errorTimes TINYINT,
	@LoginIdentifier NVARCHAR(32)
AS
	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_nickName = @nickName,
	f_isLocked = @isLocked,
	f_isMuted = @isMuted,
	f_errorTimes = @errorTimes,
	f_loginIdentifier = @LoginIdentifier,
	f_serialNumber = f_serialNumber + 1
	OUTPUT inserted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
