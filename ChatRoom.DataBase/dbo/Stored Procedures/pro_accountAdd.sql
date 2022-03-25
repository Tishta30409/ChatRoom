
--創建帳號
CREATE PROCEDURE [dbo].[pro_accountAdd]
	@account VARCHAR(40) ,
	@password VARCHAR(40),
	@nickName NVARCHAR(20)
AS
	CREATE  TABLE #accountTemp
	 (
		f_id int,
		f_account VARCHAR(40),
		f_password VARCHAR(40),
		f_nickName NVARCHAR(20),
		f_isLocked TINYINT,
		f_isMuted TINYINT,
		f_errorTimes TINYINT,
		f_GUID UNIQUEIDENTIFIER
	 )

	 --ResultCode
		--SUCCESS = 0,
        --ACCOUNT_REPEAT = 1,
        --ACCOUNT_LOCKED = 2,
        --ACCOUNT_NOTEXIST = 3,
        --WORNG_PASSWORD = 4,

	--撈出會員資料
	INSERT INTO #accountTemp 
	SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_GUID FROM t_account WHERE f_account =  @account

	IF EXISTS(
		SELECT f_id FROM #accountTemp WHERE f_account = @account
    )
	BEGIN
		SELECT 1;
		SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_GUID FROM #accountTemp 
	END
	ELSE
	BEGIN
		SELECT 0;
		INSERT INTO t_account(f_account, f_password, f_nickName)
		OUTPUT inserted.*
		VALUES(@account, @password, @nickName)
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountAdd] TO PUBLIC
    AS [dbo];