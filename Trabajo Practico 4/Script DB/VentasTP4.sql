USE [master]
GO
/****** Object:  Database [VentasTP4]    Script Date: 20/11/2020 21:12:29 ******/
CREATE DATABASE [VentasTP4]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VentasTP4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VentasTP4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VentasTP4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\VentasTP4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VentasTP4] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VentasTP4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VentasTP4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VentasTP4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VentasTP4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VentasTP4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VentasTP4] SET ARITHABORT OFF 
GO
ALTER DATABASE [VentasTP4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VentasTP4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VentasTP4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VentasTP4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VentasTP4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VentasTP4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VentasTP4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VentasTP4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VentasTP4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VentasTP4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VentasTP4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VentasTP4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VentasTP4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VentasTP4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VentasTP4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VentasTP4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VentasTP4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VentasTP4] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VentasTP4] SET  MULTI_USER 
GO
ALTER DATABASE [VentasTP4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VentasTP4] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VentasTP4] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VentasTP4] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VentasTP4] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VentasTP4] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [VentasTP4] SET QUERY_STORE = OFF
GO
USE [VentasTP4]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 20/11/2020 21:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[compras] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 20/11/2020 21:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[id_venta] [int] NOT NULL,
	[id_producto] [int] NOT NULL,
	[cantidad] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 20/11/2020 21:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](50) NOT NULL,
	[apellido] [nvarchar](50) NOT NULL,
	[ventas] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 20/11/2020 21:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [nvarchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[vendidos] [int] NULL,
	[stock] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ventas]    Script Date: 20/11/2020 21:12:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ventas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_empleado] [int] NOT NULL,
	[id_cliente] [int] NOT NULL,
	[importe] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (1, N'José', N'Rodriguez', 1)
INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (2, N'Leticia', N'Perez', 1)
INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (3, N'Pablo', N'Lopez', 1)
INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (4, N'Sofia', N'Hernandez', 1)
INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (5, N'Marta', N'Rosales', 1)
INSERT [dbo].[Clientes] ([id], [nombre], [apellido], [compras]) VALUES (6, N'Josefina', N'García', 0)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
INSERT [dbo].[Detalle] ([id_venta], [id_producto], [cantidad]) VALUES (1, 1, 1)
INSERT [dbo].[Detalle] ([id_venta], [id_producto], [cantidad]) VALUES (2, 2, 2)
INSERT [dbo].[Detalle] ([id_venta], [id_producto], [cantidad]) VALUES (3, 3, 1)
INSERT [dbo].[Detalle] ([id_venta], [id_producto], [cantidad]) VALUES (4, 4, 2)
INSERT [dbo].[Detalle] ([id_venta], [id_producto], [cantidad]) VALUES (5, 5, 1)
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (1, N'Adela', N'Salas', 1)
INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (2, N'Marcos', N'Loyola', 1)
INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (3, N'María', N'Santana', 1)
INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (4, N'Pilar', N'Ruiz', 1)
INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (5, N'Pepe', N'Ruiz', 1)
INSERT [dbo].[Empleados] ([id], [nombre], [apellido], [ventas]) VALUES (6, N'Juan', N'Gómez', 0)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (1, N'Disco duro SATA3 1TB', 86, 1, 80)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (2, N'Memoria RAM DDR4 8GB', 120, 2, 70)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (3, N'Disco SSD 1 TB', 150, 1, 100)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (4, N'GeForce GTX 1050Ti', 185, 2, 55)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (5, N'GeForce GTX 1080 Xtreme', 755, 1, 60)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (6, N'Monitor 24 LED Full HD', 202, 0, 98)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (7, N'Portátil Yoga 520', 559, 0, 102)
INSERT [dbo].[Productos] ([id], [descripcion], [precio], [vendidos], [stock]) VALUES (8, N'Impresora HP Laserjet Pro M26nw', 180, 0, 45)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Ventas] ON 

INSERT [dbo].[Ventas] ([id], [id_empleado], [id_cliente], [importe]) VALUES (1, 1, 1, 86)
INSERT [dbo].[Ventas] ([id], [id_empleado], [id_cliente], [importe]) VALUES (2, 2, 2, 240)
INSERT [dbo].[Ventas] ([id], [id_empleado], [id_cliente], [importe]) VALUES (3, 3, 3, 150)
INSERT [dbo].[Ventas] ([id], [id_empleado], [id_cliente], [importe]) VALUES (4, 4, 4, 370)
INSERT [dbo].[Ventas] ([id], [id_empleado], [id_cliente], [importe]) VALUES (5, 5, 5, 755)
SET IDENTITY_INSERT [dbo].[Ventas] OFF
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD FOREIGN KEY([id_venta])
REFERENCES [dbo].[Ventas] ([id])
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD FOREIGN KEY([id_producto])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([id_cliente])
REFERENCES [dbo].[Clientes] ([id])
GO
ALTER TABLE [dbo].[Ventas]  WITH CHECK ADD FOREIGN KEY([id_empleado])
REFERENCES [dbo].[Empleados] ([id])
GO
USE [master]
GO
ALTER DATABASE [VentasTP4] SET  READ_WRITE 
GO
