CREATE Procedure AddProductToCart
(@CartID char(36),
 @ProductID int)
As

IF EXISTS 
   (SELECT CartID 
    FROM ShoppingCart 
    WHERE ProductID = @ProductID AND CartID = @CartID)

    UPDATE ShoppingCart
    SET Quantity = Quantity + 1
    WHERE ProductID = @ProductID AND CartID = @CartID
ELSE
    IF EXISTS (SELECT Name FROM Product WHERE ProductID=@ProductID)
        INSERT INTO ShoppingCart (CartID, ProductID, Quantity, DateProductAdded)
        VALUES (@CartID, @ProductID, 1, GETDATE())

RETURN
