--單一查詢 登入時使用
CREATE PROCEDURE [dbo].[pro_accountQuery]
@account VARCHAR(40)
AS
	SELECT f_id, f_account, f_password, f_nickName, f_isLocked, f_isMuted, f_errorTimes  FROM t_account WITH(NOLOCK)  
    WHERE f_account = @account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountQuery] TO PUBLIC
    AS [dbo];
