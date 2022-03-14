CREATE TABLE [dbo].[t_account]
(
	f_id INT IDENTITY NOT NULL ,
	f_account VARCHAR(40)  NOT NULL,
	f_password VARCHAR(40) NOT NULL,
	f_nickName NVARCHAR(20) NOT NULL,
	f_state TINYINT NOT NULL DEFAULT 0,
	f_errorTimes TINYINT NOT NULL DEFAULT 0,
	CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED ([f_id] ASC)
)
