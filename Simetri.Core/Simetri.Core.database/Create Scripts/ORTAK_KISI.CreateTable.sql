/****** Object:  Table [ORTAK].[KISI]    Script Date: 05/15/2007 00:44:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ORTAK].[KISI](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_KISI_ID]  DEFAULT (newid()),
	[TcKimlikNo] [ORTAK].[TCKimlikNo] NULL,
	[Adi] [varchar](50) NULL CONSTRAINT [DF_KISI_Adi]  DEFAULT ('Atilla'),
	[Soyadi] [varchar](50) NULL,
	[IkinciAdi] [varchar](50) NULL,
	[WindowsUserName] [varchar](255) NULL,
 CONSTRAINT [PK_KISI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

