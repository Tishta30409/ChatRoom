CREATE PROCEDURE [dbo].[pro_userRoomLeave]
	@account NVARCHAR(20)
AS
	DELETE t_userroom WITH(ROWLOCK)
	OUTPUT  deleted.* 
	WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomLeave] TO PUBLIC
AS [dbo];
