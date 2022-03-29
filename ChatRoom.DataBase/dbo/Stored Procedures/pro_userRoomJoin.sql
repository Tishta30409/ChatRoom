CREATE PROCEDURE [dbo].[pro_userRoomJoin]
	@Account NVARCHAR(20),
	@NickName  NVARCHAR(10),
	@RoomID INT
AS
	IF EXISTS(SELECT Top 1 1 FROM t_userroom WHERE f_account = @Account)
		UPDATE t_userroom WITH(ROWLOCK) SET f_roomID = @RoomID  OUTPUT inserted.* WHERE f_account = @Account
	ELSE
		INSERT INTO t_userroom (f_account, f_roomID, f_nickName) OUTPUT inserted.* VALUES (@Account, @RoomID, @NickName)
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomJoin] TO PUBLIC
AS [dbo];
