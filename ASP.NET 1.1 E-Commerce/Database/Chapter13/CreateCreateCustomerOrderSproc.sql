CREATE PROCEDURE CreateCustomerOrder 
(@CartID varchar(50),
 @CustomerID int)
AS

DECLARE @OrderID int
INSERT INTO Orders (DateCreated, Verified, Completed, Canceled, CustomerID, Status)
VALUES (GETDATE(), 0, 0, 0, @CustomerID, 0)
SET @OrderID = @@IDENTITY

INSERT INTO OrderDetail 
     (OrderID, ProductID, ProductName, Quantity, UnitCost)
SELECT 
     @OrderID, Product.ProductID, Product.[Name], 
     ShoppingCart.Quantity, Product.Price
FROM Product JOIN ShoppingCart
ON Product.ProductID = ShoppingCart.ProductID
WHERE ShoppingCart.CartID = @CartID

EXEC EmptyShoppingCart @CartID

SELECT @OrderID
GO
