CREATE Procedure UpdateCartItem
(@CartID char(36),
 @ProductID int,
 @Quantity int)
As

IF @Quantity<=0 
  EXEC RemoveProductFromCart @CartID, @ProductID
ELSE
  UPDATE ShoppingCart
  SET Quantity = @Quantity, DateProductAdded=GETDATE()
  WHERE ProductID = @ProductID AND CartID = @CartID

RETURN
