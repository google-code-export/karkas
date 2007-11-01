/****** Object:  Table [ORTAK].[KISI_NUFUS_BILGILERI]    Script Date: 05/15/2007 00:44:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ORTAK].[KISI_NUFUS_BILGILERI](
	[ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_KISI_NUFUS_BILGILERI_KisiNufusBilgileriKey]  DEFAULT (newid()),
	[KisiKey] [uniqueidentifier] NOT NULL,
	[TCKimlikNo] [ORTAK].[TCKimlikNo] NULL,
	[Ad] [varchar](50) NULL,
	[IkinciAdi] [varchar](50) NULL,
	[Soyad] [varchar](50) NULL,
	[UyrukTipNo] [smallint] NULL,
	[Cilt] [varchar](50) NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_Cilt]  DEFAULT (''),
	[Sayfa] [varchar](50) NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_Sayfa]  DEFAULT (''),
	[Kutuk] [varchar](50) NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_Kutuk]  DEFAULT (''),
	[DogumYeriNo] [int] NULL,
	[NufusaKayitliOlduguSehirNo] [int] NULL,
	[NufusaKayitliOlduguIlceNo] [int] NULL,
	[NufusaKayitliOlduguMahalleKoyKey] [int] NULL,
	[AnaAdi] [varchar](50) NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_AnaAdi]  DEFAULT (''),
	[BabaAdi] [varchar](50) NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_BabaAdi]  DEFAULT (''),
	[DogumTarihi] [smalldatetime] NOT NULL CONSTRAINT [DF_KisiNufusBilgileri_DogumTarihi]  DEFAULT (getdate()),
	[MedeniDurumTuruTipNo] [tinyint] NULL,
	[DinTuruTipNo] [tinyint] NULL,
	[CinsiyetTuruTipNo] [tinyint] NULL,
	[KanGrubuTuruTipNo] [tinyint] NULL,
 CONSTRAINT [PK_KISI_NUFUS_BILGILERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

