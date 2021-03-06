--刪除房間要刪除歷史紀錄
CREATE PROCEDURE [dbo].[pro_roomDelete]
	@id INT
AS
	--刪除房間
	DELETE FROM t_room WITH(ROWLOCK) OUTPUT deleted.* WHERE f_id = @id
	--刪除歷史資料
	DELETE FROM t_history WITH(ROWLOCK) WHERE f_roomID = @id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomDelete] TO PUBLIC
    AS [dbo];
