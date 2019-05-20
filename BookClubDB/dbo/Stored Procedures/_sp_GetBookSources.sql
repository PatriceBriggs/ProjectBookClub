-- =============================================
-- Author:		BRIGP
-- Create date: 5/18/2019
-- Description:	Get list of book sources
-- =============================================
CREATE PROCEDURE _sp_GetBookSources 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT BookSourceId
		  ,BookSourceName
		  ,BookSourceLink
	FROM BookSources
END