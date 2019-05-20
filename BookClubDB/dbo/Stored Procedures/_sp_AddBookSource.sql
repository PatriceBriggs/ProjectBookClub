-- =============================================
-- Author:		BRIGP
-- Create date: 5/19/2018
-- Description:	Add Book Source
-- exec _sp_AddBookSource 'Reese Witherspoon''s Book Club Picks', 'https://www.readitforward.com/essay/article/reese-witherspoons-book-club/'
-- =============================================
CREATE PROCEDURE _sp_AddBookSource
	@bookSourceName nvarchar(100),
	@BookSourceLink nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	Insert Into BookSources
	(BookSourceName, BookSourceLink)
	Values
	(@bookSourceName, @BookSourceLink)

	Select * FROM BookSources
END