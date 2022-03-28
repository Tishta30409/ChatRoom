CREATE PROCEDURE [dbo].[pro_roomAdd]
	@roomName NVARCHAR(20)
AS
	IF EXISTS(
    SELECT Top 1 1
    FROM t_room 
    WHERE f_roomName=@roomName
    )
	BEGIN
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
		INSERT INTO t_room(f_roomName)VALUES(@roomName)
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomAdd] TO PUBLIC
    AS [dbo];
