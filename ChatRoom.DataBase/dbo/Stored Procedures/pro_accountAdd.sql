
--創建帳號
CREATE PROCEDURE [dbo].[pro_accountAdd]
	@account VARCHAR(40) ,
	@password VARCHAR(40),
	@nickName NVARCHAR(20)
AS
	 DECLARE 
      @resultCode  INT        = -99
      ,@resultMsg    NVARCHAR(20)  = N'未定義錯誤'

	IF EXISTS(
    SELECT 1 
    FROM t_account 
    WHERE f_account=@account
    )
	BEGIN
		SET @resultCode = -1    --檢查該來源會員編號已存在
		GOTO EndProc
	END

	BEGIN TRY
		BEGIN TRANSACTION
			INSERT INTO t_account
			(f_account, f_password, f_nickName)
			OUTPUT inserted.*
			VALUES(@account, @password, @nickName)
		COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
		--寫入錯誤進行ROLLBACK
		ROLLBACK
	END CATCH

	EndProc:
		SET @resultMsg = 
		CASE @resultCode
			WHEN  1 THEN '註冊會員資料成功'
			WHEN -1 THEN '會員編號已存在'
			WHEN -99 THEN '未定義錯誤'
		END

RETURN @resultCode
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountAdd] TO PUBLIC
    AS [dbo];