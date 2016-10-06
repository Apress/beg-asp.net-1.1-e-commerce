CREATE PROCEDURE UpdateProductPicture
      (@ProductID int,
       @ImageFileName varchar(50))
AS

UPDATE Product
SET ImagePath = @ImageFileName
WHERE ProductID = @ProductID

RETURN
