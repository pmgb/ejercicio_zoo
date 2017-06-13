USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[GetMarcas]    Script Date: 13/06/2017 16:23:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetClasificaciones]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END