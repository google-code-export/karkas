USE [KARKAS_ORNEK]
GO
/****** Object:  StoredProcedure [ORNEKLER].[BASIT_TABLO_IDENTITY_EKLE]    Script Date: 10/29/2008 16:49:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [ORNEKLER].[BASIT_TABLO_IDENTITY_EKLE]
	@Adi VARCHAR(50)
	,@Soyadi  VARCHAR(50)
AS
BEGIN
DECLARE @RetValue int
INSERT INTO ORNEKLER.[BASIT_TABLO_IDENTITY]
           ([Adi]
           ,[Soyadi])
     VALUES
           (@Adi
           ,@Soyadi);SET @RetValue = SCOPE_IDENTITY() ;           
           SELECT @RetValue;
END


