CREATE PROCEDURE [dbo].[pro_userRoomQuery]
	@account NVARCHAR(20)
AS
	SELECT f_roomID FROM t_userroom WITH(NOLOCK) WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomQuery] TO PUBLIC
AS [dbo];
