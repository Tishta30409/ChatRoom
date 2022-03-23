--創建帳號
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

		--帳號鎖定
		IF(@isLocked = 1)
			SET @resultCode = 2
		ELSE IF(@tempPassword != @password)
		BEGIN
			PRINT @tempPassword
			PRINT @password
			SET @resultCode = 4
			SET @errorTimes = @errorTimes +1
			--錯誤大於三次
			IF(@errorTimes >=3)
			BEGIN
				SET @isLocked = 1
			END
		END
		ELSE
		BEGIN
			SET @resultCode = 0
			SET @errorTimes = 0
		END

		--更新資料
		UPDATE t_account SET f_isLocked = @isLocked, f_errorTimes = @errorTimes, f_GUID = @guid WHERE f_account = @account 

		--輸出結果
		SELECT @resultCode
		SELECT f_id, f_account, f_password,f_nickName, f_isLocked, f_isMuted, f_errorTimes, f_GUID, f_roomID FROM t_account WHERE f_account =  @account
	END
	ELSE
	BEGIN
		SET @resultCode = 3 
	END
RETURN @resultCode
GO


GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountLogin] TO PUBLIC
    AS [dbo];