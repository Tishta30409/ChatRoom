CREATE PROCEDURE [dbo].[pro_historyDelete]
	@RoomID INT
AS
	--宣告變數
	DECLARE @roomData AS TABLE
	(
		f_id BIGINT IDENTITY NOT NULL ,
		f_roomID INT NOT NULL,
		f_nickName NVARCHAR(20) NOT NULL,
		f_content NVARCHAR(20) NOT NULL,
		f_createDateTime DATETIME NOT NULL
	)

	--整理資料
	SET @roomData = 
	(
		SELECT TOP 100 PERCENT
		f_id,
		f_roomID, 
		f_nickName,
		f_content, 
		f_createDateTime 
		FROM t_history 
		WHERE f_roomID = @RoomID ORDER BY f_createDateTime DESC
	)
	--刪除資料

	DELETE FROM @roomData WHERE  row_number() > 10

	

	GO

	



	DELETE FROM t_history WITH(ROWLOCK)
	OUTPUT deleted.*
	WHERE  
	購買物品 + '-' + CONVERT(varchar(8), 第幾次)
	in 
	(
		SELECT 購買物品 + '-' + CONVERT(varchar(8), 第幾次) AS id 
		FROM 
		(
			SELECT 購買物品, 第幾次, 價格, row_number() OVER 
			(
				partition BY 購買物品 ORDER BY 購買物品, 第幾次 DESC
			) AS RANK  FROM   dbo.DataTable
		) AS TMP 
		WHERE RANK > 2
	)

	WHERE( f_roomID = @RoomID ORDER BY f_createDateTime DESC ) 
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyDelete] TO PUBLIC
    AS [dbo];
