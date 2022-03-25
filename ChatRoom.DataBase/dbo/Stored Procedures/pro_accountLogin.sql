﻿--創建帳號
CREATE PROCEDURE [dbo].[pro_accountLogin]
	@account VARCHAR(40) ,
	@password VARCHAR(40)
AS

	 CREATE  TABLE #accountTemp
	 (
		f_id int,
		f_account VARCHAR(40),
		f_password VARCHAR(40),
		f_nickName NVARCHAR(20),
		f_isLocked TINYINT,
		f_isMuted TINYINT,
		f_errorTimes TINYINT,
		f_GUID UNIQUEIDENTIFIER
	 )

	 --ResultCode
		--SUCCESS = 0,
        --ACCOUNT_REPEAT = 1,
        --ACCOUNT_LOCKED = 2,
        --ACCOUNT_NOTEXIST = 3,
        --WORNG_PASSWORD = 4,

	--撈出會員資料
	INSERT INTO #accountTemp 
	SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_GUID FROM t_account WHERE f_account =  @account

	DECLARE @resultCode TINYINT
 
	--如果帳號存在
	IF EXISTS(
		SELECT top 1 1  FROM #accountTemp
    )
	BEGIN
		DECLARE @tempPassword  VARCHAR(40) = (SELECT f_password FROM #accountTemp)
		DECLARE @isLocked TINYINT = (SELECT f_isLocked FROM #accountTemp)
		DECLARE @errorTimes TINYINT = (SELECT f_errorTimes FROM #accountTemp)
		DECLARE @guid UNIQUEIDENTIFIER = NEWID()

		IF(@isLocked = 1)
			--錯誤碼帳號鎖定
			SELECT 2
		ELSE IF(@tempPassword != @password)
		BEGIN
			SET @errorTimes = @errorTimes +1
			--錯誤大於三次
			IF(@errorTimes >=3)
			BEGIN
				SET @isLocked = 1
				--錯誤碼帳號鎖定
				SELECT 2
			END
			ELSE
				--錯誤碼 密碼錯誤
				SELECT 4
		END
		ELSE
		BEGIN
			SELECT 0
			SET @errorTimes = 0
		END

		--更新資料
		UPDATE t_account SET f_isLocked = @isLocked, f_errorTimes = @errorTimes, f_GUID = @guid, f_roomID = NULL
		OUTPUT inserted.* 
		WHERE f_account = @account 

	END
	ELSE
	BEGIN
		--錯誤碼 帳號不存在
		SELECT 3
	END
RETURN 0
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountLogin] TO PUBLIC
    AS [dbo];