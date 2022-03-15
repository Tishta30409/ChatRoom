CREATE PROCEDURE [dbo].[pro_historyDelete]
	@RoomID INT
AS

	--宣告房間列表暫存
	DECLARE @roomlist TABLE (f_id INT , ROWID INT IDENTITY) 

	--把資料存到暫存區
	INSERT INTO @roomlist (f_id)
	SELECT  
	f_id 
	FROM t_room 
	WITH(NOLOCK) 

	-- 迴圈參數
	DECLARE 
	@TableCount INT,
	@WhileTableCount INT = 1

	--找最大行數
	SET @TableCount = (SELECT COUNT(f_id) FROM @roomlist)

	--迴圈 執行每個房間的排列刪除
	WHILE @WhileTableCount <= @TableCount
	BEGIN
	-- 找到目前迴圈指標指向的 房間ID
		DECLARE @curRoomID INT
		SET 
		@curRoomID = 
		(
			SELECT 
			f_id 
			FROM  
			@roomlist 
			WHERE  ROWID = @WhileTableCount
		)

		--找出最新的一筆資料
		DECLARE @lastHistoryID BIGINT
		SET 
		@lastHistoryID = 
		(
			SELECT TOP 1 
			f_id 
			FROM t_history  
			WHERE f_roomID = @curRoomID 
			ORDER BY f_id DESC
		)

		DELETE FROM 
		t_history 
		WHERE
		( 
			f_roomID =@curRoomID 
			AND 
			(f_id-@lastHistoryID)>10
		)

		SET @WhileTableCount = @WhileTableCount+1
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyDelete] TO PUBLIC
    AS [dbo];
