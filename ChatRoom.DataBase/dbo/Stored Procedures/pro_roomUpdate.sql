CREATE PROCEDURE [dbo].[pro_roomUpdate]
	@id int,
	@roomName VARCHAR(20)
AS
	UPDATE t_room WITH(ROWLOCK)
	SET 
	f_roomName = @roomName
	OUTPUT inserted.*
	WHERE f_id = @id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomUpdate] TO PUBLIC
    AS [dbo];
