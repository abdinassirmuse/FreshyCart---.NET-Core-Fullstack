

Use FreshyCartDB
GO

create table [Users]
(
[FullName] varchar (50) not null,
[EmailId] varchar(50) not null CONSTRAINT pk_EmailID PRIMARY KEY,
[Password] varchar(50) not null
)
GO


INSERT INTO Users
Values('Nasir', 'nasir@nasir.com', 'password');
INSERT INTO Users
Values('Test', 'test@test.com', 'password');
GO

CREATE TABLE Products 
(
[ProductId] INT CONSTRAINT pk_ProductID PRIMARY KEY IDENTITY(1,1),
[ProductName] VARCHAR(30) NOT NULL Unique,
[Price] DECIMAL(5, 2) NOT NULL,
[ProductImage] VARCHAR(500) Unique
);
GO
--select * from Products

--Drop table Products

--Truncate Table Products


--Inserting into the Products Table
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Tomatoes', 4.00, 'https://ofg.enh.mybluehost.me/Images/Products/tomatoes-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Bananas', 3.50, 'https://ofg.enh.mybluehost.me/Images/Products/bananas-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Honey Dew Melons', 2.50, 'https://ofg.enh.mybluehost.me/Images/Products/honeydew-melon-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Oranges', 3.50, 'https://ofg.enh.mybluehost.me/Images/Products/Oranges-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Pineapples', 3.76, 'https://ofg.enh.mybluehost.me/Images/Products/Pineapples-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Strawberries', 2.00, 'https://ofg.enh.mybluehost.me/Images/Products/strawberries-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Apples', 3.00, 'https://ofg.enh.mybluehost.me/Images/Products/Apples-ct.jpg'); 
INSERT INTO Products(ProductName, Price, ProductImage)
VALUES
('Watermelon', 3.00, 'https://ofg.enh.mybluehost.me/Images/Products/watermelon-ct.jpg'); 





--Creating the table for the slideshow images
CREATE TABLE SlideShow 
(
[ID] INT CONSTRAINT pk_SlideShowImageID PRIMARY KEY IDENTITY(1,1),
[Name] VARCHAR(30) NOT NULL,
[SlideImage] VARCHAR(500)
);

--select * from SlideShow

--Truncate table SlideShow

--Drop table SlideShow

INSERT INTO SlideShow ([Name], SlideImage)
VALUES
('abundance-agriculture', 'https://ofg.enh.mybluehost.me/Images/SlideShow/abundance-agriculture.jpg'); 
INSERT INTO SlideShow ([Name], SlideImage)
VALUES
('assorted-veggies','https://ofg.enh.mybluehost.me/Images/SlideShow/assorted-veggies.jpg');
INSERT INTO SlideShow ([Name], SlideImage)
VALUES
('cauliflower','https://ofg.enh.mybluehost.me/Images/SlideShow/cauliflower.jpg');
INSERT INTO SlideShow ([Name], SlideImage)
VALUES
('Fruits-in-a-bag','https://ofg.enh.mybluehost.me/Images/SlideShow/Fruits-in-a-bag.jpg');







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
('Apples-ct-150','https://ofg.enh.mybluehost.me/Images/FeaturedProducts/Apples-ct-150.jpg');
INSERT INTO FeaturedProducts ([Name], FPImage)
VALUES
('Tomatoes-ct-150','https://ofg.enh.mybluehost.me/Images/FeaturedProducts/tomatoes-ct-150.jpg');
INSERT INTO FeaturedProducts ([Name], FPImage)
VALUES
('Oranges-ct-150','https://ofg.enh.mybluehost.me/Images/FeaturedProducts/Oranges-ct-150.jpg');


Select * from SlideShow






--Cart Table
CREATE TABLE Cart
(
	[ProductId] INT CONSTRAINT fk_Cart_ProductId REFERENCES Products(ProductId) NOT NULL,
	[EmailId] VARCHAR(50) CONSTRAINT fk_Cart_EmailId REFERENCES Users(EmailId) NOT NULL,
	[ProductName] VARCHAR(30) CONSTRAINT fk_Cart_ProductName REFERENCES Products(ProductName) NOT NULL,
	[ProductImage] VARCHAR(500) CONSTRAINT fk_Cart_ProductImage REFERENCES Products(ProductImage) NOT NULL,
	[Quantity] SMALLINT CONSTRAINT chk_Quantity CHECK(Quantity>0) NOT NULL,
	CONSTRAINT pk_ProductId_EmailId Primary KEY(ProductId,EmailId)
)
GO


--Drop table Cart

--Truncate table Cart

--Select * from Cart


--Stored Procedure to Add product to the Cart Table.
CREATE PROCEDURE sp_AddProductToCart
(
	@ProductId INT,
	@EmailId VARCHAR(50),
	@ProductName VARCHAR(30),
	@ProductImage VARCHAR(500)
)
AS
BEGIN
	DECLARE @retval int
	DECLARE @number int
	BEGIN TRY		
			BEGIN						
				Select @number=Quantity from Cart where (EmailId = @EmailId AND ProductId=@ProductId)

				IF(@number IS NOT NULL)
					BEGIN
						UPDATE Cart SET Quantity=Quantity+1 WHERE ProductId=@ProductId AND ProductName=@ProductName AND EmailId=@EmailId AND ProductImage=@ProductImage
						SET @retval = 1
					END
				ELSE
					BEGIN
						INSERT INTO Cart VALUES (@ProductId,@EmailId, @ProductName, @ProductImage, 1)
						SET @retval = 1
					END				
			END
		SELECT @retval 
	END TRY
	BEGIN CATCH
		SET @retval = -99
		SELECT @retval 
	END CATCH
END
GO

--Drop Proc sp_AddProductToCart
--GO

EXEC sp_AddProductToCart 1, 'nasir@nasir.com', 'Tomatoes', 'https://ofg.enh.mybluehost.me/Images/Products/tomatoes-ct.jpg'
GO

select * from Products
GO

--Function to Fetch products in the Cart Table
CREATE FUNCTION fn_FetchCartProductByEmailId(@EmailId Varchar(50))
RETURNS TABLE 
AS
RETURN (SELECT c.ProductId,p.ProductName,p.Price,c.Quantity,p.ProductImage FROM Cart c JOIN Products p on c.ProductId=p.ProductId WHERE c.EmailId=@EmailId)
GO


Select * from fn_FetchCartProductByEmailId('nasir@nasir.com')




