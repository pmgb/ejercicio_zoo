
/* PROCEDIMIENTO GetClasificaciones */


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



/* PROCEDIMIENTO GetEspecies */


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

/* PROCEDIMIENTO GetTiposAnimales */

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

/* PROCEDIMIENTO GET_ESPECIES_POR_CLASIFICACIONES */

USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[GetClasificaciones]    Script Date: 14/06/2017 19:33:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[GET_ESPECIES_POR_CLASIFICACIONES]
AS
BEGIN
SELECT 
	Clasificaciones.denominacion as denominacionClasificacion
    , Clasificaciones.denominacion as denominacionTiposAnimal
    , Especies.idEspecie, Especies.idClasificacion, Especies.idTipodeAnimal, Especies.nombre
    , Especies.nPatas, Especies.esMascota
FROM Clasificaciones
    INNER JOIN Especies on Clasificaciones.IdClasificacion = Especies.idEspecie
    INNER JOIN TiposAnimal on Especies.esMascota = TiposAnimal.IdTipoAnimal
GROUP BY 
      Clasificaciones.denominacion
    , TiposAnimal.denominacion
    , Especies.idEspecie
    , Especies.idClasificacion
	, Especies.idTipodeAnimal, Especies.nombre, Especies.nPatas, Especies.esMascota    
ORDER BY Clasificaciones.denominacion
END

