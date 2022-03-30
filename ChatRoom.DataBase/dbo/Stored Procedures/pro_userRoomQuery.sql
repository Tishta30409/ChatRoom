CREATE PROCEDURE [dbo].[pro_userRoomQuery]
	@Account NVARCHAR(20)
AS
	SELECT f_roomID FROM t_userroom WITH(NOLOCK) WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomQuery] TO PUBLIC
AS [dbo];
