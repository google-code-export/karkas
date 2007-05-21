/****** Object:  Table [ORTAK].[KISI_EK_BILGILER]    Script Date: 05/15/2007 00:44:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ORTAK].[KISI_EK_BILGILER](
	[KisiKey] [uniqueidentifier] NOT NULL,
	[VergiDairesiTipNo] [int] NULL,
	[VergiNo] [ORTAK].[VergiNo] NULL,
	[SosyalGuvenlikTipNo] [int] NULL,
	[SosyalGuvenlikNo] [ORTAK].[SosyalGuvenlikNo] NULL,
	[PasaportTipNo] [int] NULL,
	[PasaportNo] [ORTAK].[SosyalGuvenlikNo] NULL,
	[SigaraKullanıpKullanmadıgı] [bit] NOT NULL CONSTRAINT [DF_KISI_EK_BILGILER_SigaraKullanıpKullanmadıgı]  DEFAULT ((0)),
	[EhliyetKey] [tinyint] NULL,
 CONSTRAINT [PK_KISI_EK_BILGILER] PRIMARY KEY CLUSTERED 
(
	[KisiKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

