# ::::::::::::::::::::::::::::::::::::::: #
# ::::: 1 - Liste todos os clientes ::::: #
# ::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.Companyname AS 'Nomes dos Clientes' 
		FROM customers;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 2 - Liste o nome da empresa e o país de todos os clientes ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.Companyname AS 'Nomes da Empresa',
	    customers.Country AS 'País do Cliente'
		FROM customers;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 3 - Liste todos os produtos com o repetivo preço unitário ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS ' Nome do produto',
		ROUND(products.UnitPrice,2) AS 'Preço Unitário'
        FROM products;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 4 - Liste os Fornecedores localizados nos EUA ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  suppliers.CompanyName AS 'Fornecedor',
		suppliers.Country AS 'País do fornecedor'
        FROM suppliers
        WHERE suppliers.Country = 'USA';
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 5 - Liste o nome e cargo de todos os funcionários ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário',
		employees.Title AS 'Cargo do funcionário'
        FROM employees;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 6 - Liste os produtos com preço entre 10 e 50 ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		ROUND(products.UnitPrice,2) AS 'Preço Unitário'
        FROM products
        WHERE products.UnitPrice BETWEEN '10' AND '50';
        
# ::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 7 - Liste os clientes da Alemanha ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.CompanyName AS 'Nome do cliente',
		customers.Country AS 'País do cliente'
        FROM customers
        WHERE customers.Country = 'Germany';
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 8 - Liste os pedidos efetuados após 1 de janeiro de 1997 ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  orders.OrderID AS 'ID do pedido',
		orders.OrderDate AS 'Data de pedido efetuado'
		FROM orders
        WHERE orders.OrderDate BETWEEN '1997-01-01 00:00:00' AND now();
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 9 - Liste os produtos que estão fora de stock ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		products.UnitsInStock AS 'Quantidade em Stock'
        FROM products
        WHERE products.UnitsInStock = '0';
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 10 - Liste os funcionários contratados antes de 1994 ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário',
		employees.HireDate AS 'Data de contratação'
        FROM employees
        WHERE employees.HireDate BETWEEN '0000-00-00 00:00:00' AND '1993-12-31 23:59:59';
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 11 - Liste os produtos ordenados por preço unitário, do mais caro para o mais barato ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		ROUND(products.UnitPrice,2) AS 'Preço Unitário'
        FROM products
        ORDER BY products.UnitPrice DESC;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 12 - Liste os clientes ordenados por país e por nome da empresa ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

-- Ordenado por nome da empresa
SELECT  customers.CompanyName AS 'Nome do cliente',
		customers.Country AS 'País do cliente'
        FROM customers
        ORDER BY customers.CompanyName ASC;
 
-- Ordenado por país 
SELECT  customers.CompanyName AS 'Nome do cliente',
		customers.Country AS 'País do cliente'
        FROM customers
        ORDER BY customers.Country ASC;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 13 - Liste os pedidos ordenados por data do pedido ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

-- Ordenado do mais antigo para o mais recente
SELECT  orders.OrderID AS 'ID do pedido',
		orders.OrderDate AS 'Data de pedido efetuado'
        FROM orders
        ORDER BY orders.OrderDate ASC;
        
-- Ordenado do mais recente para o mais antigo
SELECT  orders.OrderID AS 'ID do pedido',
		orders.OrderDate AS 'Data de pedido efetuado'
        FROM orders
        ORDER BY orders.OrderDate ASC;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 14 - Liste os funcionários ordenados por data de nascimento ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

-- Ordenado do que nasceu primeiro para o ultimo a nascer
SELECT  CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário',
		employees.BirthDate AS 'Data de nascimento'
        FROM employees
        ORDER BY employees.BirthDate ASC;
        
-- Ordenado do ultimo a nascer para o primeiro a nascer
SELECT  CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário',
		employees.BirthDate AS 'Data de nascimento'
        FROM employees
        ORDER BY employees.BirthDate ASC;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 15 - Liste os fornecedores ordenados alfabeticamente pelo nome da empresa ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  suppliers.CompanyName AS 'Fornecedor'
        FROM suppliers
        ORDER BY suppliers.CompanyName ASC;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 16 - Indique quantos clientes existem na base de dados ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  COUNT(customers.CustomerID) AS 'Nº de clientes'
		FROM customers;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 17 - Calcule o preço médio dos produtos ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  AVG(products.UnitPrice) AS 'Preço médio dos Produtos'
		FROM products;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 18 - Indique o preço máximo dos produtos ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  MAX(products.UnitPrice) AS 'Preço máximo dos Produtos'
		FROM products;
        
# :::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 19 - Indique quantos pedidos existem ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  COUNT(orders.OrderID) AS 'Nº de pedidos'
		FROM orders;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 20 - Calcule o total de unidades em stock ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  SUM(products.UnitsInStock) AS 'Total de unidades em stock'
		FROM products;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 21 - Indique o número de clientes por país ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  COUNT(customers.CustomerID) AS 'Total de clientes',
		customers.Country AS 'País'
        FROM customers
        GROUP BY customers.Country;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 22 - Indique o número de produtos por categoria ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  COUNT(products.ProductID) AS 'Total de produtos',
		categories.categoryName AS 'Nome da categoria'
        FROM products
			INNER JOIN categories ON categories.CategoryID = products.CategoryID
		GROUP BY categories.categoryName;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 23 - Indique o número de pedidos por cliente ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT	customers.CompanyName AS 'Nome do cliente',
        COUNT(orders.OrderID) AS 'Total de pedidos'
        FROM orders
			INNER JOIN customers ON customers.CustomerID = orders.CustomerID
		GROUP BY customers.CompanyName;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 24 - Calcule o preço médio dos produtos por categoria ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  categories.categoryName AS 'Nome da categoria',
		AVG(products.UnitPrice) AS 'Média do preço dos produtos'
        FROM products
			INNER JOIN categories ON categories.CategoryID = products.CategoryID
		GROUP BY categories.categoryName;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 25 - Calcule o total de pedidos tratados por funcionário ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário',
		COUNT(orders.OrderID) AS 'Total de pedidos tratados'
        FROM employees
			INNER JOIN orders ON orders.EmployeeID = employees.EmployeeID
		GROUP BY employees.FirstName;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 26 - Liste cada pedido com o nome do cliente ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.CompanyName AS 'Nome do cliente',
		orders.OrderID AS 'ID do pedido'
        FROM customers
			INNER JOIN orders ON orders.CustomerID = customers.CustomerID;
            
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 27 - Liste cada produto com o nome da sua categoria ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto',
		categories.CategoryName AS 'Categoria'
        FROM products
			INNER JOIN categories ON products.CategoryID = categories.CategoryID;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 28 - Liste cada pedido com o nome do funcionário responsável ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  orders.OrderID AS 'ID do pedido',
		CONCAT_WS(" ", employees.FirstName, employees.LastName) AS 'Nome do funcionário'
        FROM orders
			INNER JOIN employees ON employees.EmployeeID = orders.EmployeeID;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 29 - Liste cada produto com o nome do fornecedor ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  suppliers.CompanyName AS 'Nome do fornecedor',
		products.ProductName AS 'Nome do produto'
        FROM suppliers
			INNER JOIN products ON products.SupplierID = suppliers.SupplierID;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 30 - Liste os detalhes dos pedidos com o nome do produto ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  orders.OrderID AS 'ID do pedido',
		products.ProductName AS 'Nome do produto',
		`order details`.UnitPrice AS 'Preço unitário',
		`order details`.Quantity AS 'Quantidade'
        FROM products
			INNER JOIN `order details` ON `order details`.ProductID = products.ProductID
            INNER JOIN orders ON orders.OrderID = `order details`.OrderID;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 31 - Liste os clientes cujo nome da empresa começa por 'A' ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.CompanyName AS 'Nome da empresa'
		FROM customers
        WHERE customers.CompanyName LIKE 'A%';
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 32 - Liste os clientes que não têm região preenchida (NULL) ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  customers.CompanyName AS 'Nome da empresa',
		customers.Region AS 'Região'
        FROM customers
        WHERE customers.Region IS NULL;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 33 - Liste os pedidos efetuados no ano de 1997 ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  orders.OrderID AS 'ID do pedido',
		orders.OrderDate AS 'Data do pedido'
		FROM orders
        WHERE orders.OrderDate BETWEEN '1997-01-01 00:00:00' AND '1997-12-31 23:59:59' ;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 34 - Liste os produtos cujo nome contém a palavra chef ::::: #
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  products.ProductName AS 'Nome do produto'
		FROM products
        WHERE products.ProductName LIKE '%Chef%';
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #
# ::::: 35 - Liste os fornecedores que têm fax preenchido ::::: #
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: #

SELECT  suppliers.CompanyName AS 'Nome do fornecedor',
		suppliers.Fax 'Fax do fornecedor'
        FROM suppliers
        WHERE suppliers.Fax IS NULL;