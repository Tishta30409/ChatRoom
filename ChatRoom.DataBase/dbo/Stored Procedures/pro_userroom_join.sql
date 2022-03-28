CREATE PROCEDURE [dbo].[pro_userroom_join]
	@Account NVARCHAR(20),
	@RoomID INT
AS
	IF EXISTS(SELECT Top 1 1 FROM t_userroom WHERE f_account = @Account)
		UPDATE t_userroom WITH(ROWLOCK) SET f_roomID = @RoomID WHERE f_account = @Account
	ELSE
		INSERT INTO t_userroom (f_account, f_roomID) OUTPUT inserted.* VALUES (@Account, @RoomID)
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userroom_join] TO PUBLIC
AS [dbo];
