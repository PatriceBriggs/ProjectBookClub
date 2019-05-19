CREATE TABLE [dbo].[Books] (
    [BookId]         INT            IDENTITY (1, 1) NOT NULL,
    [GenreId]        INT            NOT NULL,
    [Title]          NVARCHAR (200) NOT NULL,
    [Author]         NVARCHAR (100) NULL,
    [DateRead]       DATETIME       NULL,
    [MainCharacters] NVARCHAR (500) NULL,
    [Notes]          NVARCHAR (500) NULL,
    [BookClubId]     INT            NULL,
    [GoodReadLink]   NVARCHAR (500) NULL,
    [Stars]          INT            NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([BookId] ASC),
    CONSTRAINT [FK_Books_BookClub] FOREIGN KEY ([BookClubId]) REFERENCES [dbo].[BookClubs] ([BookClubId]),
    CONSTRAINT [FK_Books_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([GenreId])
);





