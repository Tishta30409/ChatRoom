CREATE PROCEDURE [dbo].[pro_userRoomQueryList]
	@roomID int
AS
	SELECT f_account FROM t_userroom WITH(NOLOCK) WHERE f_roomID = @RoomID
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomQueryList] TO PUBLIC
AS [dbo];
