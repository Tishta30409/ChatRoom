CREATE PROCEDURE [dbo].[pro_userRoomLeave]
	@Account NVARCHAR(20)
AS
	UPDATE t_userroom WITH(ROWLOCK) SET f_roomID = NULL 
	OUTPUT  inserted.* 
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomLeave] TO PUBLIC
AS [dbo];
