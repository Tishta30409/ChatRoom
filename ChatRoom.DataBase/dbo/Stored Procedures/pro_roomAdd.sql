CREATE PROCEDURE [dbo].[pro_roomAdd]
	@roomName NVARCHAR(20)
AS
	CREATE  TABLE #roomTemp
	 (
		f_id int,
		f_roomName NVARCHAR(10)
	 )

	 --撈出會員資料
	INSERT INTO #roomTemp 
	SELECT f_id, f_roomName FROM t_room WHERE f_roomName =  @roomName

	IF EXISTS(
    SELECT f_id
    FROM #roomTemp 
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
