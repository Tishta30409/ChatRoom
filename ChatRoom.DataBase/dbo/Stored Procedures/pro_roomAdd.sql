CREATE PROCEDURE [dbo].[pro_roomAdd]
	@roomName NVARCHAR(20)
AS
	IF NOT EXISTS(
    SELECT f_id, f_roomName FROM t_room WHERE f_roomName = @roomName
    )
	BEGIN
		INSERT INTO t_room(f_roomName) OUTPUT inserted.* VALUES(@roomName)
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomAdd] TO PUBLIC
    AS [dbo];
