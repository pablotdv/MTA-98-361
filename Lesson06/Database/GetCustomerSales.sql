ALTER PROCEDURE [dbo].[GetCustomerSales]
	@CustomerId char(5),
	@TotalSales money OUTPUT
AS
	SELECT @TotalSales = sum(Quantity * UnitPrice)
	from (Customers INNER JOIN Orders 
		on Customers.CustomerID = Orders.CustomerID)
		inner join [Order Details] on Orders.OrderID = [Order Details].OrderID
	where Customers.CustomerID = @CustomerId
RETURN
