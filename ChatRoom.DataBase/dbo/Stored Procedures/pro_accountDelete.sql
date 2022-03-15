CREATE PROCEDURE [dbo].[pro_accountDelete]
	@Account NVARCHAR(40)
AS
	DELETE FROM t_account WITH(ROWLOCK)
	OUTPUT deleted.*
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountDelete] TO PUBLIC
    AS [dbo];
