USE [master]
GO
/****** Object:  Database [BoardingMeals]    Script Date: 7/19/2024 4:04:06 PM ******/
CREATE DATABASE [BoardingMeals]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BoardingMeals', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BoardingMeals.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BoardingMeals_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BoardingMeals_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BoardingMeals] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BoardingMeals].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BoardingMeals] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BoardingMeals] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BoardingMeals] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BoardingMeals] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BoardingMeals] SET ARITHABORT OFF 
GO
ALTER DATABASE [BoardingMeals] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BoardingMeals] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BoardingMeals] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BoardingMeals] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BoardingMeals] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BoardingMeals] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BoardingMeals] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BoardingMeals] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BoardingMeals] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BoardingMeals] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BoardingMeals] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BoardingMeals] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BoardingMeals] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BoardingMeals] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BoardingMeals] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BoardingMeals] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BoardingMeals] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BoardingMeals] SET RECOVERY FULL 
GO
ALTER DATABASE [BoardingMeals] SET  MULTI_USER 
GO
ALTER DATABASE [BoardingMeals] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BoardingMeals] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BoardingMeals] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BoardingMeals] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BoardingMeals] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BoardingMeals] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BoardingMeals', N'ON'
GO
ALTER DATABASE [BoardingMeals] SET QUERY_STORE = ON
GO
ALTER DATABASE [BoardingMeals] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BoardingMeals]
GO
/****** Object:  Table [dbo].[Class]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Meal]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChefId] [int] NOT NULL,
	[Day] [date] NOT NULL,
	[Slot] [int] NOT NULL,
 CONSTRAINT [PK_Meal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MealFood]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MealFood](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FoodId] [int] NOT NULL,
	[MeadId] [int] NOT NULL,
 CONSTRAINT [PK_MealFood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MealId] [int] NOT NULL,
	[Time] [datetime] NOT NULL,
	[Content] [text] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClassId] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Dob] [date] NOT NULL,
	[MealLevel] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/19/2024 4:04:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Class] ON 

INSERT [dbo].[Class] ([Id], [Name]) VALUES (1, N'1A1')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (2, N'1B')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (3, N'1D')
INSERT [dbo].[Class] ([Id], [Name]) VALUES (4, N'1C')
SET IDENTITY_INSERT [dbo].[Class] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (1, N'Cơm Trắng', N'Chỉ có cơm trắng')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (2, N'Cơm Rang Huệ Ỉn', N'Cơm Rang Huệ Ỉn')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (3, N'Cơm Tún', N'Chỉ có cơm Tún')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (4, N'Cơm Ngon', N'Quá là ngon ')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (5, N'Cơm rất ngon', N'Rất là ngon ')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (6, N'Bún bò huế', N'Rất nhiều topping')
INSERT [dbo].[Food] ([Id], [Name], [Description]) VALUES (7, N'Bún đậu mắm tôm', N'Ăn cũng được ')
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Meal] ON 

INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (21, 2, CAST(N'2024-07-12' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (24, 2, CAST(N'2024-07-12' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (25, 2, CAST(N'2024-07-12' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (26, 2, CAST(N'2024-07-16' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (27, 2, CAST(N'2024-07-18' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (28, 2, CAST(N'2024-07-15' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (29, 2, CAST(N'2024-07-15' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (30, 2, CAST(N'2024-07-18' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (31, 2, CAST(N'2024-07-14' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (32, 5, CAST(N'2024-07-17' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (33, 5, CAST(N'2024-07-17' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (34, 5, CAST(N'2024-07-19' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (35, 5, CAST(N'2024-07-19' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (36, 5, CAST(N'2024-07-19' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (37, 5, CAST(N'2024-07-17' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (38, 5, CAST(N'2024-07-16' AS Date), 1)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (39, 5, CAST(N'2024-07-16' AS Date), 3)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (40, 5, CAST(N'2024-07-15' AS Date), 2)
INSERT [dbo].[Meal] ([Id], [ChefId], [Day], [Slot]) VALUES (41, 5, CAST(N'2024-07-13' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Meal] OFF
GO
SET IDENTITY_INSERT [dbo].[MealFood] ON 

INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (54, 3, 21)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (55, 6, 21)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (57, 4, 25)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (58, 7, 25)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (59, 4, 24)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (60, 1, 26)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (62, 2, 27)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (63, 6, 27)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (65, 7, 29)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (67, 1, 31)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (68, 1, 30)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (86, 7, 33)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (87, 1, 34)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (88, 1, 35)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (89, 1, 36)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (90, 4, 37)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (91, 7, 38)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (92, 6, 39)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (93, 7, 32)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (94, 3, 28)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (95, 3, 40)
INSERT [dbo].[MealFood] ([Id], [FoodId], [MeadId]) VALUES (96, 3, 41)
SET IDENTITY_INSERT [dbo].[MealFood] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (2, N'teacher')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (3, N'parent')
INSERT [dbo].[Role] ([Id], [Name]) VALUES (4, N'chef')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (1, 1, 4, N'Nguyen Van An ', CAST(N'2020-01-01' AS Date), 3)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (2, 2, 6, N'Nguyen Thi Binh', CAST(N'2017-01-01' AS Date), 3)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (3, 2, 6, N'Nguyen Van Cuong ', CAST(N'2020-01-01' AS Date), 2)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (4, 4, 6, N'Dinh Thanh Muong', CAST(N'2011-01-04' AS Date), 1)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (5, 4, 6, N'Nguyễn Thành Nam', CAST(N'2020-02-14' AS Date), 1)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (6, 3, 8, N'Hoang hoa tham', CAST(N'2020-06-11' AS Date), 2)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (7, 2, 6, N'Truong Gia Binh', CAST(N'2022-11-10' AS Date), 3)
INSERT [dbo].[Student] ([Id], [ClassId], [ParentId], [FullName], [Dob], [MealLevel]) VALUES (8, 1, 8, N'Trinh Gia BUong', CAST(N'2022-11-11' AS Date), 3)
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (2, 1, N'Ad Min', N'admin', N'admin', N'12345')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (3, 2, N'Tít Chờ', N'teacher', N'teacher', N'23456')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (4, 3, N'Pe Ran', N'parent', N'parent', N'34567')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (5, 4, N'Chep ', N'chef', N'chef', N'45678')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (6, 3, N'Pa ren 2 update ', N'parent2 update', N'12123', N'013333333')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (7, 4, N'To Et Tet', N'test', N'1234', N'123456')
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [UserName], [Password], [Phone]) VALUES (8, 3, N'amazing goodchop', N'parent2', N'parent2', N'01234')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Meal]  WITH CHECK ADD  CONSTRAINT [FK_Meal_User] FOREIGN KEY([ChefId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Meal] CHECK CONSTRAINT [FK_Meal_User]
GO
ALTER TABLE [dbo].[MealFood]  WITH CHECK ADD  CONSTRAINT [FK_MealFood_Food] FOREIGN KEY([FoodId])
REFERENCES [dbo].[Food] ([Id])
GO
ALTER TABLE [dbo].[MealFood] CHECK CONSTRAINT [FK_MealFood_Food]
GO
ALTER TABLE [dbo].[MealFood]  WITH CHECK ADD  CONSTRAINT [FK_MealFood_Meal] FOREIGN KEY([MeadId])
REFERENCES [dbo].[Meal] ([Id])
GO
ALTER TABLE [dbo].[MealFood] CHECK CONSTRAINT [FK_MealFood_Meal]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Meal] FOREIGN KEY([MealId])
REFERENCES [dbo].[Meal] ([Id])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Meal]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_User]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Class] FOREIGN KEY([ClassId])
REFERENCES [dbo].[Class] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Class]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_User] FOREIGN KEY([ParentId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [BoardingMeals] SET  READ_WRITE 
GO
