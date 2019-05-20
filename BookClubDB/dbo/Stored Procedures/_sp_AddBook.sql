-- =============================================
-- Author:		BRIGP
-- Create date: 5/19/2019
-- Description:	Add New Book
-- exec _sp_AddBook ...
-- =============================================
CREATE PROCEDURE _sp_AddBook

    @genreId nvarchar(20),
    @title nvarchar(200),
    @author nvarchar(100),
    @dateRead DateTime,
    @mainCharacters nvarchar(500),
    @notes nvarchar(500),
    @bookClubId int,
    @goodReadLink nvarchar(500),
    @stars int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

Insert Into Books
(GenreId, Title, Author, DateREad, MainCharacters, Notes, BookClubId, GoodReadLink, Stars)
Values
(@genreId, @title, @author, @dateRead, @mainCharacters, @notes, @bookClubId,  @goodReadLink, @stars)


END