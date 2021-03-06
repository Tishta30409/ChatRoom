CREATE PROCEDURE [dbo].[pro_historySortOut]
AS
	--宣告房間列表暫存
	DECLARE @roomlist TABLE (f_id INT , f_rowId INT IDENTITY) 

	--把資料存到暫存區
	INSERT INTO @roomlist (f_id)
	SELECT  f_id FROM t_room WITH(NOLOCK) 

	-- 迴圈參數
	DECLARE 
	@curCount INT = 1,
	@totalCount INT
	

	--找最大行數
	SET @totalCount = (SELECT COUNT(f_id) FROM @roomlist)

	--迴圈 執行每個房間的排列刪除
	WHILE @curCount <= @TotalCount
	BEGIN
	-- 找到目前迴圈指標指向的 房間ID
		DECLARE @curRoomID INT
		DECLARE @flagID BIGINT

		SET @curRoomID = (SELECT f_id FROM  @roomlist WHERE  f_rowId = @CurCount)

		--判斷有無超過10筆
		--有找出第10筆的ID 小於它都砍掉
		SET @flagID = 
		(SELECT TOP 1 f_id FROM (SELECT TOP 10 f_id FROM t_history  WHERE f_roomID = @curRoomID ORDER BY f_id DESC) c  ORDER BY c.f_id)

		DELETE FROM t_history WHERE f_roomID =@curRoomID AND @flagID > f_id AND @flagID>0
		
		SET @curCount = @curCount+1
	END
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historySortOut] TO PUBLIC
    AS [dbo];
