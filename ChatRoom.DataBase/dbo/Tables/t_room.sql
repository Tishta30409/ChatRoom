CREATE TABLE [dbo].[t_room]
(
	f_id INT IDENTITY NOT NULL,
	f_roomName NVARCHAR(10) NOT NULL UNIQUE
	CONSTRAINT [PK_room] PRIMARY KEY CLUSTERED ([f_id] ASC)
)
