CREATE PROCEDURE EmptyShoppingCart 
(@CartID char(36))
AS

DELETE FROM ShoppingCart
WHERE CartID = @CartID

RETURN
