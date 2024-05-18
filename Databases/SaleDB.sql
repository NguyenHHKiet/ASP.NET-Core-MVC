CREATE DATABASE SaleDB;
GO

USE SaleDB;
GO

----1. Xây dựng cấu trúc bảng: Khách hàng – Mặt hàng – Đơn hàng
CREATE TABLE Customers(
----CustomerID UNIQUEIDENTIFIER DEFAULT NEWID(),
	CustomerID INT PRIMARY KEY IDENTITY(1,1),
	UserName NVARCHAR(50),
	Email NVARCHAR(50),
	Phone NVARCHAR(50),
	Address NVARCHAR(50),
);
GO

CREATE TABLE Items(
	ItemID INT PRIMARY KEY IDENTITY(1,1),
	ItemName NVARCHAR(250),
	Description NVARCHAR(250),
	Price DECIMAL(10,2),
	StockQuantity INT,
);
GO

CREATE TABLE Orders(
	OrderID INT PRIMARY KEY IDENTITY(1,1),
	CustomerID INT,
	OrderDate DATE,
	TotalAmount DECIMAL(10,2),
	FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

--Bảng OrderDetails sẽ chứa thông tin chi tiết về từng đơn hàng, bao gồm những mặt hàng nào đã được đặt hàng và số lượng của chúng.
CREATE TABLE OrderDetails(
	OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
	OrderID INT,
	ItemID INT,
	Quantity INT,
	Price DECIMAL(10,2),
	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);
GO

-- Bảng Customers
INSERT INTO Customers (UserName, Email, Phone, Address) VALUES
('john_doe', 'john@example.com', '123-456-7890', '123 Main St, Anytown, USA'),
('jane_smith', 'jane@example.com', '234-567-8901', '456 Oak St, Othertown, USA'),
('alice_jones', 'alice@example.com', '345-678-9012', '789 Pine St, Sometown, USA'),
('bob_brown', 'bob@example.com', '456-789-0123', '101 Maple St, Anytown, USA'),
('charlie_white', 'charlie@example.com', '567-890-1234', '202 Elm St, Othertown, USA'),
('david_green', 'david@example.com', '678-901-2345', '303 Birch St, Sometown, USA'),
('eve_black', 'eve@example.com', '789-012-3456', '404 Cedar St, Anytown, USA'),
('frank_gray', 'frank@example.com', '890-123-4567', '505 Walnut St, Othertown, USA'),
('grace_red', 'grace@example.com', '901-234-5678', '606 Chestnut St, Sometown, USA'),
('henry_blue', 'henry@example.com', '012-345-6789', '707 Poplar St, Anytown, USA');

-- Bảng Items
INSERT INTO Items (ItemName, Description, Price, StockQuantity) VALUES
('Laptop', '15-inch display, 8GB RAM, 256GB SSD', 999.99, 10),
('Smartphone', '6.5-inch display, 128GB storage', 599.99, 20),
('Headphones', 'Noise-cancelling, wireless', 199.99, 30),
('Tablet', '10-inch display, 64GB storage', 399.99, 15),
('Smartwatch', 'Fitness tracking, GPS', 149.99, 25),
('Camera', '20MP, 4K video', 499.99, 12),
('Printer', 'Wireless, all-in-one', 89.99, 50),
('Monitor', '27-inch, 4K resolution', 299.99, 8),
('Keyboard', 'Mechanical, RGB backlight', 79.99, 40),
('Mouse', 'Wireless, ergonomic', 49.99, 35);

-- Bảng Orders
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount) VALUES
(1, '2024-05-01', 1199.98),
(2, '2024-05-03', 599.99),
(3, '2024-05-05', 199.99),
(4, '2024-05-07', 399.99),
(5, '2024-05-09', 149.99),
(6, '2024-05-11', 499.99),
(7, '2024-05-13', 89.99),
(8, '2024-05-15', 299.99),
(9, '2024-05-17', 79.99),
(10, '2024-05-19', 49.99);

-- Bảng OrderDetails
INSERT INTO OrderDetails (OrderID, ItemID, Quantity, Price) VALUES
(1, 1, 1, 999.99),
(1, 3, 1, 199.99),
(2, 2, 1, 599.99),
(3, 3, 1, 199.99),
(4, 4, 1, 399.99),
(5, 5, 1, 149.99),
(6, 6, 1, 499.99),
(7, 7, 1, 89.99),
(8, 8, 1, 299.99),
(9, 9, 1, 79.99),
(10, 10, 1, 49.99),
(2, 9, 2, 159.98),
(3, 6, 1, 499.99),
(4, 8, 2, 599.98);

--2. Viết script phát sinh dữ liệu random: Khách hàng (100 dòng)  – Mặt hàng (100 dòng) – Đơn hàng 
--(1 triệu dòng, thời gian bán trong vòng 2 tháng liên tục): 
--Bắt buộc mã hàng và khách hàng phải tồn tại trong 2 bảng danh sách.

--Thêm 100 dòng random customers
DECLARE @i INT = 0;
WHILE @i < 100
BEGIN
	INSERT INTO Customers (UserName, Email, Phone, Address) VALUES
	(
		CONCAT('username', @i),
		CONCAT('user', @i, '@asoft.com'),
		CONCAT('84-', RIGHT('000' + CAST(CEILING(RAND() * 9999) AS VARCHAR), 4)),
		CONCAT(CAST(FLOOR(RAND() * 9999) AS VARCHAR), ' Street')
	);
	SET @i = @i + 1;
END;
--Thêm 100 random items
DECLARE @j INT = 0;
WHILE @j < 100
BEGIN
	INSERT INTO Items (ItemName, Description, Price, StockQuantity) VALUES
	(
		CONCAT('Item', @j),
		CONCAT('Description for Item', @j),
		CAST(ROUND((RAND() * 1000), 2) AS DECIMAL(10, 2)),
		FLOOR(RAND() * 500)
	);
	SET @j = @j + 1;
END;
--Đơn hàng (1 triệu dòng, thời gian bán trong vòng 2 tháng liên tục)
--Nếu tôi bán được 1 triệu đơn hàng trong vào 2 tháng theo thị trường => Tôi sẽ là một triệu phú đô la💲
DECLARE @startDate DATE = '2023-12-01';
DECLARE @endDate DATE = '2024-02-01';
DECLARE @k INT = 0;
DECLARE @totalOrders INT = 1000000;
WHILE @k < @totalOrders
BEGIN
	DECLARE @randomCustomerID INT = (SELECT TOP 1 CustomerID FROM Customers ORDER BY NEWID());
    DECLARE @randomItemID INT = (SELECT TOP 1 ItemID FROM Items ORDER BY NEWID());
    DECLARE @randomOrderDate DATE = DATEADD(DAY, ABS(CHECKSUM(NEWID()) % DATEDIFF(DAY, @startDate, @endDate)), @startDate);
    DECLARE @randomQuantity INT = FLOOR(RAND() * 10) + 1;
    DECLARE @randomPrice DECIMAL(10, 2) = (SELECT Price FROM Items WHERE ItemID = @randomItemID);

	--Thêm dòng vào Orders
    INSERT INTO Orders (CustomerID, OrderDate, TotalAmount)
    VALUES (@randomCustomerID, @randomOrderDate, @randomQuantity * @randomPrice);

    --Khi chèn một hàng mới vào bảng này, bạn có thể sử dụng SCOPE_IDENTITY để lấy giá trị CustomerID mới được tạo ra:
	DECLARE @newOrderID INT = SCOPE_IDENTITY();

	--Thêm dòng vào OrderDetails 
    INSERT INTO OrderDetails (OrderID, ItemID, Quantity, Price)
    VALUES (@newOrderID, @randomItemID, @randomQuantity, @randomPrice);

	SET @k = @k + 1;
END;

--3. Tạo Table Index cho đơn hàng theo năm, tháng.
-- 1. Thêm cột tính toán OrderYearMonth của năm, tháng
ALTER TABLE Orders
ADD OrderYearMonth AS (YEAR(OrderDate) * 100 + MONTH(OrderDate));
-- 2. Tạo 1 indexing có cột OrderYearMonth
CREATE INDEX IX_Orders_OrderYearMonth ON Orders (OrderYearMonth);
---- Example:
SELECT *
FROM Orders
WHERE OrderYearMonth = 202312;
----Sau khi tạo index này, các truy vấn như:
SELECT * FROM Orders WHERE OrderDate = '2024-01-30';
----sẽ nhanh hơn vì SQL Server có thể sử dụng index để tìm các hàng có OrderDate bằng '2024-05-01' thay vì quét toàn bộ bảng Orders.
----Trong SQL, INDEX là một cấu trúc dữ liệu được tạo ra trên một hoặc nhiều cột của bảng nhằm cải thiện tốc độ truy vấn dữ liệu. 
----Index giúp tăng hiệu suất của các câu lệnh SELECT, JOIN, ORDER BY, và GROUP BY bằng cách cung cấp một cách truy cập nhanh chóng đến các hàng dữ liệu mà không cần phải quét toàn bộ bảng.
----Non-Clustered Index: Tạo một cấu trúc riêng biệt với bảng dữ liệu, chứa các con trỏ đến các hàng dữ liệu trong bảng.

--4. Tạo store procedure tìm danh sách đơn hàng theo các điều kiện Lọc: 
--Mã đơn hàng, mã/tên khách hàng, Mã/tên mặt hàng trong đơn hàng, Ngày tạo đơn hàng trong khoảng Từ - Đến.

CREATE PROCEDURE sp_FindOrders
	@OrderID INT = NULL,
	@CustomerID INT = NULL,
	@UserName NVARCHAR(100) = NULL,
	@ItemID INT = NULL,
	@ItemName NVARCHAR(250) = NULL,
	@OrderDateFrom DATE = NULL,
	@OrderDateTo DATE = NULL
AS
BEGIN
	SET NOCOUNT ON; --được sử dụng để ngăn chặn việc trả về các thông báo "rows affected" cho từng câu lệnh UPDATE, INSERT, và DELETE trong thủ tục lưu trữ STORED PROCEDURE
	SELECT 
		O.OrderID,
        O.CustomerID,
        C.UserName,
        O.OrderDate,
        O.TotalAmount,
        OD.ItemID,
        I.ItemName,
        OD.Quantity,
        OD.Price
	FROM Orders O
	INNER JOIN Customers C ON O.CustomerID = C.CustomerID
	INNER JOIN OrderDetails OD ON O.OrderID = OD.OrderID
	INNER JOIN Items I ON OD.ItemID = I.ItemID
	WHERE
		--Truy vấn linh hoạt, cho phép lọc dữ liệu dựa trên điều kiện có thể là tùy chọn.
		(@OrderID IS NULL OR O.OrderID = @OrderID)
		AND (@CustomerID IS NULL OR C.CustomerID = @CustomerID)
		AND (@UserName IS NULL OR C.UserName LIKE '%' + @UserName + '%')
		AND (@ItemID IS NULL OR I.ItemID = @ItemID)
		AND (@ItemName IS NULL OR I.ItemName LIKE '%' + @ItemName + '%')
		AND (@OrderDateFrom IS NULL OR O.OrderDate >= @OrderDateFrom)
		AND (@OrderDateTo IS NULL OR O.OrderDate <= @OrderDateTo)
END;

-- 1. Tìm đơn hàng theo tên khách hàng và phạm vi ngày
EXEC sp_FindOrders @UserName = 'john_doe', @OrderDateFrom = '2024-05-01', @OrderDateTo = '2024-06-30';

-- 2. Tìm đơn hàng theo tên mặt hàng
EXEC sp_FindOrders @ItemName = 'Laptop';

-- 3. Tìm đơn hàng cụ thể theo ID đơn hàng
EXEC sp_FindOrders @OrderID = 12345;

-- 4. Tìm đơn hàng theo ID khách hàng
EXEC sp_FindOrders @CustomerID = 1;

----5. Tạo store procedure tìm: 
----	1. Top 10 khách hàng mua nhiều tiền nhất trong Từ ngày – Đến ngày, Từ tháng – Đến tháng; 
----	2. Top 10 mặt hàng được mua nhiều/ít nhất trong tháng.

CREATE PROCEDURE sp_TopCustomersAndItems
	@FromDate DATE = NULL,
	@ToDate DATE = NULL,
	@FromMonth INT = NULL,
	@ToMonth INT = NULL,
	@Year INT = NULL,
	@ItemRankingType NVARCHAR(10) = 'MOST' -- MOST là số lần mua nhiều nhất, LEAST là số lần mua ít nhất.
AS
BEGIN
	SET NOCOUNT ON;
	--1. Top 10 khách hàng mua nhiều tiền nhất trong một khoảng thời
	SELECT TOP 10
		C.CustomerID,
		C.UserName,
		SUM(O.TotalAmount) AS TotalSpent
	FROM Customers C
	INNER JOIN Orders O ON C.CustomerID = O.CustomerID
	WHERE
		(@FromDate IS NULL OR O.OrderDate >= @FromDate)
		AND (@ToDate IS NULL OR O.OrderDate <= @ToDate)
		AND (@FromMonth IS NULL OR MONTH(O.OrderDate) >= @FromMonth)
		AND (@ToMonth IS NULL OR MONTH(O.OrderDate) <= @ToMonth)
		AND (@Year IS NULL OR YEAR(O.OrderDate) = @Year)
	GROUP BY
		C.CustomerID, C.UserName
	ORDER BY
		TotalSpent DESC

	--2. Top 10 mặt hàng được mua nhiều/ít nhất trong tháng.
	--xác định loại xếp hạng
    DECLARE @SortOrder NVARCHAR(4) = CASE WHEN @ItemRankingType = 'LEAST' THEN 'ASC' ELSE 'DESC' END;
	DECLARE @SQL NVARCHAR(MAX);
	SET @SQL = '
		SELECT TOP 10
			I.ItemID,
			I.ItemName,
			SUM(OD.Quantity) AS TotalQuantitySold
		FROM OrderDetails OD
		INNER JOIN Orders O ON OD.OrderID = O.OrderID
		INNER JOIN Items I ON OD.ItemID = I.ItemID
		WHERE
			(@Year IS NULL OR YEAR(OrderDate) = @Year)
			AND (@FromMonth IS NULL OR MONTH(OrderDate) = @FromMonth)
			AND (@ToMonth IS NULL OR MONTH(OrderDate) = @ToMonth)
		GROUP BY
			I.ItemID, I.ItemName
		ORDER BY
			TotalQuantitySold ' + @SortOrder;
	EXEC sp_executesql @SQL, N'@Year INT, @FromMonth INT, @ToMonth INT', @Year, @FromMonth, @ToMonth;
END;

-- 1: Tìm top 10 khách hàng và mặt hàng được mua ít nhất từ ​​ngày 01/12/2023 đến ngày 31/01/2024
EXEC sp_TopCustomersAndItems @FromDate = '2023-12-01', @ToDate = '2024-01-31', @ItemRankingType = 'LEAST'; 
---- 2: Tìm top 10 khách hàng và mặt hàng được mua ít nhất trong tháng 12 năm 2023 
EXEC sp_TopCustomersAndItems @FromMonth = 12, @ToMonth = 12, @Year = 2023, @ItemRankingType = 'LEAST'; 
---- 3: Tìm top 10 khách hàng cả năm 2023 và mặt hàng được mua nhiều nhất 
EXEC sp_TopCustomersAndItems @Year = 2023, @ItemRankingType = 'MOST';
