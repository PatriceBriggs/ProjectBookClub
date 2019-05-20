-- =============================================
-- Author:		BRIGP
-- Create date: 5/19/2019
-- Description:	Edit a book
-- exec _sp_Editbook ...
-- =============================================
CREATE PROCEDURE [dbo].[_sp_EditBook] 
	@bookId int,
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

	Update Books
	Set GenreId = @genreId,
	    Title = @title, 
	    Author = @author, 
		DateRead = @DateRead, 
		MainCharacters = @mainCharacters, 
		Notes = @notes, 
		BookClubId = @bookClubId,
		GoodReadLink = @goodReadLink, 
		Stars = @stars 
	 Where bookid = @bookId


END