CREATE PROCEDURE [dbo].[pro_accountChangePassword]
	@account VARCHAR(40),
	@password VARCHAR(40)
AS

	DECLARE @passwordMD5 VARCHAR(32) = SUBSTRING(sys.fn_sqlvarbasetostr(HASHBYTES('MD5',@password)), 3, 32)

	UPDATE t_account WITH(ROWLOCK)
	SET 
	f_password = @passwordMD5
	OUTPUT inserted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountChangePassword] TO PUBLIC
    AS [dbo];
