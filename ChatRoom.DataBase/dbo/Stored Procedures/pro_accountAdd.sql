
--創建帳號
CREATE PROCEDURE [dbo].[pro_accountAdd]
	@account VARCHAR(40) ,
	@password VARCHAR(40),
	@nickName NVARCHAR(20)
AS
	IF EXISTS(
		SELECT Top 1 1 FROM t_account WHERE f_account = @account
    )
	BEGIN
		 --ACCOUNT_REPEAT = 1,
		SELECT 1;
		--SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_loginIdentifier FROM #accountTemp 
	END
	ELSE
	BEGIN
		SELECT 0;

		DECLARE @passwordSha2 VARCHAR(32) = SUBSTRING(sys.fn_sqlvarbasetostr(HASHBYTES('MD5',@password)), 3, 32)

		INSERT INTO t_account(f_account, f_password, f_nickName) VALUES(@account, @passwordSha2, @nickName)
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountAdd] TO PUBLIC
    AS [dbo];