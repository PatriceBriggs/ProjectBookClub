CREATE TABLE [dbo].[BookSources] (
    [BookSourceId]   INT            IDENTITY (1, 1) NOT NULL,
    [BookSourceName] NVARCHAR (100) NOT NULL,
    [BookSourceLink] NVARCHAR (200) NULL,
    CONSTRAINT [PK_BookSource] PRIMARY KEY CLUSTERED ([BookSourceId] ASC)
);

