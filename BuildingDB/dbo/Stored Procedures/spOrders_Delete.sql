CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id int
AS
BEGIN

	set nocount on;

	DELETE 
	FROM dbo.[Order]
	WHERE Id = @Id;
END