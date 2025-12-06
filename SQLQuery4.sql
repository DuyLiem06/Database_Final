USE master;
GO

-- 1. Kiểm tra nếu Database đã tồn tại thì xóa đi để tạo mới (Làm sạch)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'SE08201_AdminDashboard')
BEGIN
    ALTER DATABASE SE08201_AdminDashboard SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SE08201_AdminDashboard;
END
GO

-- 2. Tạo Database mới
CREATE DATABASE SE08201_AdminDashboard;
GO
USE SE08201_AdminDashboard;
GO

-- =============================================
-- TẠO CÁC BẢNG (TABLES)
-- =============================================

-- Bảng Nhân viên
CREATE TABLE tblEmployee (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    EmployeeName NVARCHAR(100) NOT NULL,
    Username VARCHAR(50) UNIQUE NOT NULL,  -- Đổi nvarchar -> varchar cho username
    Password VARCHAR(255) NOT NULL,
    AuthorityLevel INT NOT NULL   -- 1: Admin, 2: Sale, 3: Warehouse
);

-- Bảng Danh mục
CREATE TABLE tblCategory (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(100) NOT NULL
);

-- Bảng Nhà cung cấp
CREATE TABLE tblSuppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(100) NOT NULL,
    SupplierPhone VARCHAR(20) -- Số điện thoại dùng Varchar
);

-- Bảng Sản phẩm
CREATE TABLE tblProducts (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Price DECIMAL(18,2) DEFAULT 0, -- Để Default 0 để code C# cũ vẫn chạy được
    StockQuantity INT DEFAULT 0,
    CategoryID INT,
    SupplierID INT,
    FOREIGN KEY (CategoryID) REFERENCES tblCategory(CategoryID) ON DELETE SET NULL,
    FOREIGN KEY (SupplierID) REFERENCES tblSuppliers(SupplierID) ON DELETE SET NULL
);

-- Bảng Khách hàng
-- LƯU Ý: Đổi tên cột Phone và Address để khớp với Code C# đã viết
CREATE TABLE tblCustomer (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone VARCHAR(20), 
    Address NVARCHAR(255)
);

-- Bảng Phương thức thanh toán
CREATE TABLE tblPaymentMethod (
    PaymentMethodID INT PRIMARY KEY IDENTITY(1,1),
    MethodName NVARCHAR(100) NOT NULL
);

-- Bảng Đơn hàng
CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    EmployeeID INT,
    PaymentMethodID INT, -- Có thể NULL vì code C# chưa xử lý cái này
    OrderDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CustomerID) REFERENCES tblCustomer(CustomerID),
    FOREIGN KEY (EmployeeID) REFERENCES tblEmployee(EmployeeID),
    FOREIGN KEY (PaymentMethodID) REFERENCES tblPaymentMethod(PaymentMethodID)
);

-- Bảng Chi tiết đơn hàng (Dành cho phát triển sau này)
CREATE TABLE tblOrderDetail (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    ProductID INT,
    Quantity INT DEFAULT 1,
    TotalAmount DECIMAL(18,2) DEFAULT 0,
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES tblProducts(ProductID)
);
GO

-- =============================================
-- THÊM DỮ LIỆU MẪU (INSERT DATA)
-- =============================================

-- 1. Employee (Mật khẩu mẫu: 123)
INSERT INTO tblEmployee (EmployeeName, Username, Password, AuthorityLevel) VALUES
(N'Nguyễn Văn Ánh (Admin)', 'admin', '123', 1),
(N'Trần Thị Bình (Sale)', 'sale', '123', 2),
(N'Phạm Thị Duyên (Kho)', 'kho', '123', 3),
(N'Lê Văn Cường', 'sale2', '123', 2),
(N'Nguyễn Thị Thu', 'kho2', '123', 3);

-- 2. Category
INSERT INTO tblCategory (CategoryName) VALUES
(N'Điện tử'), (N'Thời trang'), (N'Nội thất'),
(N'Thực phẩm'), (N'Sách'), (N'Đồ chơi');

-- 3. Supplier
INSERT INTO tblSuppliers (SupplierName, SupplierPhone) VALUES
(N'Samsung Vina', '0909123456'),
(N'Apple Vietnam', '0911222333'),
(N'IKEA', '0933444555'),
(N'Unilever', '0944555666'),
(N'NXB Trẻ', '0955666777'),
(N'Lego Group', '0966777888');

-- 4. Product
INSERT INTO tblProducts (ProductName, Price, StockQuantity, CategoryID, SupplierID) VALUES
(N'iPhone 15 Pro', 25000000, 10, 1, 2),
(N'Samsung Smart TV', 15000000, 5, 1, 1),
(N'Ghế văn phòng', 500000, 20, 3, 3),
(N'Sofa da', 3000000, 7, 3, 3),
(N'Sữa tươi Vinamilk', 10000, 50, 4, 4),
(N'Bộ Lego City', 2000000, 15, 6, 6);

-- 5. Customer
INSERT INTO tblCustomer (CustomerName, Phone, Address) VALUES
(N'Nguyễn Văn Nam', '0909000001', N'Hà Nội'),
(N'Trần Thị Hoa', '0909000002', N'Đà Nẵng'),
(N'Lê Văn Long', '0909000003', N'TP.HCM'),
(N'Phạm Thị Mai', '0909000004', N'Huế');

-- 6. PaymentMethod
INSERT INTO tblPaymentMethod (MethodName) VALUES
(N'Tiền mặt'), (N'Thẻ tín dụng'), (N'Chuyển khoản'),
(N'MoMo'), (N'ZaloPay');

-- 7. Order
INSERT INTO [Order] (CustomerID, EmployeeID, PaymentMethodID, OrderDate) VALUES
(1, 2, 1, '2025-10-10'),
(2, 3, 2, '2025-10-11'),
(3, 4, 3, '2025-10-11'),
(4, 5, 1, '2025-10-12');

-- 8. OrderDetail
INSERT INTO tblOrderDetail (OrderID, ProductID, Quantity, TotalAmount) VALUES
(1, 1, 1, 25000000), -- Đơn 1 mua 1 iPhone
(1, 2, 1, 15000000), -- Đơn 1 mua 1 TV
(2, 3, 2, 1000000),  -- Đơn 2 mua 2 Ghế
(3, 5, 10, 100000),  -- Đơn 3 mua 10 Sữa
(4, 4, 1, 3000000);  -- Đơn 4 mua 1 Sofa

GO