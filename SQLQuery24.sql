USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[Get_Marcas_ID]    Script Date: 15/06/2017 17:10:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Get_Clasificaciones_ID]
      @id bigint   as
  Begin
    select IdClasificacion, denominacion from Clasificaciones
    WHERE Clasificaciones.IdClasificacion = @id
  END;