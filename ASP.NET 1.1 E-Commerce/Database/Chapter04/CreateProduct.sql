CREATE TABLE [Product] (
	[ProductID] [int] IDENTITY (1, 1) NOT NULL,
	[Name] [varchar] (50) NOT NULL,
	[Description] [varchar] (1000) NULL,
	[Price] [money] NULL,
	[ImagePath] [varchar] (50) NULL,
	[OnCatalogPromotion] [bit] NOT NULL,
	[OnDepartmentPromotion] [bit] NULL 
) 



