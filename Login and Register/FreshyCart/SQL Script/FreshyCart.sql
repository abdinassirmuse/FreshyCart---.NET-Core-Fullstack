Create database FreshyCartDB

use FreshyCartDB


CREATE TABLE Users 
(
EmailId VARCHAR(30) CONSTRAINT pk_EmailId PRIMARY KEY,
FullName VARCHAR(50) NOT NULL,
[Password] VARCHAR(25) NOT NULL
)
GO

SELECT * FROM Users