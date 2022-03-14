CREATE PROCEDURE [dbo].[pro_accountDelete]
	@Id INT
AS
	DELETE FROM t_account WITH(ROWLOCK)
	OUTPUT deleted.*
	WHERE f_id = @Id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountDelete] TO PUBLIC
    AS [dbo];
