CREATE TABLE [dbo].[BookClubs] (
    [BookClubId]   INT            IDENTITY (1, 1) NOT NULL,
    [BookClubName] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_BookClub] PRIMARY KEY CLUSTERED ([BookClubId] ASC)
);

