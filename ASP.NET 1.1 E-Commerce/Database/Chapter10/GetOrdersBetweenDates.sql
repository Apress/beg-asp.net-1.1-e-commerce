CREATE PROCEDURE GetOrdersBetweenDates 
(@StartDate smalldatetime,
 @EndDate smalldatetime)
AS

SELECT OrderID, DateCreated, DateShipped, 
       Verified, Completed, Canceled, CustomerName
FROM Orders
WHERE DateCreated BETWEEN @StartDate AND @EndDate
ORDER BY DateCreated DESC

