CREATE PROCEDURE [dbo].[pro_historyDelete]
	@account NVARCHAR(20)
AS
	DELETE t_history WITH(ROWLOCK) WHERE f_account = @account
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyDelete] TO PUBLIC
    AS [dbo];

