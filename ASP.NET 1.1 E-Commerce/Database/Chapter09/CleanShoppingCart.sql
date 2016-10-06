CREATE PROCEDURE CleanShoppingCart
   (@Days smallint)
AS
DELETE FROM ShoppingCart
WHERE CartID IN
  (SELECT CartID
   FROM ShoppingCart
   GROUP BY CartID
   HAVING MIN(DATEDIFF(dd,DateProductAdded,GETDATE()))>@Days)
