ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_CINSIYET] FOREIGN KEY([CinsiyetTuruTipNo])
REFERENCES [CINSIYET] ([No])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_CINSIYET]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_DIN] FOREIGN KEY([DinTuruTipNo])
REFERENCES [DIN] ([No])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_DIN]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_ILCE] FOREIGN KEY([NufusaKayitliOlduguIlceNo])
REFERENCES [ILCE] ([ID])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_ILCE]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_KAN_GRUBU] FOREIGN KEY([KanGrubuTuruTipNo])
REFERENCES [KAN_GRUBU] ([No])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_KAN_GRUBU]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_MAHALLE] FOREIGN KEY([NufusaKayitliOlduguMahalleKoyKey])
REFERENCES [MAHALLE] ([ID])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_MAHALLE]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_MEDENI_DURUM] FOREIGN KEY([MedeniDurumTuruTipNo])
REFERENCES [MEDENI_DURUM] ([No])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_MEDENI_DURUM]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_SEHIR] FOREIGN KEY([DogumYeriNo])
REFERENCES [SEHIR] ([ID])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_SEHIR]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_SEHIR1] FOREIGN KEY([NufusaKayitliOlduguSehirNo])
REFERENCES [SEHIR] ([ID])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_SEHIR1]
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI]  WITH CHECK ADD  CONSTRAINT [FK_KISI_NUFUS_BILGILERI_ULKE] FOREIGN KEY([UyrukTipNo])
REFERENCES [ULKE] ([No])
GO
ALTER TABLE [ORTAK].[KISI_NUFUS_BILGILERI] CHECK CONSTRAINT [FK_KISI_NUFUS_BILGILERI_ULKE]
GO
