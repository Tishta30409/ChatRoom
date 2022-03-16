
CREATE PROCEDURE [dbo].[pro_roomQueryList]
AS
	SELECT f_id, f_roomName  FROM t_room WITH(NOLOCK) 
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_roomQueryList] TO PUBLIC
    AS [dbo];
