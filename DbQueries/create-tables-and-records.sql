USE [CoolMoviesApp]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 27/10/2021 09:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 27/10/2021 09:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieActors]    Script Date: 27/10/2021 09:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieActors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MovieId] [bigint] NOT NULL,
	[ActorId] [int] NOT NULL,
 CONSTRAINT [PK_MoviesActors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieGenres]    Script Date: 27/10/2021 09:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieGenres](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MovieId] [bigint] NOT NULL,
	[GenreId] [int] NOT NULL,
 CONSTRAINT [PK_MoviesGenres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 27/10/2021 09:42:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (1, N'Ryan Reynolds')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (2, N'Silvester Stallone')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (3, N'Emma Watson')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (4, N'Emma Stone')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (5, N'Emma Roberts')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (6, N'Chris Evans')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (7, N'Scarlet Johansen')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (8, N'Amy Adams')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (9, N'Josh Brolyn')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (10, N'Emily Blunt')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (11, N'Benicio del Toro')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (12, N'Tom Holland')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (13, N'Mark Whalberg')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (14, N'Gal Gadot')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (15, N'Dwayne Johnson')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (16, N'Robert Pattinson')
GO
INSERT [dbo].[Actors] ([Id], [Name]) VALUES (17, N'Naomi Watts')
GO
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (1, N'Action')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (2, N'Suspense')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (3, N'Thriller')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (4, N'Horror')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (5, N'Science Fiction')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (6, N'Drama')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (7, N'Documentary')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (8, N'Crime')
GO
INSERT [dbo].[Genres] ([Id], [Name]) VALUES (9, N'Comedy')
GO
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieActors] ON 
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (1, 1, 10)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (2, 2, 10)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (3, 2, 9)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (4, 2, 11)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (5, 3, 12)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (6, 3, 17)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (7, 4, 1)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (8, 4, 14)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (9, 4, 15)
GO
INSERT [dbo].[MovieActors] ([Id], [MovieId], [ActorId]) VALUES (10, 5, 16)
GO
SET IDENTITY_INSERT [dbo].[MovieActors] OFF
GO
SET IDENTITY_INSERT [dbo].[MovieGenres] ON 
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (1, 1, 2)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (2, 1, 4)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (3, 1, 5)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (4, 2, 1)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (5, 2, 3)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (6, 2, 8)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (7, 3, 2)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (8, 3, 6)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (9, 4, 1)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (10, 4, 8)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (11, 4, 9)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (12, 5, 1)
GO
INSERT [dbo].[MovieGenres] ([Id], [MovieId], [GenreId]) VALUES (13, 5, 8)
GO
SET IDENTITY_INSERT [dbo].[MovieGenres] OFF
GO
SET IDENTITY_INSERT [dbo].[Movies] ON 
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year]) VALUES (1, N'A Quiet Place', 2018)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year]) VALUES (2, N'Sicario', 2019)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year]) VALUES (3, N'The Impossible', 2013)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year]) VALUES (4, N'Red Notice', 2021)
GO
INSERT [dbo].[Movies] ([Id], [Title], [Year]) VALUES (5, N'The Batman', 2021)
GO
SET IDENTITY_INSERT [dbo].[Movies] OFF
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MoviesActors_Actors] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MoviesActors_Actors]
GO
ALTER TABLE [dbo].[MovieActors]  WITH CHECK ADD  CONSTRAINT [FK_MoviesActors_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieActors] CHECK CONSTRAINT [FK_MoviesActors_Movies]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_MoviesGenres_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_MoviesGenres_Genres]
GO
ALTER TABLE [dbo].[MovieGenres]  WITH CHECK ADD  CONSTRAINT [FK_MoviesGenres_Movies] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
GO
ALTER TABLE [dbo].[MovieGenres] CHECK CONSTRAINT [FK_MoviesGenres_Movies]
GO
