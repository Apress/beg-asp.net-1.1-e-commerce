CREATE PROCEDURE MarkOrderAsCanceled
(@OrderID int)
AS

UPDATE Orders
SET Canceled = 1
WHERE OrderID = @OrderID
