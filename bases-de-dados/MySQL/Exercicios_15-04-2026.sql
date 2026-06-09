# :::::::::::::::::::::::::::::
# ::::: STORED PROCEDURES :::::
# :::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE lista_atores()
BEGIN
	SELECT first_name, last_name FROM actor;
END $$
DELIMITER ;

CALL lista_atores();

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar procedure para listar os filmes que contenham :::::
# ::::: um determinado caracter ou conjunto de caracteres   :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE procura_filmes(IN texto VARCHAR(50))
BEGIN
	SELECT title FROM film WHERE title LIKE CONCAT('%',texto,'%');
END $$
DELIMITER ;

CALL procura_filmes('ACA');

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar uma procedure que lista um filme pelo seu codigo :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE Procura_FilmeCodigo(IN codigo INT(10))
BEGIN 
	SELECT film_id, title FROM film WHERE film_id = codigo;
END $$
DELIMiTER ;

CALL Procura_FilmeCodigo(11);

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar procedure que lista filmes de uma determinada categoria :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE procura_filme_categoria(IN categoria INT(10))
BEGIN
	SELECT film.title AS 'Nome do filme', category.name AS 'Categoria' FROM film
		INNER JOIN film_category ON film.film_id = film_category.film_id
        INNER JOIN category ON category.category_id = film_category.category_id
        WHERE film_category.category_id = categoria;
END $$
DELIMITER ;

CALL procura_filme_categoria(2);

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar procedure que lista filmes com duração entre x e y :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE procura_filme_tempo(IN x INT(10), y INT(10))
BEGIN
	SELECT film.title AS 'Nome do filme', film.length AS 'Duração' FROM film
		WHERE film.length BETWEEN x AND y;
END $$
DELIMITER ;

CALL procura_filme_tempo(50,150);

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar procedure que diga o nº de filmes com duração entre x e y :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE conta_numero_filme_tempo(IN x INT(10), y INT(10))
BEGIN
	SELECT COUNT(film.length) AS 'Quantidade de Filmes' FROM film
		WHERE film.length BETWEEN x AND y;
END $$
DELIMITER ;

CALL conta_numero_filme_tempo(100,120);

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# ::::: Criar procedure que mostre o nº de clientes de uma determinada cidade :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

DELIMITER $$
CREATE PROCEDURE conta_cidade_cliente(IN cidade VARCHAR(50))
BEGIN
	SELECT city.city AS 'Cidade', COUNT(customer.customer_id) AS 'Nº de Clientes' FROM customer
		INNER JOIN address ON address.address_id = customer.address_id
        INNER JOIN city ON city.city_id = address.city_id
			GROUP BY city.city_id;
END $$
DELIMITER ;

CALL conta_cidade_cliente ('cidade');
