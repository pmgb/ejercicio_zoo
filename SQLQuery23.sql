USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[GetClasificaciones]    Script Date: 14/06/2017 19:12:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GetClasificaciones]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END


SELECT 
		Marcas.denominacion as denominacionMarca
    , Marcas.denominacion as denominacionTipoCombustible
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
FROM Marcas
    INNER JOIN Coches on Marcas.id = Coches.idMarca
    INNER JOIN TiposCombustible on Coches.idTipoCombustible = TiposCombustible.id
GROUP BY 
      Marcas.denominacion
    , TiposCombustible.denominacion
    , Coches.idMarca
    , Coches.idTipoCombustible
    , Coches.id, Coches.matricula, Coches.color, Coches.nPlazas
    , Coches.fechaMatriculacion, Coches.cilindrada
ORDER BY Marcas.denominacion