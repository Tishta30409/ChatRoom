CREATE PROCEDURE [dbo].[pro_historyDelete]
	@RoomID INT
AS
	DELETE FROM t_history WITH(ROWLOCK)
	OUTPUT deleted.*
	WHERE f_roomID = @RoomID 
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyDelete] TO PUBLIC
    AS [dbo];
