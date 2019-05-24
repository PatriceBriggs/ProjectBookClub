-- =============================================
-- Author:		BRIGP
-- Create date: 5/11/2018
-- Description:	GEt List of books for Excel
-- exec _sp_GetAllBooksExcel
-- =============================================
CREATE PROCEDURE [dbo].[_sp_GetAllBooksExcel] 
	
AS
BEGIN

	SET NOCOUNT ON;

	Select Title
		  ,Author
		  ,DateRead AS [Date Read]
		  ,MainCharacters AS [Main Characters]
		  ,Notes
		  ,bc.BookClubName AS [Book Club]
		  ,GoodReadLink AS [Book Information]
		  ,Stars
		  ,g.GenreDesc AS [Genre]

		  From Books b
		  Inner Join BookClubs bc on b.BookClubid = bc.BookClubId
		  Inner Join Genres g on b.GenreId = g.GenreId

		  Order by bc.BookclubName asc, DateRead Asc
		  

END