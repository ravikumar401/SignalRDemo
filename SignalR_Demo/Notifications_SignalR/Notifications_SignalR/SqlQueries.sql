
CREATE DATABASE NotificationsDB
go


ALTER DATABASE NotificationsDB SET ENABLE_BROKER

GO

CREATE TABLE DemoUsers(

UserId INT PRIMARY KEY IDENTITY(1,1),
UserName NVARCHAR(50) ,
Status bit
)
GO

INSERT DemoUsers 
SELECT 'RAVI',1
go
INSERT DemoUsers 
SELECT 'KUMAR',0


SELECT * FROM DemoUsers