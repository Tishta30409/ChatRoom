--後臺使用
CREATE PROCEDURE [dbo].[pro_accountDelete]
	@account NVARCHAR(40)
AS
	DELETE FROM t_account WITH(ROWLOCK)
	OUTPUT deleted.*
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountDelete] TO PUBLIC
    AS [dbo];
