
CREATE DATABASE Shopping_Cart
GO

alter procedure sp_InsertCustomers(
@CustomerId BIGINT  output ,--PRIMARY KEY IDENTITY(1001,1),
@FirstName VARCHAR(50),
@LastName VARCHAR(50),
@Address1 VARCHAR(200),
@ZipCode varchar(5),
@City VARCHAR(50),
@State VARCHAR(50))
As
Begin
set nocount on
insert into Customers (
FirstName,
LastName,
Address1,
ZipCode,
City,
State)
values(
@FirstName,
@LastName,
@Address1,
@ZipCode,
@City,
@State)
RETURN SCOPE_IDENTITY()
end
GO

EXECUTE sp_InsertCustomers 1009,'aakash','chetty','bargur','1212','chennai','tamilnadu'
GO

exec sp_UpdateEmployee 1012,'hello','world','123','456','aaa','bbb'
GO

exec sp_deleteCustomers 1016
GO

select * from Customers
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('John','Smith','No-45 Peter road',1111, 'Denver','Colorado')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Paul','O''Brien','No-122 Nehru street ',2222,'Denver','Colorado')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Sam','Vel','No-32 Balaji street',3333,'Denver','Colorado')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Thulasi','Krishnan','No-32 St Mary road',4444,'Denver','Colorado')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Oliver','Charlotte','No-56 St Peter road',5555,'Denver','Colorado')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('James','Smith','No-66 John Street',6666,'California','Sacramento')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Robert','Willam','No-77 Willams Street',7777,'Hawaii','Honolulu')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('David','White','No-66 Anna street',8888,'Texas','Austin')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Joseph','Clark','No-56 Gandhi street',9999,'Ohio','Columbus')
GO

INSERT INTO Customers(FirstName,LastName,Address1,ZipCode,City,State) VALUES('Peter','Joe','North Main raod',1100,' Florida','Tallahassee')
GO

SELECT * FROM Customers
GO

SELECT FirstName,LastName from Customers
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-14 12:45:22',1001)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-15 02:02:34',1002)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-15 02:02:34',1003)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-15 04:24:37',1004)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-16 05:25:44',1005)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-16 09:45:33',1006)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-16 09:45:34',1007)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-16 09:45:33',1008)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-17 11:34:54',1009)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-17 04:23:56',1004)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-18 09:22:54',1006)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-18 07:23:34',1008)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-18 09:32:44',1003)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-19 08:42:54',1006)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-19 04:22:24',1008)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-21 06:42:24',1009)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-21 04:52:14',1007)
GO

INSERT INTO Orders(OrderDate,CustomerId) VALUES('2022-11-21 07:32:54',1004)
GO

SELECT * FROM Orders
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price, OrderId) VALUES('Hard Disk',2,3000,10001)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('KeyBoard and Monitor',1,2500,10002)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',2,5000,10003)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',5,4500,10004)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Mouse',6,6000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',4,6000,10006)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Keyboard',5,7500,10007)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('KeyBoard and Monitor',3,7500,10008)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',1,1500,10009)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Laptop',1,60000,10003)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Keyboard',2,5000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Printer',1,10000,10007)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',3,7500,10002)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Motherbox',3,6000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Controller',4,2000,10008)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Router',1,2000,10009)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Keyboard',2,5000,10001)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',3,4500,10003)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',4,6000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',3,7500,10004)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',2,3000,10007)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',3,4500,10008)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',3,7500,10002)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',3,7500,10006)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',3,7500,10004)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Hard Disk',3,7500,10002)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Monitor',3,7500,10007)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('Router',3,7500,10009)
GO

delete  FROM OrderDetails where OrderId = 10010
GO

DELETE FROM Orders where CustomerId = 1010
GO

SELECT * FROM Customers
GO

SELECT * FROM Orders
GO

SELECT * FROM OrderDetails where OrderId = 10010
GO

-- DML Query - Find the date on which maximum number of orders created

SELECT 
	Orderdate ,
	COUNT(OrderId) AS Maximum_Orders
FROM
	Orders
GROUP BY
	OrderDate
ORDER BY
	Maximum_Orders DESC
GO

SELECT 
	CONVERT(DATE,OrderDate),
	COUNT(OrderId) AS Maximum_Orders
FROM 
	Orders 
GROUP BY
	CONVERT(DATE,OrderDate)
ORDER BY
	Maximum_Orders DESC 


/*	Stored Procedure - Get First Name and Last Name of all Customers who has ordered at least one product
•	We need to list the customer First Name and Last Name of customers who  has ordered at least one product.*/
GO

WITH CTE AS
(SELECT
TOP 1
	ProductName,
	COUNT(ProductName) AS TotalCount
FROM
	OrderDetails
GROUP BY
	ProductName
ORDER BY 
	TotalCount DESC)
			
SELECT 
	*
FROM
	CTE
GO

SELECT
	CONVERT(DATE,OrderDate) AS DATE,
	OrderId,
	CustomerId
FROM 
	Orders
GROUP BY
	OrderId,
	CustomerId,
	OrderDate
ORDER BY 
	OrderDate DESC
GO

SELECT
TOP 1
	*
FROM 
	Orders
ORDER BY
	OrderId DESC
GO

SELECT
	OrderId,
	COUNT(ProductName) AS Product 
FROM 
	OrderDetails
GROUP BY 
	OrderId
HAVING
	COUNT(ProductName)>1
GO

SELECT
	OrderId,
	SUM(Price) AS Total_Price
FROM 
	OrderDetails
GROUP BY
	OrderId
GO

SELECT
	ProductName,
	COUNT(*) AS Count
FROM 
	OrderDetails
GROUP BY 
	ProductName
ORDER BY
	COUNT(*)DESC
GO

SELECT
	ProductName,
	COUNT(*) AS COUNT
FROM 
	OrderDetails
GROUP BY 
	ProductName
ORDER BY
	COUNT
GO

SELECT 
	c.CustomerId,
	SUM(Price) AS Total_Price 
FROM 
	Customers c
	JOIN Orders o ON c.CustomerId = o.CustomerId
	JOIN OrderDetails od ON o.OrderId =od.OrderId
GROUP BY
	c.CustomerId
GO

SELECT 
TOP 1
	c.CustomerId,
	SUM(Price) AS Amount
FROM 
	Customers c 
	JOIN Orders o ON c.CustomerId = o.CustomerId
	JOIN OrderDetails od ON od.OrderId = o.OrderId
GROUP BY
	c.CustomerId
ORDER BY
	Amount DESC
GO

SELECT 
	CONVERT(DATE,OrderDate) AS DATE,
	Quantity,ProductName
FROM 
	Orders o
	JOIN OrderDetails od ON o.OrderId = od.OrderId
GROUP BY
	OrderDate,
	Quantity,
	ProductName
ORDER BY 
	Quantity DESC
GO

SELECT 
TOP 5 
	FORMAT (orderDate , 'dddd, MMMM, yyyy') AS DAY,
	ProductName,
	Quantity
FROM 
	Orders o
	JOIN OrderDetails od ON o.OrderId = od.OrderId
GROUP BY
	OrderDate,
	Quantity,
	ProductName
ORDER BY
	Quantity DESC
GO

SELECT 
	Employee.Id,
	Employee.FirstName,
	Employee.LastName,
	SUM(DATEDIFF("second", call.start_time, call.end_time)) AS call_duration_sum 
FROM
	call INNER JOIN employee ON call.employee_id = employee.id
GROUP BY 
	employee.id, 
	employee.first_name,
	employee.last_name 
ORDER BY
	employee.Id ASC;
GO

SELECT
	employee.id,
	employee.first_name,
	employee.last_name,
	call.start_time,
	call.end_time,
	DATEDIFF("second", call.start_time, call.end_time) AS call_duration,duration_sum.call_duration_sum,
	CAST( CAST(DATEDIFF("second", call.start_time, call.end_time) AS decimal(7,2)) / CAST(duration_sum.call_duration_sum AS decimal(7,2)) AS decimal(4,4)) AS call_percentage 
	FROM 
		call INNER JOIN employee ON call.employee_id = employee.id
GO

SELECT
	[empid],
	[firstname] + ' ' +[lastname] AS Name ,
	[education],
	[occupation],
	[yearlyincome],
	[sales]  
FROM 
	[employees 2015]  
WHERE
	yearlyincome >= 70000 UNION SELECT [empid],[firstname] + ' ' +[lastname] as Name,
	[education],
	[occupation],
	[yearlyincome], 
	[sales]  
FROM
	[employees 2016]  
WHERE
	yearlyincome < 70000 
ORDER BY
	yearlyincome DESC
GO

SELECT * FROM CustomerInfo
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('John','Smith', '2002-06-17 12:45:22',1 ,'johnsmith12@gmail.com',9500554093)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Paul','O''Brien','2001-02-09 09:45:34',1,'paulbrien@gmail.com',9876543210)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Sam','Vel','1999-07-08 11:34:54',1,'samvel@gmail.com',8765432109)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Peter','Joe','1996-02-19 09:22:54',1,'peterjoe@gmail.com',6543210987)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Thulasi','Krishnan','1997-06-23 05:42:34',1,'thulasikrishna12@gmail.com',6213478035)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Oliver','Charlotte','1998-01-24 07:32:54',1,'oliverchatlte@gmail.com',9807654312)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('James','Smith','1980-09-14 06:42:24',1,'jamessmith134@gmail.com',9856821785)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Ruby','Willam','2003-05-21 07:23:34',0,'robertwillam131@gmail.com',9812345674)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('David','White','2000-09-13 04:24:37',1,'davidwhite14@gmail.com',9357281225)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('Joseph','Clark','2001-05-15 12:23:44',1,'josephclark@gmailcom',8003581680)
GO

INSERT INTO CustomerInfo (FirstName,LastName,Date_of_Birth,Gender,Email,Phone_Number) VALUES ('JENNY','Clark','2002-06-17 08:42:54',0,'davidclark165@gamil.com',6583911338)
GO

exec sp_rename 'Customers1', 'CustomerInfo'
GO

select * from CustomerInfo
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Acorn Street','No-45 Peter road', 'Denver','Colorado',60719,1001)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Albert Cuypstraat street','No-122 GanEdhi street ','Denver','Colorado',60709,1002)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Amber Road street','No-32 Bharathi street','Denver','Colorado',60709,1003)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Appian Way ','North Main raod',' Florida','Tallahassee',60215,1004)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Atlanterhavsveien street ','No-56 St Peter road','Denver','Colorado',60709,1005)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Aviles Street','No-66 John Street','California','Sacramento',60815,1006)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Beale Street','No-66 John Street','California','Sacramento',60805,1007)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Bleeker Street','No-77 Willams Street','Hawaii','Honolulu',60503,1008)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Blue Ridge Parkway','No-66 Johnson street','Texas','Austin',60149,1009)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Boston Post Road','No-56 Garthik street','Ohio','Columbus',60215,1010)
GO

INSERT INTO CustomerAddress (Address1,Address2,State,City,ZipCode,CustomerID) VALUES ('Calle Estafeta street','No-65 kathik street','Texas','Austin',60505,1011)
GO

SELECT
	* 
FROM 
	CustomerAddress
GO

SELECT
	DATEDIFF(YY,Date_of_Birth,GETDATE()) AS  Age
FROM 
	CustomerInfo
GO

SELECT 
	[dbo].[AgeInfo]('1998-04-11')
GO

--ALTER TABLE Customers1  Rename To CustomerInfo ;   
 
  SELECT * FROM CustomerDetails
GO

--5.	DML Query - Find the Customers who never ordered a product named Hard Disk using LEFT OUTER JOIN. The query should not use subquery.

SELECT 
	C.FirstName,
	C.LastName,
	od.ProductName,
	od.OrderId
FROM
	Customers C 
	LEFT OUTER JOIN Orders O ON C.CustomerId = O.CustomerId 
	LEFT OUTER JOIN OrderDetails OD ON O.OrderId = OD.OrderId and ProductName != 'Hard Disk'
WHERE 
	od.OrderId  is not null
GO

select * from OrderDetails where OrderId = 10007
GO

select 
distinct
	o.OrderId,
	od.ProductName 
from 
	Orders o
	left outer join OrderDetails od on o. OrderId = od.OrderId 
where 
	od.ProductName != 'Hard Disk'
GO

--group by o.OrderId

SELECT C.CustomerID , C.FirstName,C.LastName 
    FROM Customers C 
    WHERE NOT EXISTS(SELECT O.CustomerID FROM Orders O 
                    JOIN OrderDetails OD 
                    ON O.OrderID =OD.OrderID
                    WHERE c. CustomerID =O.CustomerID  and ProductName ='Hard disk')
GO

--select * from OrderDetails where OrderDetailsId = 100010
--select * from OrderDetails where OrderDetailsId = 100023


--6.	DML Query - Get the customers First Name, Last Name and the date on which they ordered the Mouse first time

SELECT
TOP 1
	FirstName,
	LastName,
	MIN(CONVERT(DATE,OrderDate)) AS DATE
FROM 
	Customers C
	JOIN Orders O on c.CustomerId = O.CustomerId
	JOIN OrderDetails od on O.OrderId = OD.OrderId
WHERE
	ProductName = 'Mouse'
GROUP BY 
	FirstName,
	LastName,
	OrderDate
ORDER BY
	MIN(OrderDate)

--7.	Stored Procedure - Create a stored procedure to create a customer
--INSERTING DATA IN SINGLE PROCEDURE FOR BOTH TABLES
GO

ALTER PROCEDURE CreateCustomer
		@FirstName VARCHAR(100),
         @LastName VARCHAR(100) ,
        @Address1 VARCHAR(100),
		@Address2 VARCHAR(100),
        @City VARCHAR(50),
         @State VARCHAR(50),
         @ZipCode VARCHAR(5),
         @Gender BIT,
         @Date_of_Birth DATETIME,
         @Email VARCHAR(50),
         @Phone_Number BIGINT   
AS
INSERT INTO CustomerInfo(
		FirstName,
         LastName,
         Gender, 
         Date_of_Birth,
         Email,
         Phone_Number )  
 VALUES (
		@FirstName,
		@LastName,
		@Gender,
		@Date_of_Birth,
		@Email,
		@Phone_Number
 )
 DECLARE @CustomerId BIGINT 
 SET @CustomerId = (SELECT TOP 1 CustomerID FROM CustomerInfo ORDER BY CustomerID DESC)
 INSERT INTO CustomerAddress(
			CustomerID,
            Address1,
            Address2 ,
            State,
            City,
            ZipCode)
VALUES (
		@CustomerId,
	     @Address1,
		 @Address2,
		 @State,
		 @City,
		 @ZipCode
		 )
GO

EXECUTE CreateCustomer 
	'aakash','chetty','add1','add2','chennai','triplicane',98987,1,'1998-04-11','aakashchetty54@gmail',1212121212
GO

select * from CustomerAddress
GO

select * from CustomerInfo

--InLine Table Functions
GO

SELECT * FROM [dbo].[CustomersByGender] (0)
GO

--INLINE BY JOINS

SELECT C.FirstName,C.Gender,CA.City FROM [dbo].[CustomersByGender](1) C
JOIN CustomerAddress CA ON C.CustomerID = CA.CustomerID
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('Hard Disk','Computer Peripherals')
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('KeyBoard','Computer Peripherals')
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('Monitor','Computer Peripherals')
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('i3 processor','Computer Processors')
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('i5 processor','Computer Processors')
GO

INSERT INTO Products (ProductName,ProductCategoryName ) VALUES ('i7 processor','Computer Processors')
GO

SELECT * FROM Products P
GO

SELECT * FROM  OrderDetails
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i3 processor',1,60000,10003)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i5 processor',1,60000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i7 processor',1,60000,10008)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i3 processor',1,60000,10003)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i5 processor',1,60000,10005)
GO

INSERT INTO OrderDetails(ProductName,Quantity,Price,OrderId) VALUES('i7 processor',1,60000,10008)
GO

ALTER TABLE
	OrderDetails 
 ADD 
	ProductID BIGINT FOREIGN KEY REFERENCES Products(ProductID) NULL
GO

--BULK UPDATE
 UPDATE
	OrderDetails 
SET 
	ProductId = P.ProductId 
 FROM
	OrderDetails OD 
	INNER JOIN Products P ON OD.ProductName = P.ProductName
GO

UPDATE OrderDetails SET ProductName = 'KeyBoard' WHERE ProductName ='KeyBoard and Monitor'
GO

UPDATE OrderDetails SET ProductName = 'Monitor' WHERE ProductName ='Router'
GO

UPDATE OrderDetails SET ProductName = 'i3 Processor' WHERE ProductName ='Controller'
GO

UPDATE OrderDetails SET ProductName = 'i5 Processor' WHERE ProductName ='Mouse'
GO

UPDATE OrderDetails SET ProductName = 'Monitor' WHERE ProductName ='Laptop'
GO

UPDATE OrderDetails SET ProductName = 'i7 Processor' WHERE ProductName ='Printer'
GO

UPDATE OrderDetails SET ProductName = 'Monitor' WHERE ProductName ='MotherBox'
GO

--	Alter the column productid as not-null column

 ALTER TABLE OrderDetails 
 ALTER COLUMN ProductID BIGINT NOT NULL
GO

select * from Customers
GO

/* ----- REFFERENCES
ALTER TABLE 
	Customers
ADD 
	Created_By_User1 VARCHAR(50),
    Created_Date1 DATETIME default getdate(),
    Modified_Date1 DATETIME,
    Modified_By1 VARCHAR(50);

	
	alter table  Customers drop column  Created_By_User1,Modified_Date1


	--we cant alter more than one column
ALTER TABLE 
	Customers
alter column
	--Created_By_User VARCHAR(50)not null,
    Created_Date DATETIME not null
	*/
    

UPDATE
	Products
set 
	Created_By_User ='Aakash',
	Created_Date = GETDATE()-1,
	Modified_By ='Robin',
	Modified_Date = GETDATE()
GO

select * from Customers
GO

select * from CustomerAddress
GO

select * from CustomerInfo
GO

select * from OrderDetails
GO

select * from Orders
GO

select * from Products
GO

ALTER TABLE 
	Customers
ADD 
	Created_By_User VARCHAR(50),
    Created_Date DATETIME,
    Modified_Date DATETIME ,
    Modified_By VARCHAR(50);
GO

ALTER TABLE 
	CustomerAddress
ADD 
	Created_By_User VARCHAR(50),
    Created_Date DATETIME,
    Modified_Date DATETIME ,
    Modified_By VARCHAR(50);
GO

ALTER TABLE 
	OrderDetails
ADD 
	Created_By_User VARCHAR(50),
    Created_Date DATETIME,
    Modified_Date DATETIME ,
    Modified_By VARCHAR(50);
GO

ALTER TABLE 
	Orders
ADD 
	Created_By_User VARCHAR(50),
    Created_Date DATETIME,
    Modified_Date DATETIME ,
    Modified_By VARCHAR(50);
GO

ALTER TABLE 
	Products
ADD 
	Created_By_User VARCHAR(50),
    Created_Date DATETIME,
    Modified_Date DATETIME ,
    Modified_By VARCHAR(50);
GO

select * from Customers
GO

select * from CustomerInfo
GO

select * from Orders
GO

select * from CustomerAddress
GO

select * from OrderDetails
GO

select * from Products
GO

--------------------------------- PHASE - 6  -------------------------------------------------------------

	USE [Shopping_Cart]
GO

IF OBJECT_ID('Customers', 'U') IS NOT NULL
BEGIN
PRINT 'Table exists.'
END
ELSE
BEGIN
PRINT 'Table does not exist.'
END
GO

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA .TABLES  WHERE TABLE_NAME  = 'Customers')
BEGIN 
--The following statement was imported into the database project as a schema object and named dbo.Customers.
--CREATE TABLE Customers(
--    CustomerID  BIGINT    IDENTITY(1001,1)PRIMARY KEY,
--    FirstName VARCHAR(50),
--    LastName VARCHAR(50),
--    Address VARCHAR(500),
--    ZipCode VARCHAR(50),
--    City VARCHAR(50),
--    State VARCHAR(50)    
--)
    
PRINT 'Table Customers Successfully Created'
END
ELSE
BEGIN
PRINT 'Table Customers Already Exists'
END
GO

IF  EXISTS (select * from sys.VIEWS where  Name = 'CustomerDetails'  and type = 'V')
DROP VIEW CustomerDetails
GO

/*BEGIN
PRINT 'VIEW ALREADY EXISTS'
END
ELSE 
BEGIN
PRINT 'VIEW CREATED'
END
*/



--go
--CREATE VIEW [CustomerDetails] 
--AS 
--SELECT
--	FirstName,
--    LastName ,
--    Date_of_Birth ,
--CASE 
--WHEN  Gender = 1  THEN 'male '
--WHEN  Gender = 0  THEN 'female' 
--ELSE NULL
--END
--	Gender,
--    Email,
--    Phone_Number,
--     [dbo].[AgeInfo](Date_of_Birth) as Age 
--FROM 
--	CustomerInfo 
--GO
--PRINT 'View CustomerDetails Created Sucessfully '

--PRINT 'View CustomerDetails Already Exists'

--GO

IF OBJECT_ID('CustomerDetails', 'V') IS NOT NULL

    DROP VIEW CustomerDetails
GO

SELECT * FROM [CustomerDetails]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'CUSTOMERSINFO')
DROP PROCEDURE CUSTOMERSINFO
GO

EXECUTE [dbo].[CUSTOMERSINFO]
GO

IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'[dbo].[CustomersByGender]')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
 select 'function exists 1'
GO

IF   EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'CustomerID') 
             AND parent_object_id = OBJECT_ID(N'Orders'))
 --The following statement was imported into the database project as a schema object and named dbo.Orders.
--CREATE TABLE Orders(
-- OrderID BIGINT IDENTITY (10001,1)PRIMARY KEY,
-- OrderDate DATETIME,
-- CustomerID BIGINT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID)
-- )

GO

SELECT
	o.OrderId,
	o.OrderDate
FROM 
	Orders  as O
WHERE 
	NOT EXISTS(SELECT
					O.OrderId 
		       FROM
					Orders 
                    JOIN OrderDetails OD  ON	O.OrderID =OD.OrderID
               WHERE 
					o.OrderId = od.OrderId and  ProductName ='Monitor')
GO

select * from Orders o inner join OrderDetails od on o.OrderId = od.OrderId where od.ProductName = 'Monitor'
GO

select * from Orders
GO

select * from OrderDetails
GO

select * from Products
GO

select
	o.OrderId,
	o.OrderDate,
	od.ProductName
from
	Orders o
	inner join OrderDetails od on o.OrderId = od.OrderId
where 
	od.ProductName = 'Keyboard'
order by 
	o.OrderDate
GO

select
	o.OrderId,
	od.ProductName
from 
	Orders o
	inner join OrderDetails od on o.OrderId = od.OrderId
where
	od.ProductName = 'Hard Disk'
order by 
	o.OrderDate desc
GO

SELECT
	o.OrderID,
	o.orderDate,
	p.ProductCategoryName,'Internal Procressor'as processor
FROM  
	OrderDetails od
    JOIN Products  p ON od.ProductID  =p.productID  
    JOIN Orders o  ON od.OrderID  =o.OrderID  
WHERE
	p.ProductCategoryName ='Computer processors'
GO

select * from CustomerInfo
GO

EXECUTE SP_PRODUCTSTABLE 'KeyBoard'
GO


  DECLARE @SQL nvarchar(1000)    
    DECLARE @PRODUCTID varchar(50)
    SET @PRODUCTID = '102'
    SET @SQL = 'SELECT ProductID,PRODUCTNAME,ProductCategoryName FROM PRODUCTS where ProductID = '+ @PRODUCTID
    EXEC (@SQL)

	select * from Products

/*
GO
ALTER PROCEDURE SP_INSERTUPDATE
	
         @Address1 VARCHAR(100),
		 @Address2 VARCHAR(100),
         @State VARCHAR(50),
		 @City VARCHAR(50),
         @ZipCode VARCHAR(5),
		 @CustomerID bigint,
         @Created_By_User VARCHAR(50),
         @Modified_By VARCHAR(50)
AS
BEGIN
IF  EXISTS (SELECT * FROM CustomerAddress  WHERE CustomerID = @CustomerID)
UPDATE CustomerAddress
SET Address1 = @Address1,Address2 = @Address2,State = @State,City = @City,ZipCode = @ZipCode,
	 Modified_Date = getdate(),Modified_By = @Modified_By
WHERE CustomerID = @CustomerID
ELSE
INSERT INTO CustomerAddress(Address1,Address2,State,City,ZipCode,CustomerID,Created_By_User,Created_Date)
VALUES(@Address1,@Address2,@State,@City,@ZipCode,@CustomerID,@Created_By_User,Getdate())
END

exec dbo.SP_INSERTUPDATE
'add1','add2','triplicane','chennai',98987,1014,'Monish','Aakash'
 
 delete from CustomerAddress where Modified_By = 'Aakash'
 */


GO

--Syntax Error: Incorrect syntax near 1..
----39.	Find the First name , Last name and amount second top most customer who has order large sum of amounts--pagination performance faster
--
--SELECT 
--	c.FirstName,
--	c.LastName,
--	SUM(Price) AS Amount 
--FROM 
--	Customers c
--	JOIN Orders o ON c.CustomerId = o.CustomerId
--	JOIN OrderDetails od ON o.OrderId = od.OrderId
--GROUP BY 
--	c.FirstName,
--	c.LastName
--ORDER BY
--	Amount DESC
--	OFFSET 1 ROWS
--FETCH NEXT
--	1
--ROWS
--	ONLY
--
--
--
--
------------------------------------------------------------          ---------------------------------------------------------------------------------
--                                                         -- PHASE-2-- 
------------------------------------------------------------          ---------------------------------------------------------------------------------
--1.	Format the following query as per the coding standards defined above
--
--SELECT
--	*
--FROM 
--	Patient 
--ORDER BY
--	PatientId
--
--SELECT
--	E.Id,
--	E.Code,
--	E.FirstName,
--	E.LastName,
--	L.Code,
--	L.Descr 
--FROM 
--	Employees E INNER JOIN Location L ON E.LocationId = L.Id;

GO

--Syntax Error: Incorrect syntax near INNNER.
--INNNER JOIN (SELECT employee.id,SUM(DATEDIFF("second", call.start_time, call.end_time)) AS call_duration_sum
--	FROM 
--		call INNER JOIN employee ON call.employee_id = employee.id
--	GROUP BY 
--		employee.id) AS duration_sum ON employee.id = duration_sum.id 
--	ORDER BY
--		employee.id ASC,call.start_time ASC;



GO
