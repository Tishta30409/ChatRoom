CREATE PROCEDURE [dbo].[pro_accountUpdate]
	@account VARCHAR(40),--傳入值
	@password VARCHAR(40),
	@nickName NVARCHAR(20),
	@isLocked	TINYINT,
	@isMuted TINYINT, 
	@errorTimes TINYINT,
	@GUID UNIQUEIDENTIFIER ,
	@roomID INT
AS
	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @password, 
	f_nickName = @nickName,
	f_isLocked = @isLocked,
	f_isMuted = @isMuted,
	f_errorTimes = @errorTimes,
	f_GUID = @GUID,
	f_roomID = @roomID
	OUTPUT inserted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountUpdate] TO PUBLIC
    AS [dbo];
