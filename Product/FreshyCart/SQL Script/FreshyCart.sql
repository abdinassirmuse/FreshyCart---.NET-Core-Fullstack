Create Database FreshyCartDB

Use FreshyCartDB


CREATE TABLE Users 
(
EmailId VARCHAR(30) CONSTRAINT pk_EmailId PRIMARY KEY,
FullName VARCHAR(50) NOT NULL,
[Password] VARCHAR(25) NOT NULL
)

--SELECT * FROM Users

--DROP TABLE Users

INSERT INTO Users
VALUES('test@test.com','test','password')
GO

SELECT * FROM Users

CREATE TABLE Products 
(
[ProductID] INT CONSTRAINT pk_ProductID PRIMARY KEY IDENTITY(1,1),
[ProductName] VARCHAR(30) NOT NULL UNIQUE,
[Price] DECIMAL NOT NULL,
[ProductImage] VARCHAR(500) UNIQUE
);

--select * from Products

--Drop table Products

--Truncate Table Products


--Inserting into the Products Table
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Tomatoes', 4.00, 'http://localhost:21621/Products/tomatoes-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Bananas', 3.50, 'http://localhost:21621/Products/bananas-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Honey Dew Melons', 2.50, 'http://localhost:21621/Products/honeydew-melon-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Oranges', 3.50, 'http://localhost:21621/Products/Oranges-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Pineapples', 3.76, 'http://localhost:21621/Products/Pineapples-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Strawberries', 2.00, 'http://localhost:21621/Products/strawberries-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Apples', 3.00, 'http://localhost:21621/Products/Apples-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Watermelon', 3.00, 'http://localhost:21621/Products/watermelon-ct.jpg'); 

SELECT * FROM Products


--Creating the table for the featured products category
CREATE TABLE FeaturedProducts 
(
[ID] INT CONSTRAINT pk_FeaturedProductID PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL,
[FPImage] VARCHAR(500)
);

--Select * from FeaturedProducts

--Drop table FeaturedProducts


--Inserting pictures for the Featured Products category
INSERT INTO FeaturedProducts([Name], FPImage)
VALUES
('Apples-ct-150','http://localhost:21621/FeaturedProducts/Apples-ct-150.jpg');
INSERT INTO FeaturedProducts ([Name], FPImage)
VALUES
('Tomatoes-ct-150','http://localhost:21621/FeaturedProducts/tomatoes-ct-150.jpg');
INSERT INTO FeaturedProducts ([Name], FPImage)
VALUES
('Oranges-ct-150','http://localhost:21621/FeaturedProducts/Oranges-ct-150.jpg');

SELECT * FROM FeaturedProducts