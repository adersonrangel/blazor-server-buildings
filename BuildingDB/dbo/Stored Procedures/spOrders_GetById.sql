CREATE PROCEDURE [dbo].[spOrders_GetById]
	@Id int
AS
BEGIN
	set nocount on;

	select [Id], [OrderName], [OrderDate], [FootId], [Quantity], [Total]
	from dbo.[Order]
	where Id = @Id;

END