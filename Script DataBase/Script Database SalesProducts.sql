USE [master]
GO
/****** Object:  Database [SalesProducts]    Script Date: 5/08/2021 1:50:11 a. m. ******/
CREATE DATABASE [SalesProducts]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SalesProducts', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SalesProducts.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SalesProducts_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SalesProducts_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SalesProducts] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SalesProducts].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SalesProducts] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SalesProducts] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SalesProducts] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SalesProducts] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SalesProducts] SET ARITHABORT OFF 
GO
ALTER DATABASE [SalesProducts] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SalesProducts] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SalesProducts] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SalesProducts] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SalesProducts] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SalesProducts] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SalesProducts] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SalesProducts] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SalesProducts] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SalesProducts] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SalesProducts] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SalesProducts] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SalesProducts] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SalesProducts] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SalesProducts] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SalesProducts] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SalesProducts] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SalesProducts] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SalesProducts] SET  MULTI_USER 
GO
ALTER DATABASE [SalesProducts] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SalesProducts] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SalesProducts] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SalesProducts] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SalesProducts] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SalesProducts] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SalesProducts] SET QUERY_STORE = OFF
GO
USE [SalesProducts]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 5/08/2021 1:50:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[PedID] [int] IDENTITY(1,1) NOT NULL,
	[PedUsu] [int] NOT NULL,
	[PedProd] [int] NOT NULL,
	[PedVrUnit] [money] NOT NULL,
	[PedCant] [float] NOT NULL,
	[PedSubTot] [money] NOT NULL,
	[PedIVA] [float] NOT NULL,
	[PedTotal] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 5/08/2021 1:50:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ProId] [int] IDENTITY(1,1) NOT NULL,
	[ProDesc] [varchar](50) NOT NULL,
	[ProValor] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seguridad]    Script Date: 5/08/2021 1:50:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seguridad](
	[IdSeguridad] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](100) NOT NULL,
	[Contrasena] [varchar](200) NOT NULL,
	[Rol] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/08/2021 1:50:11 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[UsuID] [int] IDENTITY(1,1) NOT NULL,
	[UsuNombre] [varchar](50) NOT NULL,
	[UsuPass] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UsuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([PedID], [PedUsu], [PedProd], [PedVrUnit], [PedCant], [PedSubTot], [PedIVA], [PedTotal]) VALUES (1, 1, 2, 1200000.0000, 2, 700000.0000, 19, 3500000.0000)
INSERT [dbo].[Pedido] ([PedID], [PedUsu], [PedProd], [PedVrUnit], [PedCant], [PedSubTot], [PedIVA], [PedTotal]) VALUES (2, 2, 1, 230000.0000, 4, 950000.0000, 19, 2500000.0000)
INSERT [dbo].[Pedido] ([PedID], [PedUsu], [PedProd], [PedVrUnit], [PedCant], [PedSubTot], [PedIVA], [PedTotal]) VALUES (5, 2, 4, 250000.0000, 3, 150000.0000, 19, 350000.0000)
INSERT [dbo].[Pedido] ([PedID], [PedUsu], [PedProd], [PedVrUnit], [PedCant], [PedSubTot], [PedIVA], [PedTotal]) VALUES (6, 1, 3, 1500000.0000, 2, 32000000.0000, 0, 42000000.0000)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ProId], [ProDesc], [ProValor]) VALUES (1, N'Computador', 3500000.0000)
INSERT [dbo].[Producto] ([ProId], [ProDesc], [ProValor]) VALUES (2, N'Armario', 800000.0000)
INSERT [dbo].[Producto] ([ProId], [ProDesc], [ProValor]) VALUES (3, N'Televisor', 4000000.0000)
INSERT [dbo].[Producto] ([ProId], [ProDesc], [ProValor]) VALUES (4, N'Lavadora', 720000.0000)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Seguridad] ON 

INSERT [dbo].[Seguridad] ([IdSeguridad], [Usuario], [NombreUsuario], [Contrasena], [Rol]) VALUES (1, N'Admin', N'Administrador', N'1234', N'Administrador')
INSERT [dbo].[Seguridad] ([IdSeguridad], [Usuario], [NombreUsuario], [Contrasena], [Rol]) VALUES (2, N'Delev', N'Developer', N'98745', N'Developer')
SET IDENTITY_INSERT [dbo].[Seguridad] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (1, N'David Ramirez', N'xxxx')
INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (2, N'Leonardo Heredia', N'yyyy')
INSERT [dbo].[Usuario] ([UsuID], [UsuNombre], [UsuPass]) VALUES (3, N'Andres Fernandez', N'qqqqqq')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Producto] FOREIGN KEY([PedProd])
REFERENCES [dbo].[Producto] ([ProId])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Producto]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Usuario] FOREIGN KEY([PedUsu])
REFERENCES [dbo].[Usuario] ([UsuID])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SalesProducts] SET  READ_WRITE 
GO
