USE [Zoo_pm]
GO
/****** Object:  StoredProcedure [dbo].[AgregarMarca]    Script Date: 15/06/2017 17:25:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- PROCEDIMIENTO PARA INSERTAR UNA NUEVA MARCA

ALTER PROCEDURE [dbo].[AgregarClasificacion]
	@denominacion nvarchar (50)
AS
BEGIN
	INSERT INTO Clasificaciones (denominacion) VALUES (@denominacion)
END