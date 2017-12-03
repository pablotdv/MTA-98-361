CREATE PROCEDURE GetCustomersFromFrance	
AS
	select * from Customers
	where Country = 'France'
RETURN
