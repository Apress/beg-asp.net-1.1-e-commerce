CREATE TABLE [Customer] (
	[CustomerID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL,
	[Email] [varchar] (50) NOT NULL,
	[Password] [varchar] (50) NULL,
	[CreditCard] [varchar] (512) NULL,
	[Address1] [varchar] (100) NULL,
	[Address2] [varchar] (100) NULL,
	[City] [varchar] (100) NULL,
	[Region] [varchar] (100) NULL,
	[PostalCode] [varchar] (100) NULL,
	[Country] [varchar] (100) NULL,
	[Phone] [varchar] (100) NULL
)