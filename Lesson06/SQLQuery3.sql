USE [D:\DATABASE\NORTHWND.MDF]
GO

DECLARE	@return_value Int,
		@TotalSales money

EXEC	@return_value = [dbo].[GetCustomerSales]
		@CustomerId = N'ALFKI',
		@TotalSales = @TotalSales OUTPUT

SELECT	@TotalSales as N'@TotalSales'

SELECT	@return_value as 'Return Value'

GO
