CREATE PROCEDURE UpdateOrder
(@OrderID int,
 @DateCreated smalldatetime,
 @DateShipped smalldatetime = NULL,
 @Verified bit,
 @Completed bit,
 @Canceled bit,
 @Comments varchar(200),
 @CustomerName varchar(50),
 @ShippingAddress varchar(200),
 @CustomerEmail varchar(50))
AS

UPDATE Orders
SET DateCreated=@DateCreated,
    DateShipped=@DateShipped,
    Verified=@Verified,
    Completed=@Completed,
    Canceled=@Canceled,
    Comments=@Comments,
    CustomerName=@CustomerName,
    ShippingAddress=@ShippingAddress,
    CustomerEmail=@CustomerEmail
WHERE OrderID = @OrderID
