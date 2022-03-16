CREATE PROCEDURE [dbo].[pro_historyAdd]
	@roomID INT,
	@nickName NVARCHAR(20),
	@content NVARCHAR(20),
	@createDateTime DATETIME
AS
	
	
	INSERT INTO t_history([f_roomID], [f_nickName], [f_content], [f_createDateTime])
	OUTPUT inserted.*
	VALUES(@roomID, @nickName, @content, @createDateTime)

RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyAdd] TO PUBLIC
    AS [dbo];
