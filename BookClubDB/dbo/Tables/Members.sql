CREATE TABLE [dbo].[Members] (
    [MemberId]   INT            IDENTITY (1, 1) NOT NULL,
    [BookClubId] INT            NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Email]      NVARCHAR (100) NULL,
    [CellNumber] NVARCHAR (20)  NULL,
    [HomeNumber] NVARCHAR (20)  NULL,
    CONSTRAINT [PK_Memebers] PRIMARY KEY CLUSTERED ([MemberId] ASC),
    CONSTRAINT [FK_Members_BookClubs] FOREIGN KEY ([BookClubId]) REFERENCES [dbo].[BookClubs] ([BookClubId])
);

