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
--иде€, изменить, если врем€ покупки отсутствует изменить на неустановленно. 2. ≈сли у прадовца покупают, то его врем€ работы +1(врем€ работы можно изменить на кол-во обслуживающих(дл€ чего?, просто иде€ пришла))




UPDATE Product
SET ProductPrice = 20.21
WHERE IDProduct = 1

INSERT Product(IDProduct,ProductName,ProductPrice)
VALUES (3,'–амен', 299.24)