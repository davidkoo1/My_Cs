CREATE DATABASE Product


USE Product

CREATE TABLE Product
(
IDProduct INT PRIMARY KEY,
ProductName VARCHAR(30),
ProductPrice DECIMAL(6, 2)
)

CREATE TABLE Seller
(
IDSeller INT PRIMARY KEY,
SellerName VARCHAR(30),
TimeWork INT
)

CREATE TABLE Buyer
(
IDBuyer INT PRIMARY KEY,
BuyProductID INT FOREIGN KEY REFERENCES Product(IDProduct),
_SellerID INT FOREIGN KEY REFERENCES Seller(IDSeller),
BuyTime DATETIME
)
DROP TABLE Buyer
Select *
from Seller

Select *
from Product

Select * 
from Buyer


SELECT IDBuyer,BuyTime,IDProduct,ProductName,ProductPrice,IDSeller, SellerName, TimeWork 
FROM Buyer INNER JOIN
(
Product INNER JOIN Seller
ON	Product.IDProduct = Seller.IDSeller
)
ON Buyer.BuyProductID = Product.IDProduct
--����, ��������, ���� ����� ������� ����������� �������� �� ��������������. 2. ���� � �������� ��������, �� ��� ����� ������ +1(����� ������ ����� �������� �� ���-�� �������������(��� ����?, ������ ���� ������))




UPDATE Product
SET ProductPrice = 20.21
WHERE IDProduct = 1

INSERT Product(IDProduct,ProductName,ProductPrice)
VALUES (3,'�����', 299.24)