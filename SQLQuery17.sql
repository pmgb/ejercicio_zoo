USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[GetClasificaciones]    Script Date: 13/06/2017 20:54:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetTiposAnimales]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END