CREATE PROCEDURE GetOrderInfo
(@OrderID int)
AS

SELECT OrderID, 
       (SELECT SUM(UnitCost*Quantity) FROM OrderDetail WHERE OrderID = @OrderID) 
       AS TotalAmount, 
       DateCreated, 
       DateShipped, 
       Verified, 
       Completed, 
       Canceled, 
       Comments, 
       CustomerName, 
       ShippingAddress, 
       CustomerEmail
FROM Orders
WHERE OrderID = @OrderID

