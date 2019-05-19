CREATE TABLE [dbo].[Genres] (
    [GenreId]   INT           IDENTITY (1, 1) NOT NULL,
    [GenreDesc] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED ([GenreId] ASC)
);

