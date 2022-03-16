
--創建帳號
CREATE PROCEDURE [dbo].[pro_accountAdd]
	@Account VARCHAR(40) ,
	@Password VARCHAR(40),
	@NickName NVARCHAR(20)
AS
	 DECLARE 
      @ResultCode  INT        = -99
      ,@ResultMsg    NVARCHAR(MAX)  = N'未定義錯誤'

	IF EXISTS(
    SELECT 1 
    FROM t_account 
    WHERE f_account=@Account
    )
	BEGIN
		SET @ResultCode = -1    --檢查該來源會員編號已存在
		GOTO EndProc
	END

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO t_account
			(f_account, f_password, f_nickName)
			OUTPUT inserted.*
			VALUES(@Account, @Password, @NickName)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		--寫入錯誤進行ROLLBACK
		ROLLBACK
	END CATCH

	EndProc:
		SET @ResultMsg = 
		CASE @ResultCode
			WHEN  1 THEN N'檢查完成，註冊會員資料成功'
			WHEN -1 THEN N'檢查該來源會員編號已存在'
			WHEN -99 THEN N'未定義錯誤。'
		END

RETURN @ResultCode
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountAdd] TO PUBLIC
    AS [dbo];