CREATE PROCEDURE RemoveProductFromCart
(@CartID char(36),
 @ProductID int)
AS

DELETE FROM ShoppingCart
WHERE CartID = @CartID and ProductID = @ProductID

RETURN
