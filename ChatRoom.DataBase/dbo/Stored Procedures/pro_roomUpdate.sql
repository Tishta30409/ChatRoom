CREATE PROCEDURE [dbo].[pro_roomUpdate]
	@ID int,
	@RoomName VARCHAR(20)
AS
	UPDATE t_room WITH(ROWLOCK)
	SET 
	f_roomName = @RoomName
	OUTPUT inserted.*
	WHERE f_id = @ID
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomUpdate] TO PUBLIC
    AS [dbo];
