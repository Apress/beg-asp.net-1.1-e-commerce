CREATE PROCEDURE CountOldShoppingCartElements
   (@Days smallint)
AS
SELECT COUNT(CartID) 
FROM ShoppingCart
WHERE CartID IN
  (SELECT CartID
   FROM ShoppingCart
   GROUP BY CartID
   HAVING MIN(DATEDIFF(dd,DateProductAdded,GETDATE()))>@Days)
