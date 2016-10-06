CREATE PROCEDURE GetMostRecentOrders 
(@Count smallint)
AS

SET ROWCOUNT @Count

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
ORDER BY DateCreated DESC

SET ROWCOUNT 0
