-- =============================================
-- Author:		BRIGP
-- Create date: 5/11/2018
-- Description:	GEt List of books
-- =============================================
CREATE PROCEDURE _sp_GetAllBooks 
	
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
		  

END