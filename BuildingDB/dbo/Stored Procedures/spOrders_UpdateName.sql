CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@OrderName nvarchar(50),
	@Id int
AS
BEGIN
	set nocount on;

	update dbo.[Order]
	set OrderName = @OrderName
	where Id = @Id;
END
