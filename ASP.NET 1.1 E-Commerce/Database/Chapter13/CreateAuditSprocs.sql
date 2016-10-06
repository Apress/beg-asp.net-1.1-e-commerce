CREATE PROCEDURE GetOrderStatus
(@OrderID int)
AS

SELECT Status
FROM Orders
WHERE OrderID = @OrderID
GO

CREATE PROCEDURE AddAudit
(@OrderID int,
 @Message nvarchar(512),
 @MessageNumber int)
AS

INSERT INTO Audit (OrderID, DateStamp, Message, MessageNumber)
VALUES (@OrderID, GetDate(), @Message, @MessageNumber)
GO

CREATE PROCEDURE GetCustomerByOrderID
(@OrderID int)
AS

SELECT Customer.CustomerID, Customer.[Name], Customer.Email, Customer.[Password],
 Customer.CreditCard, Customer.Address1, Customer.Address2, Customer.City,
 Customer.Region, Customer.PostalCode, Customer.Country, Customer.Phone
FROM Customer INNER JOIN Orders
ON Customer.CustomerID = Orders.CustomerID
WHERE Orders.OrderID = @OrderID
GO

CREATE PROCEDURE UpdateOrderStatus
(@OrderID int,
 @Status int)
AS

UPDATE Orders
SET Status = @Status
WHERE OrderID = @OrderID
GO

CREATE PROCEDURE SetOrderAuthCode
(@OrderID int,
 @AuthCode nvarchar(50),
 @Reference nvarchar(50))
AS

UPDATE Orders
SET AuthCode = @AuthCode, Reference = @Reference
WHERE OrderID = @OrderID
GO

CREATE PROCEDURE GetOrderAuthCode
(@OrderID int)
AS

SELECT AuthCode,  Reference
FROM Orders
WHERE OrderID = @OrderID
GO

CREATE PROCEDURE SetDateShipped
(@OrderID int)
AS

UPDATE Orders
SET DateShipped = GetDate()
WHERE OrderID = @OrderID
GO
