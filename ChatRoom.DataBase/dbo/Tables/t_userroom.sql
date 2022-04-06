CREATE TABLE [dbo].[t_userroom]
(
	[f_id]  INT IDENTITY NOT NULL , 
    [f_account] NVARCHAR(20) NOT NULL UNIQUE, 
    [f_roomID] INT NOT NULL,
    [f_nickName] NVARCHAR(20) NOT NULL
	CONSTRAINT [PK_userroom] PRIMARY KEY CLUSTERED ([f_id] ASC)
)
