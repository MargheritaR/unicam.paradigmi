USE [master]
GO
/****** Object:  Database [Paradigmi]    Script Date: 24/04/2024 11:11:57 ******/
CREATE DATABASE [Paradigmi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Paradigmi', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Paradigmi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Paradigmi_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Paradigmi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Paradigmi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Paradigmi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Paradigmi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Paradigmi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Paradigmi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Paradigmi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Paradigmi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Paradigmi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Paradigmi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Paradigmi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Paradigmi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Paradigmi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Paradigmi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Paradigmi] SET RECOVERY FULL 
GO
ALTER DATABASE [Paradigmi] SET  MULTI_USER 
GO
ALTER DATABASE [Paradigmi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Paradigmi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Paradigmi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Paradigmi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Paradigmi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Paradigmi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Paradigmi', N'ON'
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE = ON
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Paradigmi]
GO
/****** Object:  User [AdParadigmi]    Script Date: 24/04/2024 11:11:57 ******/
CREATE USER [AdParadigmi] FOR LOGIN [AdParadigmi] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Admin]    Script Date: 24/04/2024 11:11:57 ******/
CREATE USER [Admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AdParadigmi]
GO
ALTER ROLE [db_owner] ADD MEMBER [Admin]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 24/04/2024 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[NomeCategoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categorie_1] PRIMARY KEY CLUSTERED 
(
	[NomeCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libri]    Script Date: 24/04/2024 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libri](
	[ISBN] [varchar](50) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Autore] [varchar](100) NOT NULL,
	[Editore] [varchar](50) NOT NULL,
	[DatadiPubblicazione] [date] NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Libro] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 24/04/2024 11:11:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[Nome] [varchar](50) NOT NULL,
	[Cognome] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[IdUtente] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Utente] PRIMARY KEY CLUSTERED 
(
	[IdUtente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Libri]  WITH CHECK ADD  CONSTRAINT [FK_Libri_Libri] FOREIGN KEY([Categoria])
REFERENCES [dbo].[Categorie] ([NomeCategoria])
GO
ALTER TABLE [dbo].[Libri] CHECK CONSTRAINT [FK_Libri_Libri]
GO
USE [master]
GO
ALTER DATABASE [Paradigmi] SET  READ_WRITE 
GO
