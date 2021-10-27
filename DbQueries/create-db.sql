USE [master]
GO

/****** Object:  Database [CoolMoviesApp]    Script Date: 27/10/2021 09:43:36 ******/
CREATE DATABASE [CoolMoviesApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CoolMoviesApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CoolMoviesApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CoolMoviesApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\CoolMoviesApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CoolMoviesApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [CoolMoviesApp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET ARITHABORT OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [CoolMoviesApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [CoolMoviesApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET  DISABLE_BROKER 
GO

ALTER DATABASE [CoolMoviesApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [CoolMoviesApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [CoolMoviesApp] SET  MULTI_USER 
GO

ALTER DATABASE [CoolMoviesApp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [CoolMoviesApp] SET DB_CHAINING OFF 
GO

ALTER DATABASE [CoolMoviesApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [CoolMoviesApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [CoolMoviesApp] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [CoolMoviesApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [CoolMoviesApp] SET QUERY_STORE = OFF
GO

ALTER DATABASE [CoolMoviesApp] SET  READ_WRITE 
GO


