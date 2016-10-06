CREATE PROCEDURE MarkOrderAsCompleted
(@OrderID int)
AS

UPDATE Orders
SET Completed = 1,
    DateShipped = getdate()
WHERE OrderID = @OrderID
