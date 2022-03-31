CREATE PROCEDURE [dbo].[pro_roomAdd]
	@roomName NVARCHAR(20)
AS
	CREATE  TABLE #roomTemp
	 (
		f_id int,
		f_roomName VARCHAR(10),
	 )

	 INSERT INTO #roomTemp
	 SELECT f_id, f_roomName  FROM t_room WITH(NOLOCK) WHERE f_roomName = @roomName 

	IF  EXISTS(
		SELECT TOP 1 1 FROM #roomTemp
    )
	BEGIN
		SELECT f_id, f_roomName FROM t_room WHERE f_roomName = @roomName 
	END
	ELSE
	BEGIN
		INSERT INTO t_room(f_roomName) OUTPUT inserted.* VALUES(@roomName)
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomAdd] TO PUBLIC
    AS [dbo];
