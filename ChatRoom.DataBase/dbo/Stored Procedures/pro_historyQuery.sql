CREATE PROCEDURE [dbo].[pro_historyQuery]
AS
	SELECT TOP 10
    f_id, f_roomID, 
    f_nickName, 
    f_content,
    f_createDateTime  
    FROM 
    t_history 
    WITH(NOLOCK)  
    ORDER BY 
    f_createDateTime 
    DESC 

RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyQuery] TO PUBLIC
    AS [dbo];
