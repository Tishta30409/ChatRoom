﻿--顯示LIST用
CREATE PROCEDURE [dbo].[pro_accountQueryList]
AS
	SELECT f_id, f_account, f_password, f_nickName, f_state, f_errorTimes  FROM t_account WITH(NOLOCK)
RETURN 0
GO
GRANT EXECUTE
    ON OBJECT::[dbo].[pro_accountQueryList] TO PUBLIC
    AS [dbo];
