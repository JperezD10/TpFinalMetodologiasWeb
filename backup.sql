USE [master]
GO
/****** Object:  Database [Libreria]    Script Date: 12/11/2024 14:38:46 ******/
CREATE DATABASE [Libreria]
GO
CREATE TABLE [dbo].[Bitacora](
	[fecha] [datetime] NULL,
	[usuario] [nvarchar](10) NULL,
	[movimiento] [varchar](30) NULL,
	[modulo] [varchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[idcompra] [int] IDENTITY(1,1) NOT NULL,
	[idProducto] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaCompra] [datetime] NOT NULL,
	[metodoPago] [nvarchar](50) NOT NULL,
	[totalAPagar] [decimal](18, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[idcompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Formularios]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Formularios](
	[formId] [int] IDENTITY(1,1) NOT NULL,
	[formPath] [varchar](100) NULL,
	[formName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[formId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PermisosRoles]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PermisosRoles](
	[idRol] [int] NULL,
	[idForm] [int] NULL,
	[isAllowed] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[idproducto] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](100) NULL,
	[categoria] [nvarchar](100) NULL,
	[precio] [int] NULL,
	[Encriptado] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[idproducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[idRol] [int] NOT NULL,
	[descripcion] [varchar](20) NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SumaEncriptadaTablas]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SumaEncriptadaTablas](
	[NombreTabla] [char](30) NULL,
	[Varibles] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[usuario] [nvarchar](10) NOT NULL,
	[contraseña] [nvarchar](100) NULL,
	[idRol] [int] NULL,
	[Encriptado] [nvarchar](max) NULL,
	[IntentosRestantes] [int] NOT NULL,
	[Bloqueado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VarSumaEncriptada]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VarSumaEncriptada](
	[variable] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-17T13:22:52.413' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-17T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-17T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-18T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-20T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-06-23T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-07-13T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-07-15T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-07-16T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-07-16T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-17T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-17T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-18T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-18T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-19T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-19T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-20T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-20T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-25T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-31T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-08-31T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-04T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-04T00:00:00.000' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-24T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T00:00:00.000' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T00:26:00.690' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T17:17:07.080' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T17:17:32.250' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T17:18:17.793' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T17:22:17.887' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-25T17:22:49.377' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-26T14:40:12.487' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-26T14:40:50.113' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-26T14:41:19.367' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-09-26T22:27:10.333' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T10:32:15.950' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T10:48:12.940' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T10:49:31.730' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T10:49:49.850' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T12:33:10.493' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-10-09T21:26:42.220' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:02:54.350' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:13:57.910' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:21.227' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:23.227' AS DateTime), N'Nadia', N'Cierre de sesion del usuario', N'Logout')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:27.900' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:29.707' AS DateTime), N'Maite', N'Cierre de sesion del usuario', N'Logout')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:34.363' AS DateTime), N'Maite', N'Logueo de usuario', N'Módulo Login')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:37.273' AS DateTime), N'Maite', N'Cierre de sesion del usuario', N'Logout')
INSERT [dbo].[Bitacora] ([fecha], [usuario], [movimiento], [modulo]) VALUES (CAST(N'2024-11-05T21:15:41.080' AS DateTime), N'Nadia', N'Logueo de usuario', N'Módulo Login')
GO
SET IDENTITY_INSERT [dbo].[Formularios] ON 

INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (1, N'MenuPrincipal.aspx', N'MenuPrincipal')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (2, N'Backup.aspx', N'Backup')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (3, N'Bitacora.aspx', N'Bitacora')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (4, N'Compras.aspx', N'Compras')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (5, N'Login.aspx', N'Login')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (6, N'Productos.aspx', N'Productos')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (7, N'Restore.aspx', N'Restore')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (8, N'Contacto.aspx', N'Contacto')
INSERT [dbo].[Formularios] ([formId], [formPath], [formName]) VALUES (9, N'Logout.aspx', N'Logout')
SET IDENTITY_INSERT [dbo].[Formularios] OFF
GO
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 1, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 2, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 3, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 4, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 5, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 6, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 7, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 1, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 2, 0)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 3, 0)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 4, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 5, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 6, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 7, 0)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 8, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 8, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (2, 9, 1)
INSERT [dbo].[PermisosRoles] ([idRol], [idForm], [isAllowed]) VALUES (1, 9, 1)
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([idproducto], [nombre], [categoria], [precio], [Encriptado]) VALUES (1, N'Lapices', N'Lapices y Lapiceras', 600, N'73c5394f22bfad7da87011b03ec9c5d1faea0ed25b8c4173be1a42637ae03874')
INSERT [dbo].[Productos] ([idproducto], [nombre], [categoria], [precio], [Encriptado]) VALUES (2, N'Goma', N'Lapices y Lapiceras', 600, N'd59afa16d08fe52dd2eae0b9b47554df9cee35d64cdeb48fe120309d41a3ac76')
INSERT [dbo].[Productos] ([idproducto], [nombre], [categoria], [precio], [Encriptado]) VALUES (3, N'Cuaderno', N'Cuadernos', 600, N'dcfd478fc1faeb1de0975080b934195dc32baeae904d8e4ff5aaaffb8c0887ce')
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
INSERT [dbo].[Rol] ([idRol], [descripcion]) VALUES (1, N'web master')
INSERT [dbo].[Rol] ([idRol], [descripcion]) VALUES (2, N'cliente')
GO
INSERT [dbo].[SumaEncriptadaTablas] ([NombreTabla], [Varibles]) VALUES (N'dt_usuario                    ', N'6f2cbe1f72b701fb65d78d75addca2ae2eedb253c439d734900a855884406131d0ab4a583ffb5dcbf7eb2ecd83dda6df01ce50e03c3bac60614b6403a067f604d00e557b7d2eb134720267d0e1b054b9c82a694e3b711c96781ab6da8b5ea959')
INSERT [dbo].[SumaEncriptadaTablas] ([NombreTabla], [Varibles]) VALUES (N'dt_productos                  ', N'73c5394f22bfad7da87011b03ec9c5d1faea0ed25b8c4173be1a42637ae03874d59afa16d08fe52dd2eae0b9b47554df9cee35d64cdeb48fe120309d41a3ac76dcfd478fc1faeb1de0975080b934195dc32baeae904d8e4ff5aaaffb8c0887ce')
GO
INSERT [dbo].[Usuarios] ([usuario], [contraseña], [idRol], [Encriptado], [IntentosRestantes], [Bloqueado]) VALUES (N'Maite', N'e23aa0c53b32a57688c7482732a02615390e7513926b8ae3a7282b996fa6a0c1', 2, N'6f2cbe1f72b701fb65d78d75addca2ae2eedb253c439d734900a855884406131', 3, 0)
INSERT [dbo].[Usuarios] ([usuario], [contraseña], [idRol], [Encriptado], [IntentosRestantes], [Bloqueado]) VALUES (N'Nadia', N'e23aa0c53b32a57688c7482732a02615390e7513926b8ae3a7282b996fa6a0c1', 1, N'd0ab4a583ffb5dcbf7eb2ecd83dda6df01ce50e03c3bac60614b6403a067f604', 3, 0)
INSERT [dbo].[Usuarios] ([usuario], [contraseña], [idRol], [Encriptado], [IntentosRestantes], [Bloqueado]) VALUES (N'Usu', N'Usu', 2, N'd00e557b7d2eb134720267d0e1b054b9c82a694e3b711c96781ab6da8b5ea959', 3, 1)
GO
INSERT [dbo].[VarSumaEncriptada] ([variable]) VALUES (N'f9455a215adad13ec38bafae91881be02250c12b48d9c9479fe79ef6ca2e8bf17997124882b5869aadbb4e0cc10da8ef55a58a17bdd04ae7ef8096500a6c074583b4481d14646308104a3f215b418c184ee6251f48f6d66c5737fe953f9d22ba')
INSERT [dbo].[VarSumaEncriptada] ([variable]) VALUES (N'f9455a215adad13ec38bafae91881be02250c12b48d9c9479fe79ef6ca2e8bf17997124882b5869aadbb4e0cc10da8ef55a58a17bdd04ae7ef8096500a6c074583b4481d14646308104a3f215b418c184ee6251f48f6d66c5737fe953f9d22ba73c5394f22bfad7da87011b03ec9c5d1faea0ed25b8c4173be1a42637ae03874d59afa16d08fe52dd2eae0b9b47554df9cee35d64cdeb48fe120309d41a3ac7622a426d282b9c0d92ed145891aec20f39308fbbda60d74dd42390c0c04331d5a')
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((3)) FOR [IntentosRestantes]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [Bloqueado]
GO
ALTER TABLE [dbo].[Bitacora]  WITH CHECK ADD FOREIGN KEY([usuario])
REFERENCES [dbo].[Usuarios] ([usuario])
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([idProducto])
REFERENCES [dbo].[Productos] ([idproducto])
GO
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD FOREIGN KEY([idForm])
REFERENCES [dbo].[Formularios] ([formId])
GO
ALTER TABLE [dbo].[PermisosRoles]  WITH CHECK ADD FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Rol] ([idRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuario_Rol]
GO
/****** Object:  StoredProcedure [dbo].[GetFormIdByName]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetFormIdByName]
@FormName VARCHAR(100)
AS BEGIN
SELECT formId from Formularios where formName=@FormName
END
GO
/****** Object:  StoredProcedure [dbo].[GetRoleByUsername]    Script Date: 12/11/2024 14:38:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetRoleByUsername]
@Username NVARCHAR(10)
AS BEGIN
SELECT idRol from Usuarios where usuario=@Username
END
GO
USE [master]
GO
ALTER DATABASE [Libreria] SET  READ_WRITE 
GO
