CREATE PROCEDURE [dbo].[pro_historyAdd]
	@roomID INT,
	@account NVARCHAR(20),
	@nickName NVARCHAR(20),
	@content NVARCHAR(20),
	@createDateTime DATETIME
AS
	INSERT INTO t_history(f_roomID,f_account,f_nickName, f_content, f_createDateTime)
	OUTPUT inserted.*
	VALUES(@roomID, @account, @nickName, @content, @createDateTime)
RETURN 0
GO

GRANT EXECUTE
    ON OBJECT::[dbo].[pro_historyAdd] TO PUBLIC
    AS [dbo];
