--單一查詢 登入時使用
CREATE PROCEDURE [dbo].[pro_accountQuery]
@Account VARCHAR(40)
AS
	SELECT f_id, f_account, f_password, f_nickName, f_state, f_errorTimes  FROM t_account WITH(NOLOCK)  
    WHERE f_account = @Account
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountQuery] TO PUBLIC
    AS [dbo];
