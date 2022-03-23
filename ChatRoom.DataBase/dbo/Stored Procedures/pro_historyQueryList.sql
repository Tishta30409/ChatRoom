CREATE PROCEDURE [dbo].[pro_historyQueryList]
@roomID INT
AS
    --撈出前10筆資料 反向排序
    SELECT  f_id, f_roomID, 
    f_nickName, 
    f_content,
    f_createDateTime  
    FROM(
        SELECT  TOP 10 
        f_id, f_roomID, 
        f_nickName, 
        f_content,
        f_createDateTime  
        FROM t_history WHERE f_roomID = @roomID
        ORDER BY f_id DESC
    ) c
    ORDER BY f_id
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyQueryList] TO PUBLIC
    AS [dbo];
