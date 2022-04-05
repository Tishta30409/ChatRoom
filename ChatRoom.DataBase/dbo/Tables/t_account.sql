CREATE TABLE [dbo].[t_account]
(
	f_id INT IDENTITY NOT NULL ,
	f_account VARCHAR(20)  NOT NULL UNIQUE,
	f_password VARCHAR(32)  NOT NULL,
	f_nickName NVARCHAR(10) NOT NULL UNIQUE,
	f_isLocked TINYINT NOT NULL DEFAULT 0,
	f_isMuted TINYINT NOT NULL DEFAULT 0,
	f_errorTimes TINYINT NOT NULL DEFAULT 0,
	f_loginIdentifier NVARCHAR(40)  NULL,
    f_serialNumber BIGINT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED (f_id ASC)
)
