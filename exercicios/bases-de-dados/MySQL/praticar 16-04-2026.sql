# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar todos os clientes com o repetivo nome, cidade e país ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.ContactName AS 'Nome do Cliente', 
		customers.City AS 'Cidade do cliente', 
        customers.Country AS 'País do cliente'
        FROM customers;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar todos os empregados (first_name, last_name e birth_date) ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  CONCAT_WS(" ", employees.Firstname, employees.Country) AS 'Nome do empregado', 
		employees.BirthDate AS 'Data de nascimento' 
        FROM employees;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar os empregados que nasceram em 1963 ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  CONCAT_WS(" ", employees.Firstname, employees.Country) AS 'Nome do empregado', 
		employees.BirthDate AS 'Data de nascimento' 
        FROM employees
        WHERE employees.BirthDate Like '1963%';

# ::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar os produtos e as suas categorias ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		categories.CategoryName AS 'Nome da categoria'
		FROM products
			INNER JOIN categories ON categories.CategoryID = products.CategoryID;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar os produtos e o valor do em stock de cada um (qtd*stock) ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		FORMAT(products.UnitsInStock * products.UnitPrice, 2) AS 'Preço Total Stock'
        FROM products;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar o valor (SOMA) em stock de cada categoria ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  categories.CategoryName AS 'Nome da categoria',
		FORMAT(SUM(products.UnitsInStock * products.UnitPrice),2) AS 'Valor em stock'
        FROM categories
			INNER JOIN products ON products.CategoryID = categories.CategoryID
		GROUP BY categories.CategoryName;

# :::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Listar o valor de cada encomenda ::::: #
# :::::::::::::::::::::::::::::::::::::::::::: #

SELECT  `order details`.OrderID,
		ROUND((`order details`.UnitPrice * `order details`.Quantity),2) AS 'Valor de encomenda'
		FROM `order details`
		GROUP BY `order details`.OrderID
        ORDER BY `order details`.OrderID DESC;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Somar o valor de todas as encomendas de cada cliente ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.CompanyName AS 'Nome do cliente',
		ROUND(SUM(`order details`.UnitPrice * `order details`.Quantity),2) AS 'Valor de encomenda'
		FROM `order details`
			INNER JOIN orders ON orders.OrderID = `order details`.OrderID
            INNER JOIN customers ON customers.CustomerID = orders.CustomerID
		GROUP BY customers.CompanyName;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Valor total das encomendas no mês de Agosto de 1996 ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #	

SELECT  ROUND(SUM(`order details`.UnitPrice * `order details`.Quantity),2) AS 'Valor de encomenda'
		FROM `order details`
			INNER JOIN orders ON orders.OrderID = `order details`.OrderID
		WHERE orders.OrderDate BETWEEN '1996-08-01' AND '1996-08-31';
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: Valor total das encomendas no mês de Julho de 1996 ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #	

-- Opção1
SELECT  ROUND(SUM(`order details`.UnitPrice * `order details`.Quantity),2) AS 'Valor de encomenda'
		FROM `order details`
			INNER JOIN orders ON orders.OrderID = `order details`.OrderID
		WHERE orders.OrderDate BETWEEN '1996-07-01' AND '1996-07-31';

-- Opção2
SELECT  ROUND(SUM(`order details`.UnitPrice * `order details`.Quantity),2) AS 'Valor de encomenda'
		FROM `order details`
			INNER JOIN orders ON orders.OrderID = `order details`.OrderID
		WHERE MONTH(orders.OrderDate) = 7 AND YEAR(orders.OrderDate) = 1996;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #        
# ::::: Quantas (COUNT) encomendas foram expedidas por cada transitário ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  shippers.CompanyName AS 'Transitário',
		COUNT(orders.OrderID) AS 'Total de encomendas expedidas'
		FROM orders
			INNER JOIN shippers ON shippers.ShipperID = orders.ShipVia
		GROUP BY shippers.CompanyName;
