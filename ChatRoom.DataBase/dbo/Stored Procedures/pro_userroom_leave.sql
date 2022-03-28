CREATE PROCEDURE [dbo].[pro_userroom_leave]
	@Account NVARCHAR(20)
AS
	UPDATE t_userroom WITH(ROWLOCK) SET f_roomID = NULL 
	OUTPUT  inserted.* 
	WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userroom_leave] TO PUBLIC
AS [dbo];
