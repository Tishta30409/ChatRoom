CREATE PROCEDURE [dbo].[pro_roomAdd]
	@roomName NVARCHAR(20)
AS
	DECLARE 
      @resultCode  INT        = -99
      ,@resultMsg    NVARCHAR(20)  = '未定義錯誤'

	IF EXISTS(
    SELECT 1 
    FROM t_room 
    WHERE f_roomName=@roomName
    )
	BEGIN
		SET @resultCode = -1    
	END

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO t_room
			(f_roomName)
			OUTPUT inserted.*
			VALUES(@roomName)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

	EndProc:
		SET @resultMsg = 
		CASE @resultCode
			WHEN  1 THEN N'創建房間成功'
			WHEN -1 THEN N'房間名稱已存在'
			WHEN -99 THEN N'未定義錯誤。'
		END

RETURN @resultCode
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomAdd] TO PUBLIC
    AS [dbo];
