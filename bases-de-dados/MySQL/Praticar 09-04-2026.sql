# ::::::::::::::::::::::::::::::::::::
# :::::  Listar todos os filmes  :::::
# ::::::::::::::::::::::::::::::::::::

SELECT * FROM film;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Lista apenas film_id, title, release_year de film  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT film_id, title, release_year FROM film;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar todos os filmes que começam por Z  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM film WHERE title LIKE 'Z%';

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar todos os filmes com film_id maior que 500  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT * FROM film WHERE film_id > 500;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos filmes temos com o rental_duration de 3 dias  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT rental_duration, COUNT(*) FROM film WHERE rental_duration = 3;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos filmes temos agrupados por rental_duration  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT rental_duration, COUNT(*) FROM film GROUP BY rental_duration;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos filmes temos agrupados por rental_duration  ::::: 
# :::::  ordenados por ordem decrescente de nº de filmes     :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT rental_duration, COUNT(*) FROM film GROUP BY rental_duration 
		ORDER BY COUNT(*);
        
# ::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os filmes e a sua linguagem  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::

SELECT film.title, language.name FROM film JOIN language
		ON film.language_id = language.language_id;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar as cidades e os respetivos países  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT city.city, country.country FROM city JOIN country
		ON city.country_id = country.country_id;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o número de cidades de cada país  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(city.city), country.country FROM city JOIN country
		ON city.country_id = country.country_id GROUP BY country.country;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o número de cidades de cada país ordenado  ::::: 
# :::::  por ordem descendente de nº de países             :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(city.city), country.country 
		FROM city JOIN country
		ON city.country_id = country.country_id 
        GROUP BY country.country
        ORDER BY COUNT(city.city) DESC;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o país com o maior nº de cidades  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(city.city), country.country FROM city JOIN country
		ON city.country_id = country.country_id GROUP BY country.country
        ORDER BY COUNT(city.city) DESC LIMIT 1;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome do cliente e o montante pago por cada um  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT customer.first_name, customer.last_name, SUM(payment.amount) 
		FROM customer JOIN payment
        ON customer.customer_id = payment.customer_id
        GROUP BY customer.customer_id;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os filmes e as suas categorias  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT film.title, category.name FROM film 
		INNER JOIN film_category ON film.film_id = film_category.film_id
        INNER JOIN category ON film_category.category_id = category.category_id;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome e sobrenome do cliente e a cidade onde mora  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT CONCAT_WS(" ",customer.first_name, customer.last_name), city.city FROM customer
		INNER JOIN address ON address.address_id = customer.address_id
        INNER JOIN city ON address.city_id = city.city_id;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome do filme e os respetivos atores  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT film.title, CONCAT_WS(" ", actor.first_name, actor.last_name) AS "Nome do ator" FROM film
		INNER JOIN film_actor ON film_actor.film_id = film.film_id
        INNER JOIN actor ON actor.actor_id = film_actor.actor_id
        ORDER BY film.title;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome do filme e os respetivos atores numa só linha  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT film.title, GROUP_CONCAT(CONCAT_WS(" ",actor.first_name, actor.last_name) SEPARATOR " || ")
		AS "Nome dos atores"  FROM film
		INNER JOIN film_actor ON film_actor.film_id = film.film_id
        INNER JOIN actor ON actor.actor_id = film_actor.actor_id
        GROUP BY film.title;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome do ator e os respetivos filmes numa só linha  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ", actor.first_name, actor.last_name) AS "Nome do ator", 
		GROUP_CONCAT((film.title) SEPARATOR " || ") AS "Nomes dos filmes"
		FROM film
		INNER JOIN film_actor ON film_actor.film_id = film.film_id
        INNER JOIN actor ON actor.actor_id = film_actor.actor_id
        GROUP BY CONCAT_WS(" ", actor.first_name, actor.last_name);
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar todos os atores com o first name Helen  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT actor.first_name AS "Nome do ator", actor.last_name AS "Sobrenome"
		FROM actor WHERE actor.first_name = "Helen";
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar os sobrenomes distintos dos atores  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT DISTINCT(actor.last_name) AS "Sobrenome Distinto" FROM actor;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos sobrenomes distintos temos?  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::

SELECT Count(DISTINCT(actor.last_name)) AS "Sobrenomes Distintos" FROM actor;

# ::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quais sobrenomes aparecem uma vez?  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::

SELECT actor.last_name AS "Sobrenome",
		COUNT(actor.last_name) AS "Contagem de sobrenomes"
		FROM actor
        GROUP BY actor.last_name 
        HAVING COUNT(actor.last_name) = 1;
        
# ::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos sobrenomes aparecem uma vez?  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT COUNT(*) AS "Contagem dos sobrenomes" FROM (
	SELECT actor.last_name AS "Sobrenome",
			COUNT(actor.last_name) AS "Contagem de sobrenomes"
			FROM actor
			GROUP BY actor.last_name 
			HAVING COUNT(actor.last_name) = 1
) AS subquery;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Qual a duração média de todos os filmes (length)  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT AVG(film.length) AS "Média de duração" FROM film;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Qual a duração média dos filmes por categoria (length)  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT category.name AS "Categoria de filme",
		ROUND(AVG(film.length), 2) AS "Média de duração" 
			FROM film
			INNER JOIN film_category ON film_category.film_id = film.film_id
			INNER JOIN category ON category.category_id = film_category.category_id
			GROUP BY category.name;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nome e sobrenome dos clientes, a cidade e o país  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ",customer.first_name , customer.last_name) AS "Nome do Cliente", 
        city.city AS "Cidade do Cliente", 
        country.country AS "País do Cliente"
			FROM customer
			INNER JOIN address ON customer.address_id = address.address_id
			INNER JOIN city ON address.city_id = city.city_id
			INNER JOIN country ON city.country_id = country.country_id;
        
# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quanto é que faturei por cliente  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ",customer.first_name , customer.last_name) AS "Nome do Cliente",
        SUM(payment.amount) AS "Valor total faturado"
			FROM customer
            INNER JOIN payment ON payment.customer_id = customer.customer_id
            GROUP BY customer.customer_id;
            
# ::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos exemplares tenho de cada filme  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  film.title AS "Nome do filme", 
		Count(inventory.inventory_id) AS "Exemplares"
			FROM film
			INNER JOIN inventory ON inventory.film_id = film.film_id
			GROUP BY film.film_id;
            
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos exemplares tenho de cada filme em cada loja  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  film.title AS "Nome do filme", 
		Count(inventory.inventory_id) AS "Exemplares",
        store.store_id AS "Loja"
			FROM film
			INNER JOIN inventory ON inventory.film_id = film.film_id
            INNER JOIN store ON inventory.store_id = store.store_id
			GROUP BY film.film_id, inventory.store_id;
            
# ::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos faturou cada empregado da loja  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ", staff.first_name, staff.last_name) AS "Empregado",
		SUM(payment.amount) AS "Faturação"
			FROM staff
			INNER JOIN payment ON payment.staff_id = staff.staff_id
			GROUP BY staff.staff_id;
        
# :::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Quantos aluguers fez cada funcionario  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ", staff.first_name, staff.last_name) AS "Empregado",
		COUNT(rental.rental_id) AS "Nº de aluguers"
			FROM staff
			INNER JOIN rental ON rental.staff_id = staff.staff_id
			GROUP BY staff.staff_id;
            
# ::::::::::::::::::::::::::::::::::::::::::
# :::::  Quanto é que faturei por mês  :::::
# ::::::::::::::::::::::::::::::::::::::::::

SET lc_time_names = 'pt_PT';
SELECT  DATE_FORMAT(payment.payment_date, '%M') AS "Mês",
		DATE_FORMAT(payment.payment_date, '%Y') AS "Ano",
		SUM(payment.amount) AS "Faturação"
			FROM payment
            GROUP BY YEAR(payment.payment_date), MONTH(payment.payment_date);
            
# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o nº de aluguers por ator  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ",actor.first_name, actor.last_name) AS 'Nome do ator',
		COUNT(rental.rental_id) AS 'Nº de aluguers'
			FROM actor
			INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
			INNER JOIN film ON film.film_id = film_actor.film_id
			INNER JOIN inventory ON inventory.film_id = film.film_id
			INNER JOIN rental ON rental.inventory_id = inventory.inventory_id
			GROUP BY actor.actor_id;
		
# ::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o ator mais alugado  :::::
# ::::::::::::::::::::::::::::::::::::::::

SELECT  CONCAT_WS(" ",actor.first_name, actor.last_name) AS 'Nome do ator',
		COUNT(rental.rental_id) AS 'Nº de aluguers'
			FROM actor
			INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
			INNER JOIN film ON film.film_id = film_actor.film_id
			INNER JOIN inventory ON inventory.film_id = film.film_id
			INNER JOIN rental ON rental.inventory_id = inventory.inventory_id
			GROUP BY actor.actor_id 
            ORDER BY COUNT(rental.rental_id) DESC LIMIT 1;

# :::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar a categoria mais alugada  :::::
# :::::::::::::::::::::::::::::::::::::::::::::

SELECT  category.name AS 'Nome da categoria',
		COUNT(rental.rental_id) AS 'Nº de aluguers'
			FROM film_category
			INNER JOIN film ON film.film_id = film_category.film_id
            INNER JOIN category ON category.category_id = film_category.category_id
			INNER JOIN inventory ON inventory.film_id = film.film_id
			INNER JOIN rental ON rental.inventory_id = inventory.inventory_id
			GROUP BY film_category.category_id
            ORDER BY COUNT(film_category.category_id) ASC LIMIT 1;
            