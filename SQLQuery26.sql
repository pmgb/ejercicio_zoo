USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[EliminarMarca]    Script Date: 15/06/2017 17:33:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[EliminarClasificacion]
	@id bigint
AS
BEGIN
	DELETE FROM Clasificaciones WHERE IdClasificacion = @id
END