CREATE PROCEDURE GetShoppingCartProducts 
(@CartID char(36))
AS

SELECT Product.ProductID, Product.Name, Product.Price, ShoppingCart.Quantity, Product.Price*ShoppingCart.Quantity AS Subtotal
FROM ShoppingCart
INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

RETURN
