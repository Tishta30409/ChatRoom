CREATE PROCEDURE [dbo].[pro_historyAdd]
	@RoomID VARCHAR(25),
	@NickName DECIMAL,
	@Content VARCHAR(25),
	@CreateDateTime DATETIME
AS
	INSERT INTO t_history([f_roomID], [f_nickName], [f_content], [f_createDateTime])
	OUTPUT inserted.*
	VALUES(@RoomID, @NickName, @Content, @CreateDateTime)
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyAdd] TO PUBLIC
    AS [dbo];
