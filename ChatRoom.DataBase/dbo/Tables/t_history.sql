CREATE TABLE [dbo].[t_history]
(
	f_id BIGINT IDENTITY NOT NULL ,
	f_account NVARCHAR(20) NOT NULL,
	f_roomID INT NOT NULL,
	f_nickName NVARCHAR(10) NOT NULL,
	f_content NVARCHAR(20) NOT NULL,
	f_createDateTime DATETIME NOT NULL
	CONSTRAINT [PK_history] PRIMARY KEY CLUSTERED (f_id ASC)
)
