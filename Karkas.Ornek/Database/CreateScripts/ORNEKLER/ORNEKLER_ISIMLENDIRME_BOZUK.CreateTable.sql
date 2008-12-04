SET ANSI_NULLS ON
GO --ExecuteThisSql
SET QUOTED_IDENTIFIER ON
GO --ExecuteThisSql
CREATE TABLE [ORNEKLER].[ISIMLENDIRME_BOZUK](
	[KISI_OID] [int] NOT NULL,
	[ADI] [varchar](50) NOT NULL,
	[SOYADI] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ISIMLENDIRME_BOZUK] PRIMARY KEY CLUSTERED 
(
	[KISI_OID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO --ExecuteThisSql

