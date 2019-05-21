-- =============================================
-- Author:		BRIGP
-- Create date: 5/20/2019
-- Description:	get alphabetical list of genres
-- =============================================
CREATE PROCEDURE _sp_GetGenres

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT * FROM Genres
	Order By GenreDesc ASC
END