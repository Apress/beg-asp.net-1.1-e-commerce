CREATE TABLE [Audit] (
	[AuditID] [int] IDENTITY (1, 1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[DateStamp] [datetime] NOT NULL,
	[Message] [varchar] (512) NOT NULL,
	[MessageNumber] [int] NOT NULL
)