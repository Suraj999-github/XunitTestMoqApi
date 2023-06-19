CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](255) NULL,
	[ProductDescription] [varchar](2000) NULL,
	[ProductPrice] [int] NULL,
	[ProductStock] [int] NULL
) ON [PRIMARY]

GO