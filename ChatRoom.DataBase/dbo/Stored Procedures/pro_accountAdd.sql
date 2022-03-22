
--創建帳號
CREATE PROCEDURE [dbo].[pro_accountAdd]
	@account VARCHAR(40) ,
	@password VARCHAR(40),
	@nickName NVARCHAR(20)
AS
	 DECLARE 
      @resultCode  INT        =  0

	IF EXISTS(
    SELECT 1 
    FROM t_account 
    WHERE f_account=@account
    )
	BEGIN
		SET @resultCode =  1
	END
	ELSE
	BEGIN
		INSERT INTO t_account(f_account, f_password, f_nickName)
		OUTPUT inserted.*
		VALUES(@account, @password, @nickName)
	END

	SELECT @resultCode
	SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_GUID FROM t_account WHERE f_account =  @account 

RETURN @resultCode
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountAdd] TO PUBLIC
    AS [dbo];