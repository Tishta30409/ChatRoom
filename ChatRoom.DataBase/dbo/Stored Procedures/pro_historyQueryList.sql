﻿CREATE PROCEDURE [dbo].[pro_historyQueryList]
@RoomID INT
AS
	SELECT
    f_id, f_roomID, 
    f_nickName, 
    f_content,
    f_createDateTime  
    FROM t_history WITH(NOLOCK)  WHERE f_roomID = @RoomID
    ORDER BY f_id DESC 

RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyQueryList] TO PUBLIC
    AS [dbo];
