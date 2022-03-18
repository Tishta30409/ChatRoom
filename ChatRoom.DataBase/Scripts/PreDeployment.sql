/*
 預先部署指令碼樣板							
--------------------------------------------------------------------------------------
 此檔案包含要在組建指令碼之前執行的 SQL 陳述式	
 使用 SQLCMD 語法可將檔案包含在預先部署指令碼中			
 範例:      :r .\myfile.sql								
 使用 SQLCMD 語法可參考預先部署指令碼中的變數		
 範例:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [ChatRoom]

IF EXISTS( SELECT * FROM sysobjects WHERE name = 't_account' )
    TRUNCATE TABLE t_account

IF EXISTS( SELECT * FROM sys.tables WHERE name = 't_history' )
TRUNCATE TABLE t_history

IF EXISTS( SELECT * FROM sys.tables WHERE name = 't_room' )
TRUNCATE TABLE t_room