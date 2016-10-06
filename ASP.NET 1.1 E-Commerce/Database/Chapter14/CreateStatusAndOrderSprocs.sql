CREATE PROCEDURE GetStatuses
AS

SELECT StatusID, [Description]
FROM Status
GO

CREATE PROCEDURE GetOrders
AS

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Orders.AuthCode, Orders.Reference, Status.[Description], Customer.[Name]
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
GO

Create PROCEDURE GetOrder
(@OrderID as int)
AS

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Status.[Description], Customer.[Name], Orders.AuthCode,
Orders.Reference
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
WHERE Orders.OrderID = @OrderID
GO

CREATE PROCEDURE GetOrdersByRecent
(@Count int)
AS

SET ROWCOUNT @Count

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Status.[Description], Customer.[Name]
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
ORDER BY DateCreated DESC
SET ROWCOUNT 0
GO

CREATE PROCEDURE GetOrdersByCustomer
(@CustomerID int)
AS

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Status.[Description], Customer.[Name]
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
WHERE Orders.CustomerID = @CustomerID
GO

CREATE PROCEDURE GetOrdersByDate
(@StartDate datetime,
 @EndDate datetime)
AS

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Status.[Description], Customer.[Name]
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
WHERE Orders.DateCreated > @StartDate AND Orders.DateCreated < @EndDate
GO

CREATE PROCEDURE GetOrdersByStatus
(@Status int)
AS

SELECT Orders.OrderID, Orders.DateCreated, Orders.DateShipped, Orders.Status, Orders.CustomerID, Status.[Description], Customer.[Name]
FROM Orders INNER JOIN Customer
ON Customer.CustomerID = Orders.CustomerID
INNER JOIN Status
ON Status.StatusID = Orders.Status
WHERE Orders.Status = @Status
GO

CREATE PROCEDURE GetAuditTrail
(@OrderID int)
AS

SELECT DateStamp, MessageNumber, Message
FROM Audit 
WHERE OrderID = @OrderID
GO
