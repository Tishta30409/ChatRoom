CREATE PROCEDURE [dbo].[pro_userRoomLeave]
	@Account NVARCHAR(20)
AS
	DELETE t_userroom WITH(ROWLOCK)
	OUTPUT  deleted.* 
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomLeave] TO PUBLIC
AS [dbo];
