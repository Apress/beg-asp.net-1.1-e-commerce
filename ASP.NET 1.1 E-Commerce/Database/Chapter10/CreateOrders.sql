CREATE TABLE [Orders] (
	[OrderID] [int] IDENTITY (1, 1) NOT NULL,
	[DateCreated] [smalldatetime] NOT NULL,
	[DateShipped] [smalldatetime] NULL,
	[Verified] [bit] NOT NULL,
	[Completed] [bit] NULL,
	[Canceled] [bit] NOT NULL,
	[Comments] [varchar] (200) NULL,
	[CustomerName] [varchar] (50) NULL,
	[ShippingAddress] [varchar] (200) NULL,
	[CustomerEmail] [varchar] (50) NULL 
)


