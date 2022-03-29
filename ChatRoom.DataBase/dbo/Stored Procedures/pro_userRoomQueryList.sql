CREATE PROCEDURE [dbo].[pro_userRoomQueryList]
	@RoomID int
AS
	SELECT f_account, f_nickName FROM t_userroom WITH(NOLOCK) WHERE f_roomID = @RoomID
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomQueryList] TO PUBLIC
AS [dbo];
