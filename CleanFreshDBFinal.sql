USE [master]
GO
/****** Object:  Database [CleanFreshT]    Script Date: 29/06/2023 11:06:23 AM ******/
CREATE DATABASE [CleanFreshT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CleanFreshT', FILENAME = N'D:\SQL,DATA\MSSQL15.MSSQLSERVER\MSSQL\DATA\CleanFreshT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CleanFreshT_log', FILENAME = N'D:\SQL,DATA\MSSQL15.MSSQLSERVER\MSSQL\DATA\CleanFreshT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CleanFreshT] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CleanFreshT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CleanFreshT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CleanFreshT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CleanFreshT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CleanFreshT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CleanFreshT] SET ARITHABORT OFF 
GO
ALTER DATABASE [CleanFreshT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CleanFreshT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CleanFreshT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CleanFreshT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CleanFreshT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CleanFreshT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CleanFreshT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CleanFreshT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CleanFreshT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CleanFreshT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [CleanFreshT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CleanFreshT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CleanFreshT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CleanFreshT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CleanFreshT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CleanFreshT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CleanFreshT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CleanFreshT] SET RECOVERY FULL 
GO
ALTER DATABASE [CleanFreshT] SET  MULTI_USER 
GO
ALTER DATABASE [CleanFreshT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CleanFreshT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CleanFreshT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CleanFreshT] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CleanFreshT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CleanFreshT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CleanFreshT', N'ON'
GO
ALTER DATABASE [CleanFreshT] SET QUERY_STORE = OFF
GO
USE [CleanFreshT]
GO
/****** Object:  Table [dbo].[AbastecimientoProductos]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbastecimientoProductos](
	[ID_IngresoProductos] [int] IDENTITY(1,1) NOT NULL,
	[ID_CompraProveedor] [int] NULL,
	[ID_Producto] [int] NOT NULL,
	[Cantidad_Producto] [int] NULL,
	[Subtotal_monto] [float] NULL,
 CONSTRAINT [PK_AbastecimientoProductos] PRIMARY KEY CLUSTERED 
(
	[ID_IngresoProductos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Categoria] [varchar](50) NULL,
	[Eliminado_Categoria] [bit] NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[ID_Cliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Cliente] [varchar](50) NULL,
	[DNI_Cliente] [nchar](10) NULL,
	[Distrito_Cliente] [varchar](50) NULL,
	[Celular_Cliente] [varchar](30) NULL,
	[Correo] [varchar](100) NULL,
	[Eliminado_Cliente] [bit] NULL,
 CONSTRAINT [PK__Cliente__4BB7B1F87AD147F5] PRIMARY KEY CLUSTERED 
(
	[ID_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCompraProveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCompraProveedor](
	[ID_CompraProveedor] [int] NOT NULL,
	[ID_Proveedor] [int] NULL,
	[Fecha_Ingreso] [date] NULL,
	[Monto] [int] NULL,
 CONSTRAINT [PK_DetalleCompraProveedor] PRIMARY KEY CLUSTERED 
(
	[ID_CompraProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleComprobante]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleComprobante](
	[ID_Venta] [int] NOT NULL,
	[ID_Empleado] [int] NULL,
	[ID_Cliente] [int] NULL,
	[Fecha_Venta] [date] NULL,
	[Monto] [float] NULL,
 CONSTRAINT [PK__Pedido__00C11F991735EC4D] PRIMARY KEY CLUSTERED 
(
	[ID_Venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[ID_DetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[ID_Venta] [int] NULL,
	[ID_Producto] [int] NULL,
	[Cantidad] [int] NULL,
	[Precio] [float] NULL,
	[Subtotal] [float] NULL,
 CONSTRAINT [PK__Factura__492FE939D2D2CF0C] PRIMARY KEY CLUSTERED 
(
	[ID_DetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[ID_Empleado] [int] NOT NULL,
	[Nombre_Empleado] [varchar](50) NULL,
	[Contraseña] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Empleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[ID_Categoria] [int] NULL,
	[Nombre_producto] [varchar](50) NULL,
	[Marca] [varchar](50) NULL,
	[Precio_Producto] [float] NULL,
	[Stock_Inicial] [int] NULL,
	[Stock_Actual] [int] NULL,
	[Stock_Reposicion] [int] NULL,
	[Eliminado] [bit] NULL,
 CONSTRAINT [PK__Producto__ABDAF2B46E5B1E5D] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[ID_Proveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Proveedor] [varchar](50) NULL,
	[Celular_Proveedor] [int] NULL,
	[Distrito_Proveedor] [varchar](50) NULL,
	[Eliminado_P] [bit] NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[ID_Proveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AbastecimientoProductos] ON 

INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2014, 1000, 12, 15, 150)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2016, 1001, 1012, 2, 17)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2017, 1002, 1010, 11, 137.5)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2018, 1003, 14, 12, 102)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2019, 1004, 1015, 11, 220)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2020, 1004, 14, 14, 119)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2021, 1005, 1010, 14, 175)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2022, 1006, 1011, 11, 137.5)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2023, 1007, 1015, 12, 240)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2025, 1008, 1011, 15, 187.5)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2026, 1008, 14, 10, 85)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2027, 1008, 1020, 8, 100)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2028, 1009, 1027, 11, 110)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2029, 1009, 14, 11, 93.5)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2030, 1009, 1015, 4, 80)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2031, 1009, 1019, 3, 12)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2032, 1010, 14, 17, 144.5)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2033, 1010, 1024, 17, 136)
INSERT [dbo].[AbastecimientoProductos] ([ID_IngresoProductos], [ID_CompraProveedor], [ID_Producto], [Cantidad_Producto], [Subtotal_monto]) VALUES (2034, 1010, 1026, 45, 225)
SET IDENTITY_INSERT [dbo].[AbastecimientoProductos] OFF
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (1, N'Disolventes', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (2, N'Ambientadores', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (3, N'Desinfectante', 1)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (4, N'Bactericidas', 1)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (5, N'Antibacteriales', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (6, N'Limpiavidrios', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (7, N'Detergentes', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (8, N'Desengrasantes', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (9, N'Limpiadores de Cocina', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (10, N'Limpiadores de Baño', 1)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (11, N'Productos para Lavandería', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (12, N'Limpiadores de Pisos', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (13, N'Productos de Cuidado Personal', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (14, N'Productos para Automóviles', 0)
INSERT [dbo].[Categoria] ([ID_Categoria], [Nombre_Categoria], [Eliminado_Categoria]) VALUES (15, N'CleanClean', 0)
SET IDENTITY_INSERT [dbo].[Categoria] OFF
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (1, N'Cesar', N'70151655  ', N'Surco', N'959597524', N'Csar17@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (2, N'Juan', N'71515156  ', N'San Juan de Miraflores', N'985151332', N'Juan1@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (3, N'Hugo', N'55489966  ', N'Monterrico', N'985564442', N'Hugod@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (4, N'Fabrizio', N'98547126  ', N'San Miguel', N'968888888', N'Fabri@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (6, N'Juan Perez', N'12345678  ', N'San Isidro', N'987654321', N'juanperez@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (7, N'María Rodríguez', N'79876543  ', N'San Miguel', N'912345678', N'mariarodriguez@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (8, N'Pedro Sánchez', N'23456789  ', N'San Juan de Miraflores', N'923456789', N'pedrosanchez@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (9, N'Laura Gómez', N'34567890  ', N'Surco', N'934567890', N'lauragomez@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (10, N'Carlos López', N'45678901  ', N'Monterrico', N'945678901', N'carloslopez@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (11, N'Ana Torres', N'56789012  ', N'Miraflores', N'956789012', N'anatorres@gmail.com', 1)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (12, N'Luis ', N'67890123  ', N'Ate', N'967890123', N'luisgonzalez@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (13, N'Miguel Ramirez', N'78901234  ', N'La Victoria', N'978901234', N'miguelramirez@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (14, N'Lucía Herrera', N'89012345  ', N'Monterrico', N'989012345', N'luciaherrera@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (15, N'Fernando Castro', N'90123456  ', N'Breña', N'990123456', N'fernandocastro@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (16, N'Marcela Vargas', N'11234567  ', N'Comas', N'901234567', N'marcelavargas@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (17, N'Sandra Cáceres', N'19876543  ', N'Callao', N'902345678', N'sandracaceres@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (18, N'Roberto Montes', N'19871234  ', N'Pamplona', N'903456789', N'robertomontes@gmail.com', 0)
INSERT [dbo].[Cliente] ([ID_Cliente], [Nombre_Cliente], [DNI_Cliente], [Distrito_Cliente], [Celular_Cliente], [Correo], [Eliminado_Cliente]) VALUES (1019, N'Mario Catañerda', N'75611446  ', N'San Miguel', N'987654321', N'Mariog123@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1000, 2, CAST(N'2023-06-24' AS Date), 150)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1001, 4, CAST(N'2023-06-27' AS Date), 17)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1002, 3, CAST(N'2023-06-28' AS Date), 137)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1003, 3, CAST(N'2023-06-28' AS Date), 102)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1004, 3, CAST(N'2023-06-28' AS Date), 339)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1005, 3, CAST(N'2023-06-28' AS Date), 175)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1006, 3, CAST(N'2023-06-28' AS Date), 137)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1007, 4, CAST(N'2023-06-28' AS Date), 240)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1008, 3, CAST(N'2023-06-29' AS Date), 372)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1009, 6, CAST(N'2023-06-29' AS Date), 295)
INSERT [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor], [ID_Proveedor], [Fecha_Ingreso], [Monto]) VALUES (1010, 5, CAST(N'2023-06-29' AS Date), 505)
GO
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1000, 202031764, 4, CAST(N'2023-06-24' AS Date), 83)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1001, 202031764, 2, CAST(N'2023-06-27' AS Date), 0)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1002, 202031764, 3, CAST(N'2023-06-27' AS Date), 75)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1003, 202031764, 4, CAST(N'2023-06-27' AS Date), 127)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1004, 202031764, 3, CAST(N'2023-06-27' AS Date), 187)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1005, 202031764, 6, CAST(N'2023-06-27' AS Date), 200)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1006, 202031764, 4, CAST(N'2023-06-27' AS Date), 110)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1007, 202031764, 2, CAST(N'2023-06-27' AS Date), 119)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1008, 202031764, 2, CAST(N'2023-09-19' AS Date), 42)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1009, 202031764, 4, CAST(N'2023-08-09' AS Date), 52)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1010, 202031764, 6, CAST(N'2023-05-17' AS Date), 42)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1011, 202031764, 4, CAST(N'2023-06-27' AS Date), 34)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1012, 202031764, 4, CAST(N'2023-06-28' AS Date), 137)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1013, 202031764, 2, CAST(N'2023-01-04' AS Date), 387)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1014, 202031764, 9, CAST(N'2023-02-15' AS Date), 246)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1015, 202031764, 12, CAST(N'2023-06-29' AS Date), 739)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1016, 202031764, 9, CAST(N'2023-06-29' AS Date), 59)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1017, 202031764, 9, CAST(N'2023-06-29' AS Date), 140)
INSERT [dbo].[DetalleComprobante] ([ID_Venta], [ID_Empleado], [ID_Cliente], [Fecha_Venta], [Monto]) VALUES (1018, 202031764, 12, CAST(N'2023-06-29' AS Date), 180)
GO
SET IDENTITY_INSERT [dbo].[DetalleVenta] ON 

INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (13, 1002, 5, 10, 7, 75)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (14, 1003, 6, 15, 8, 127)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (16, 1005, 12, 20, 10, 200)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (17, 1006, 12, 11, 10, 110)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (18, 1007, 14, 14, 8, 119)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (19, 1008, 14, 5, 8, 42)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (20, 1009, 3, 5, 10, 52)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (21, 1010, 6, 5, 8, 42)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (22, 1011, 1012, 4, 8, 34)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (23, 1012, 1011, 11, 12, 137)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (24, 1013, 1, 11, 14, 154)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (25, 1013, 14, 4, 8, 34)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (26, 1013, 14, 7, 8, 59)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (27, 1013, 1015, 7, 20, 140)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (28, 1014, 1012, 7, 8, 59)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (29, 1014, 1011, 9, 12, 112)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (30, 1014, 1011, 6, 12, 75)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (35, 1015, 14, 17, 8, 144)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (36, 1015, 1010, 22, 12, 275)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (37, 1015, 1015, 16, 20, 320)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (38, 1016, 1012, 7, 8, 59)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (39, 1017, 1015, 7, 20, 140)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (40, 1018, 1010, 7, 12, 87)
INSERT [dbo].[DetalleVenta] ([ID_DetalleVenta], [ID_Venta], [ID_Producto], [Cantidad], [Precio], [Subtotal]) VALUES (41, 1018, 14, 11, 8, 93)
SET IDENTITY_INSERT [dbo].[DetalleVenta] OFF
GO
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre_Empleado], [Contraseña]) VALUES (201712336, N'Ariam Bartolo', N'Amaraxis')
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre_Empleado], [Contraseña]) VALUES (201715076, N'Edgar Onofre', N'Eonofre')
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre_Empleado], [Contraseña]) VALUES (201812390, N'Luis Benites', N'Derek04')
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre_Empleado], [Contraseña]) VALUES (201917243, N'Cesar Martinez', N'Cesar17')
INSERT [dbo].[Empleado] ([ID_Empleado], [Nombre_Empleado], [Contraseña]) VALUES (202031764, N'Darwin Mendoza', N'Darwin123')
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1, 2, N'Spray Sapolio', N'Sapolio', 14, 100, 59, 23, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (3, 1, N'SparkleClean Pro', N'InnoBrand', 10.5, 50, 25, 20, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (5, 3, N'GermShield Ultra', N'HygieneTech', 7.5, 20, 20, 5, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (6, 4, N'MicroKill Max', N'BioShield', 8.5, 40, 20, 15, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (12, 4, N'Bactericide', N'BioShield', 10, 60, 44, 25, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (13, 5, N'ShieldClean Antibacterial Soap', N'PureProtect', 5, 30, 30, 10, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (14, 6, N'CrystalClear Glass Cleaner', N'ShineMaster', 8.5, 45, 51, 18, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1009, 7, N'Cissar Clear Max', N'TheGods', 13, 50, 50, 10, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1010, 7, N'JadesMaxClear 200g', N'MaxJades', 12.5, 42, 38, 20, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1011, 6, N'MaxClear Jade', N'JadeCorp', 12.5, 40, 40, 10, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1012, 4, N'CrystalClear', N'Master', 8.5, 40, 24, 10, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1015, 5, N'Sapolio Clear Manchas', N'Sapolio', 20, 40, 37, 10, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1016, 9, N'TrapeadorExClean', N'Zibrio', 12, 40, 40, 10, 1)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1017, 14, N'ElectroBlend', N'Nextron', 17.5, 100, 100, 20, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1018, 2, N'FreshCleaner', N'PureShine', 9.5, 100, 92, 20, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1019, 2, N'GleamWipe', N'SparkleTech', 4, 50, 50, 10, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1020, 3, N'DustBuster', N'CleanMaster', 12.5, 75, 83, 15, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1021, 4, N'OdorFree', N'FragranceGuru', 6.5, 200, 183, 40, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1022, 5, N'SpotErase', N'StainBuster', 7, 80, 74, 16, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1023, 3, N'GermShield', N'HealthGuard', 115, 120, 120, 24, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1024, 7, N'AllPurpose', N'SuperClean', 8, 150, 167, 30, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1025, 8, N'ShinyFloors', N'GlowPro', 14.5, 100, 100, 20, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1026, 9, N'GrimeGone', N'DirtDestroyer', 5, 90, 135, 18, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1027, 7, N'MoldBlast', N'FreshAir', 10, 60, 71, 12, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1028, 11, N'StreakFree', N'CrystalClear', 9.5, 110, 110, 22, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1029, 2, N'HuxFlower', N'Aven', 22, 70, 70, 22, 0)
INSERT [dbo].[Producto] ([ID_Producto], [ID_Categoria], [Nombre_producto], [Marca], [Precio_Producto], [Stock_Inicial], [Stock_Actual], [Stock_Reposicion], [Eliminado]) VALUES (1030, 15, N'CleanFreshMAX', N'CleanFresh', 12, 70, 70, 30, 0)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Proveedor] ON 

INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (1, N'Shine', 987665422, N'Ate', 0)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (2, N'Cleansed', 956644211, N'San Isidro', 1)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (3, N'Nova', 942311656, N'Santa Clara', 0)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (4, N'MaxLimpio', 955446141, N'Chorrillos', 0)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (5, N'MsMusculo', 955778686, N'San Isidro', 0)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (6, N'Darwin', 946633155, N'San Isidro', 0)
INSERT [dbo].[Proveedor] ([ID_Proveedor], [Nombre_Proveedor], [Celular_Proveedor], [Distrito_Proveedor], [Eliminado_P]) VALUES (7, N'Dennis', 985462144, N'Surco', 0)
SET IDENTITY_INSERT [dbo].[Proveedor] OFF
GO
ALTER TABLE [dbo].[AbastecimientoProductos]  WITH CHECK ADD  CONSTRAINT [FK_AbastecimientoProductos_DetalleCompraProveedor] FOREIGN KEY([ID_CompraProveedor])
REFERENCES [dbo].[DetalleCompraProveedor] ([ID_CompraProveedor])
GO
ALTER TABLE [dbo].[AbastecimientoProductos] CHECK CONSTRAINT [FK_AbastecimientoProductos_DetalleCompraProveedor]
GO
ALTER TABLE [dbo].[AbastecimientoProductos]  WITH CHECK ADD  CONSTRAINT [FK_AbastecimientoProductos_Producto] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Producto] ([ID_Producto])
GO
ALTER TABLE [dbo].[AbastecimientoProductos] CHECK CONSTRAINT [FK_AbastecimientoProductos_Producto]
GO
ALTER TABLE [dbo].[DetalleCompraProveedor]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCompraProveedor_Proveedor] FOREIGN KEY([ID_Proveedor])
REFERENCES [dbo].[Proveedor] ([ID_Proveedor])
GO
ALTER TABLE [dbo].[DetalleCompraProveedor] CHECK CONSTRAINT [FK_DetalleCompraProveedor_Proveedor]
GO
ALTER TABLE [dbo].[DetalleComprobante]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__DNIClien__2B3F6F97] FOREIGN KEY([ID_Cliente])
REFERENCES [dbo].[Cliente] ([ID_Cliente])
GO
ALTER TABLE [dbo].[DetalleComprobante] CHECK CONSTRAINT [FK__Pedido__DNIClien__2B3F6F97]
GO
ALTER TABLE [dbo].[DetalleComprobante]  WITH CHECK ADD  CONSTRAINT [FK__Pedido__DNIEmple__2A4B4B5E] FOREIGN KEY([ID_Empleado])
REFERENCES [dbo].[Empleado] ([ID_Empleado])
GO
ALTER TABLE [dbo].[DetalleComprobante] CHECK CONSTRAINT [FK__Pedido__DNIEmple__2A4B4B5E]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_DetalleComprobante] FOREIGN KEY([ID_Venta])
REFERENCES [dbo].[DetalleComprobante] ([ID_Venta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_DetalleComprobante]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [FK_DetalleVenta_Producto] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Producto] ([ID_Producto])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [FK_DetalleVenta_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categoria] ([ID_Categoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_monto_ingreso_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_actualizar_monto_ingreso_proveedor]
@id int,
@monto float
as
begin
    update DetalleCompraProveedor set Monto=@monto where ID_CompraProveedor=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_monto_venta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_actualizar_monto_venta]
@id int,
@monto float
as
begin
    update DetalleComprobante set Monto=@monto where ID_Venta=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_actualizar_stock_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_actualizar_stock_producto]
@id int,
@nuevo int
as
begin
    update Producto set Stock_Actual=Stock_Actual+@nuevo where ID_Producto=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_categoria_nombre]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_buscar_categoria_nombre]
@nombre varchar(50)
as
begin
select * from Categoria where Nombre_Categoria like @nombre + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_cliente_ID]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_buscar_cliente_ID]
@id int
as
begin
select * from Cliente where ID_Cliente=@id;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_cliente_nombre]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_buscar_cliente_nombre]
@nombre varchar(50)
as
begin
select * from Cliente where Nombre_Cliente like @nombre + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_detalle_comp_proveedor_id]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_buscar_detalle_comp_proveedor_id]
@id int
as
begin
select * from DetalleCompraProveedor where ID_CompraProveedor=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_detalle_comprobante_id]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_buscar_detalle_comprobante_id]
@id int
as
begin
select * from DetalleComprobante where ID_Venta=@id
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_empleado_id]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_buscar_empleado_id]
@ID int
as
begin
select * from Empleado where ID_Empleado=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_producto_categoria]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_buscar_producto_categoria]
@categoria varchar(50)
as
begin
SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion From (SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion FROM Producto p JOIN Categoria C ON p.ID_Categoria = c.ID_Categoria) as b where b.Nombre_Categoria like @categoria  + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_producto_id]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_buscar_producto_id]
@id int
as
begin
SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion From (SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion FROM Producto p JOIN Categoria C ON p.ID_Categoria = c.ID_Categoria) as b where b.ID_Producto like STR(@id)  + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_producto_nombre]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_buscar_producto_nombre]
@nombre varchar(50)
as
begin
SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion From (SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion FROM Producto p JOIN Categoria C ON p.ID_Categoria = c.ID_Categoria) as b where b.Nombre_producto like @nombre  + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_proveedor_nombre]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_buscar_proveedor_nombre]
@nombre varchar(50)
as
begin
select * from Proveedor where Nombre_Proveedor like @nombre + '%'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_Datos_boleta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_Datos_boleta]
@id_VENTA int
as
begin
SELECT Cantidad, Nombre_producto, Precio, Subtotal from (SELECT ID_DetalleVenta, ID_Venta, P.ID_Producto,P.Nombre_producto, Cantidad, Precio,Subtotal FROM DetalleVenta V JOIN Producto P ON P.ID_Producto = V.ID_Producto) as a where a.ID_Venta=@id_VENTA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_detalle_ventas_mes]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_detalle_ventas_mes]
@mes VARCHAR(50)
AS
BEGIN
    SELECT P.Nombre_producto, SUM(DV.Cantidad) AS CantidadVendida, SUM(DV.Cantidad * P.Precio_Producto) AS IngresosTotales
    FROM DetalleVenta DV
    JOIN Producto P ON DV.ID_Producto = P.ID_Producto
    JOIN DetalleComprobante DC ON DV.ID_Venta = DC.ID_Venta
    WHERE MONTH(DC.Fecha_Venta) = @mes
    GROUP BY P.Nombre_producto;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_Abastecimiento_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_eliminar_Abastecimiento_producto]
@id_comprobante int
as
begin
    delete from AbastecimientoProductos where ID_CompraProveedor=@id_comprobante
end
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_Detalle_venta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_eliminar_Detalle_venta]
@id_venta int
as
begin
    delete from DetalleVenta where ID_Venta=@id_venta
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_Abastecimiento_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_listar_Abastecimiento_producto]
as
begin
SELECT ID_IngresoProductos, ID_CompraProveedor, P.ID_Producto, Nombre_producto, Cantidad_Producto,Subtotal_monto FROM AbastecimientoProductos I JOIN Producto P ON P.ID_Producto = I.ID_Producto order by ID_IngresoProductos
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_Abastecimiento_producto_id_compra_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_listar_Abastecimiento_producto_id_compra_proveedor]
@id_compraProveedor int
as
begin
SELECT ID_IngresoProductos, ID_CompraProveedor, a.ID_Producto, Nombre_producto, Cantidad_Producto,Subtotal_monto from (SELECT ID_IngresoProductos, ID_CompraProveedor, P.ID_Producto, Nombre_producto, Cantidad_Producto,Subtotal_monto FROM AbastecimientoProductos I JOIN Producto P ON P.ID_Producto = I.ID_Producto) as a where a.ID_CompraProveedor=@id_compraProveedor
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_categoria]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listar_categoria]
as
begin
select ID_Categoria,Nombre_Categoria from Categoria WHERE Eliminado_Categoria=0;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_cliente]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listar_cliente]
as
begin
select ID_Cliente, Nombre_Cliente, DNI_Cliente, Distrito_Cliente, Celular_Cliente, Correo from Cliente WHERE Eliminado_Cliente=0;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_detalle_compra_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[sp_listar_detalle_compra_proveedor]
as
begin
select * from DetalleCompraProveedor;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_Detalle_comprobante]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_listar_Detalle_comprobante]
as
begin
select * from DetalleComprobante;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_Detalle_venta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_listar_Detalle_venta]
as
begin
SELECT * from DetalleVenta 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_Detalle_venta_id_venta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_listar_Detalle_venta_id_venta]
@id_VENTA int
as
begin
SELECT * from (SELECT ID_DetalleVenta, ID_Venta, P.ID_Producto,P.Nombre_producto, Cantidad, Precio,Subtotal FROM DetalleVenta V JOIN Producto P ON P.ID_Producto = V.ID_Producto) as a where a.ID_Venta=@id_VENTA
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_empleado]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_listar_empleado]
as
begin
select * from Empleado;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_empleado_reporte]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_listar_empleado_reporte]
as
begin
select ID_Empleado,Nombre_Empleado from Empleado;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_marcas_productos]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_listar_marcas_productos]
AS
BEGIN
    SELECT DISTINCT Marca
    FROM Producto;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_listar_producto]
as
begin
SELECT ID_Producto,Nombre_producto, Marca, Nombre_Categoria, Precio_Producto,Stock_Inicial,Stock_Actual,Stock_Reposicion FROM (Producto p JOIN Categoria C ON p.ID_Categoria = c.ID_Categoria) WHERE Eliminado=0
 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_listar_proveedor]
as
begin
select ID_Proveedor,Nombre_Proveedor, Celular_Proveedor, Distrito_Proveedor from Proveedor WHERE Eliminado_P=0;
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_Abastecimiento_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_mantenimiento_Abastecimiento_producto]
@id int,
@id_compraProveedor int,
@id_producto int,
@cantidad int,
@subtotal float,
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into AbastecimientoProductos(ID_CompraProveedor,ID_Producto,Cantidad_Producto,Subtotal_monto)
    values(@id_compraProveedor,@id_producto,@cantidad,@subtotal)
    set @accion='Se agrego un producto'
end
else if (@accion='2')/*eliminar*/
begin
    delete from AbastecimientoProductos where ID_IngresoProductos=@id
    set @accion='Se eliminó el producto de la lista'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_categoria]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_categoria]
@id int,
@nombre varchar(50),
@accion varchar(50) output
as
if (@accion='1')
begin
    insert into Categoria(Nombre_Categoria)
    values(@nombre)
    set @accion='Se inserto la categoria: ' + @nombre
	
	SET @id = SCOPE_IDENTITY();

	UPDATE Categoria
        SET Eliminado_Categoria = 0
        WHERE ID_Categoria = @id;
end
else if (@accion='2')
begin
    update Categoria set Nombre_Categoria=@nombre where ID_Categoria=@id
    set @accion='Se modifico la categoria: ' + @nombre
end
else if (@accion='3')
begin
     UPDATE Categoria
        SET Eliminado_Categoria = 1
        WHERE ID_Categoria = @id;

        SET @accion = 'Se marcó como eliminado la categoria con ID: ' + CAST(@id AS varchar);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_cliente]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_cliente]
@id int,
@nombre varchar(50),
@DNI int,
@distrito varchar(50),
@celular varchar(50),
@correo varchar(50),
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into Cliente(Nombre_Cliente, DNI_Cliente,Distrito_Cliente, Celular_Cliente, Correo)
    values(@nombre, @DNI,@distrito, @celular, @correo)
		SET @id = SCOPE_IDENTITY();
		 UPDATE Cliente
        SET Eliminado_Cliente = 0
        WHERE ID_Cliente = @id;
        SET @accion = 'Se agregó al cliente:' + @nombre;
end
else if (@accion='2')/* modificar*/
begin
    update Cliente set Nombre_Cliente=@nombre, DNI_Cliente=@DNI,Distrito_Cliente=@distrito ,Celular_Cliente=@celular ,Correo=@correo where ID_Cliente=@id
    set @accion='Se modifico el cliente: ' + @nombre
end
else if (@accion='3')/* eliminar*/
begin
     UPDATE Cliente
        SET Eliminado_Cliente = 1
        WHERE ID_Cliente = @id;
        SET @accion = 'Se marcó como eliminado al cliente con ID: ' + CAST(@id AS varchar);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_detalle_compra_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_detalle_compra_proveedor]
@id int,
@id_proveedor int,
@fecha date,
@monto float,
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into DetalleCompraProveedor(ID_CompraProveedor,ID_Proveedor,Fecha_Ingreso,Monto)
    values(@id,@id_proveedor,@fecha,@monto)
    set @accion='Se creo un detalle de comprobante'
end
else if (@accion='2')/*eliminar*/
begin
    delete from DetalleCompraProveedor where ID_CompraProveedor=@id
    set @accion='Se cancelo el ingreso de productos'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_Detalle_comprobante]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_Detalle_comprobante]
@id int,
@id_empleado int,
@id_cliente int,
@fecha date,
@monto float,
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into DetalleComprobante(ID_Venta,ID_Empleado,ID_Cliente,Fecha_Venta,Monto)
    values(@id,@id_empleado,@id_cliente,@fecha,@monto)
    set @accion='Se creo un comprobante de venta'
end
else if (@accion='2')/*eliminar*/
begin
    delete from DetalleComprobante where ID_Venta=@id
    set @accion='Se cancelo la venta'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_Detalle_venta]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_Detalle_venta]
@id int,
@id_venta int,
@id_producto int,
@cantidad int,
@precio int,
@subtotal int,
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into DetalleVenta(ID_Venta,ID_Producto,Cantidad,Precio,Subtotal)
    values(@id_venta,@id_producto,@cantidad,@precio,@subtotal)
    set @accion='Se agrego un producto'
end
else if (@accion='2')/*eliminar*/
begin
    delete from DetalleVenta where ID_DetalleVenta=@id
    set @accion='Se eliminó el producto de la lista'
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_empleado]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_mantenimiento_empleado]
@id int,
@nombre varchar(50),
@contraseña varchar(50),
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into Empleado(ID_Empleado, Nombre_Empleado,Contraseña)
    values(@id, @nombre,@contraseña)
    set @accion='Se creo el empleado: ' + @nombre
end
else if (@accion='2')/* modificar*/
begin
    update Empleado set @contraseña=@contraseña where ID_Empleado=@id
    set @accion='Se modifico el empleado: ' + @nombre
end
else if (@accion='3')/* eliminar*/
begin
    delete from Empleado where ID_Empleado=@id
    set @accion='Se borro el empleado: ' + @nombre
end
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_producto]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_mantenimiento_producto]
@id INT,
@nombre VARCHAR(50),
@marca VARCHAR(50),
@id_categoria INT,
@precio FLOAT,
@stock_inicial INT,
@stock_actual INT,
@stock_repo INT,
@accion VARCHAR(50) OUTPUT
AS
BEGIN
    DECLARE @nombreN VARCHAR(50);

    IF (@accion = '1')
    BEGIN
        INSERT INTO Producto (Nombre_producto, Marca, ID_Categoria, Precio_Producto, Stock_Inicial, Stock_Actual, Stock_Reposicion)
        VALUES (@nombre, @marca, @id_categoria, @precio, @stock_inicial, @stock_actual, @stock_repo);
		
		SET @id = SCOPE_IDENTITY();

        UPDATE Producto
        SET Eliminado = 0
        WHERE ID_Producto = @id;

        SET @accion = 'Se agregó el producto con ID: ' + CAST(@id AS VARCHAR);
    END
    ELSE IF (@accion = '2')
    BEGIN
        UPDATE Producto
        SET Nombre_producto = @nombre, Marca = @marca, Precio_Producto = @precio
        WHERE ID_Producto = @id;

        SET @accion = 'Se modificó el producto con ID: ' + CAST(@id AS VARCHAR);
    END
    ELSE IF (@accion = '3')
    BEGIN
        UPDATE Producto
        SET Eliminado = 1
        WHERE ID_Producto = @id;

        SET @accion = 'Se marcó como eliminado el producto con ID: ' + CAST(@id AS VARCHAR);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_mantenimiento_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_mantenimiento_proveedor]
@id int,
@nombre varchar(50),
@celular varchar(50),
@distrito varchar(50),
@accion varchar(50) output
as
if (@accion='1')/* insertar*/
begin
    insert into Proveedor(Nombre_Proveedor, Celular_Proveedor,Distrito_Proveedor)
    values(@nombre, @celular,@distrito)
    set @accion='Se inserto el proveedor: ' + @nombre

	SET @id = SCOPE_IDENTITY();

	 UPDATE Proveedor
        SET Eliminado_P = 0
        WHERE ID_Proveedor = @id;

end
else if (@accion='2')/* modificar*/
begin
    update Proveedor set Nombre_Proveedor=@nombre, Celular_Proveedor=@celular,Distrito_Proveedor=@distrito where ID_Proveedor=@id
    set @accion='Se modifico el proveedor: ' + @nombre
end
else if (@accion='3')/* eliminar*/
begin
     UPDATE Proveedor
        SET Eliminado_P = 1
        WHERE ID_Proveedor = @id;

        SET @accion = 'Se marcó como eliminado al proveedor con ID: ' + CAST(@id AS varchar);
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_compra_proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[sp_reporte_compra_proveedor]
as
begin
select Nombre_Proveedor, SUM(TABLA6.Cantidad_Producto) as CantidadProductos 
FROM (SELECT tabla4.Nombre_Proveedor,ID_CompraProveedor,P.Nombre_producto, Cantidad_Producto, Fecha_Ingreso,Distrito_Proveedor
from (select Nombre_Proveedor,Cantidad_Producto, ID_Producto,Fecha_Ingreso,tabla2.ID_CompraProveedor, Distrito_Proveedor  
from (select * from (select Nombre_Proveedor,Distrito_Proveedor,ID_CompraProveedor, Fecha_Ingreso 
from Proveedor c JOIN DetalleCompraProveedor D on C.ID_Proveedor=D.ID_Proveedor) tabla1 ) tabla2 join AbastecimientoProductos V 
on tabla2.ID_CompraProveedor=v.ID_CompraProveedor) tabla4 join Producto p ON tabla4.ID_Producto=p.ID_Producto) 
TABLA6 GROUP BY TABLA6.Nombre_Proveedor
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_detalles_Compra_Proveedor]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_reporte_detalles_Compra_Proveedor]
@nombreProveedor varchar(50)
as
begin
SELECT tabla4.Nombre_Proveedor,ID_CompraProveedor,P.Nombre_producto,Cantidad_Producto,Fecha_Ingreso
from (select Nombre_Proveedor,Cantidad_Producto, ID_Producto,Fecha_Ingreso,tabla2.ID_CompraProveedor  

from (select * from 

(select Nombre_proveedor, Distrito_proveedor ,ID_CompraProveedor,Fecha_Ingreso from Proveedor c JOIN DetalleCompraProveedor D on C.ID_Proveedor=D.ID_Proveedor)

tabla1 where tabla1.Nombre_Proveedor=@nombreProveedor)

tabla2 join AbastecimientoProductos V on tabla2.ID_CompraProveedor=v.ID_CompraProveedor) 

tabla4 join Producto p ON tabla4.ID_Producto=p.ID_Producto
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_detalles_ventas_distrito]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_reporte_detalles_ventas_distrito]
@distrito varchar(50)
as
begin
SELECT tabla4.Nombre_Cliente,ID_Venta,P.Nombre_producto, Cantidad, Fecha_Venta from (select Nombre_Cliente,Cantidad, ID_Producto,Fecha_Venta,tabla2.ID_Venta  from (select * from (select Nombre_Cliente,Distrito_Cliente,ID_Venta, Fecha_Venta from Cliente c JOIN DetalleComprobante D on C.ID_Cliente=D.ID_Cliente) tabla1 where tabla1.Distrito_Cliente=@distrito) tabla2 join DetalleVenta V on tabla2.ID_Venta=v.ID_Venta) tabla4 join Producto p ON tabla4.ID_Producto=p.ID_Producto
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_detalles_ventas_marca]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_reporte_detalles_ventas_marca]
    @MarcaProducto VARCHAR(50)
AS
BEGIN
    SELECT V.ID_Venta, P.Nombre_producto AS NombreProducto, DV.Cantidad, V.Fecha_Venta
    FROM DetalleComprobante V
    INNER JOIN DetalleVenta DV ON V.ID_Venta = DV.ID_Venta
    INNER JOIN Producto P ON DV.ID_Producto = P.ID_Producto
    WHERE P.Marca = @MarcaProducto;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_productos_categoria]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_reporte_productos_categoria]
@categoria varchar(50)
as
begin
SELECT Nombre_producto, SUM(D.Cantidad) as CantidadVendida FROM (select tabla1.ID_Producto,Nombre_producto,Nombre_Categoria from(SELECT ID_Producto,Nombre_producto,Nombre_Categoria FROM Producto p JOIN Categoria C ON p.ID_Categoria = c.ID_Categoria) tabla1 where tabla1.Nombre_Categoria=@categoria) tabla2 join DetalleVenta D on tabla2.ID_Producto=D.ID_Producto group by Nombre_Producto
end
GO
/****** Object:  StoredProcedure [dbo].[sp_reporte_ventas_distritos]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[sp_reporte_ventas_distritos]
as
begin
select Distrito_Cliente, SUM(TABLA6.Cantidad) as CantidadProductos FROM (SELECT tabla4.Nombre_Cliente,ID_Venta,P.Nombre_producto, Cantidad, Fecha_Venta,Distrito_Cliente from (select Nombre_Cliente,Cantidad, ID_Producto,Fecha_Venta,tabla2.ID_Venta, Distrito_Cliente  from (select * from (select Nombre_Cliente,Distrito_Cliente,ID_Venta, Fecha_Venta from Cliente c JOIN DetalleComprobante D on C.ID_Cliente=D.ID_Cliente) tabla1 ) tabla2 join DetalleVenta V on tabla2.ID_Venta=v.ID_Venta) tabla4 join Producto p ON tabla4.ID_Producto=p.ID_Producto) TABLA6 GROUP BY TABLA6.Distrito_Cliente
end
GO
/****** Object:  StoredProcedure [dbo].[sp_venta_del_mes]    Script Date: 29/06/2023 11:06:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_venta_del_mes]
@mes varchar(50)
as
begin
SELECT @mes as N_Mes, SUM(CantidadVendida) as CantidadProductos from (select Nombre_producto, Count(Cantidad) as CantidadVendida from (select tabla1.ID_Venta, ID_Producto, Cantidad from (select ID_Venta from DetalleComprobante where MONTH(Fecha_Venta)=@mes) tabla1 join DetalleVenta D on tabla1.ID_Venta=D.ID_Venta) tabla2 join Producto P on tabla2.ID_Producto=P.ID_Producto GROUP BY Nombre_producto) TABLA3;
end
GO
USE [master]
GO
ALTER DATABASE [CleanFreshT] SET  READ_WRITE 
GO
