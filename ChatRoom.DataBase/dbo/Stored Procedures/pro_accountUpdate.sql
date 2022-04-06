CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@account VARCHAR(40),--傳入值
	@nickName NVARCHAR(20),
	@isLocked	TINYINT,
	@isMuted TINYINT, 
	@errorTimes TINYINT,
	@loginIdentifier NVARCHAR(32),
	@serialNumber BIGINT
AS
	DECLARE @seriaNumber BIGINT = (SELECT f_serialNumber FROM t_account WHERE f_account = @account)

	if(@seriaNumber  = @serialNumber)
	BEGIN
		SELECT 0
		UPDATE t_account WITH(ROWLOCK)
		SET 
		f_nickName = @nickName,
		f_isLocked = @isLocked,
		f_isMuted = @isMuted,
		f_errorTimes = @errorTimes,
		f_loginIdentifier = @loginIdentifier,
		f_serialNumber = f_serialNumber + 1
		WHERE f_account = @account
	END
	ELSE
	BEGIN
		SELECT 7
	END

	SELECT  
	f_account,
	f_password,
	f_nickName,
	f_errorTimes,
	f_isLocked,
	f_isMuted,
	f_loginIdentifier,
	f_serialNumber
	FROM t_account
	WHERE f_account = @account
	
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
