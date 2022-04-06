CREATE PROCEDURE [dbo].[pro_userRoomJoin]
	@account NVARCHAR(20),
	@roomID INT,
	@nickName NVARCHAR(20)
AS
	IF EXISTS(SELECT Top 1 1 FROM t_userroom WHERE f_account = @account)
		UPDATE t_userroom WITH(ROWLOCK) SET f_roomID = @roomID, f_nickName = @nickName  OUTPUT inserted.* WHERE f_account = @Account
	ELSE
		INSERT INTO t_userroom (f_account, f_roomID, f_nickName) OUTPUT inserted.* VALUES (@Account, @RoomID, @nickName)
RETURN 0
GO
GRANT EXECUTE
ON OBJECT::[dbo].[pro_userRoomJoin] TO PUBLIC
AS [dbo];
