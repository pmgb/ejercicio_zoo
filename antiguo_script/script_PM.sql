USE [Zoo_pm]
GO
/****** Object:  User [PMGB]    Script Date: 14/06/2017 17:02:33 ******/
CREATE USER [PMGB] FOR LOGIN [PMGB] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [PMGB]
GO
/****** Object:  Table [dbo].[Clasificaciones]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificaciones](
	[IdClasificacion] [int] NOT NULL,
	[denominacion] [nchar](50) NULL,
 CONSTRAINT [PK_Clasificaciones] PRIMARY KEY CLUSTERED 
(
	[IdClasificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Especies]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especies](
	[idEspecie] [bigint] NOT NULL,
	[idClasificacion] [int] NOT NULL,
	[idTipodeAnimal] [int] NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[nPatas] [int] NOT NULL,
	[esMascota] [int] NOT NULL,
 CONSTRAINT [PK_Especies] PRIMARY KEY CLUSTERED 
(
	[idEspecie] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TiposAnimal]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposAnimal](
	[IdTipoAnimal] [int] NOT NULL,
	[denominacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TiposAnimal] PRIMARY KEY CLUSTERED 
(
	[IdTipoAnimal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (1, N'klkl                                              ')
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (2, N'erre                                              ')
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (3, N'werw                                              ')
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (4, N'yut                                               ')
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (5, N'pouio                                             ')
INSERT [dbo].[Clasificaciones] ([IdClasificacion], [denominacion]) VALUES (6, N'hola                                              ')
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (1, 1, 1, N'perro', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (2, 2, 2, N'gato', 4, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (3, 3, 3, N'serpiente', 0, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (4, 4, 4, N'araña', 8, 1)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (5, 5, 5, N'elefante', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (6, 6, 6, N'tigre', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (7, 7, 7, N'ballena', 0, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (8, 8, 8, N'gorila', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (9, 9, 9, N'ciervo', 4, 0)
INSERT [dbo].[Especies] ([idEspecie], [idClasificacion], [idTipodeAnimal], [nombre], [nPatas], [esMascota]) VALUES (10, 10, 10, N'puma', 4, 0)
INSERT [dbo].[TiposAnimal] ([IdTipoAnimal], [denominacion]) VALUES (1, N'animal doméstico')
INSERT [dbo].[TiposAnimal] ([IdTipoAnimal], [denominacion]) VALUES (2, N'animal salvaje')
INSERT [dbo].[TiposAnimal] ([IdTipoAnimal], [denominacion]) VALUES (3, N'animal salvaje de compañia')
INSERT [dbo].[TiposAnimal] ([IdTipoAnimal], [denominacion]) VALUES (4, N'animal exótico de compañia')
INSERT [dbo].[TiposAnimal] ([IdTipoAnimal], [denominacion]) VALUES (5, N'animal exótico salvaje')
/****** Object:  StoredProcedure [dbo].[GetClasificaciones]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetClasificaciones]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GetEspecies]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetEspecies]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END
GO
/****** Object:  StoredProcedure [dbo].[GetTiposAnimales]    Script Date: 14/06/2017 17:02:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTiposAnimales]
AS
BEGIN
	SELECT IdTipoAnimal, denominacion FROM TiposAnimal
END
GO
