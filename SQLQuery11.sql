USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[GetClasificaciones]    Script Date: 13/06/2017 20:46:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEspecies]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END