-- =============================================
-- Author:		BRIGP
-- Create date: 5/11/2018
-- Description:	GEt One Book using bookId
-- exec _sp_GetOneBook 3
-- =============================================
CREATE PROCEDURE [dbo].[_sp_GetOneBook] 
	@bookId int
AS
BEGIN

	SET NOCOUNT ON;

	Select bookId
		  ,b.BookClubId 
		  ,b.GenreId 
		  ,Title
		  ,Author
		  ,DateRead
		  ,MainCharacters
		  ,Notes
		  ,bc.BookClubName
		  ,GoodReadLink
		  ,Stars
		  ,g.GenreDesc

		  From Books b
		  Inner Join BookClubs bc on b.BookClubid = bc.BookClubId
		  Inner Join Genres g on b.GenreId = g.GenreId
		  Where b.bookId = @bookId
		  

END