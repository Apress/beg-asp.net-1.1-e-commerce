CREATE PROCEDURE GetTotalAmount
(@CartID char(36))
AS

DECLARE @Amount money

SELECT @Amount = SUM(Product.Price*ShoppingCart.Quantity)
FROM ShoppingCart
INNER JOIN Product
ON ShoppingCart.ProductID = Product.ProductID
WHERE ShoppingCart.CartID = @CartID

IF @Amount IS NULL 
	SELECT 0
ELSE
	SELECT @Amount

RETURN
