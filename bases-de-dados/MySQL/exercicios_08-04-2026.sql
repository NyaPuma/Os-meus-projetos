SELECT * FROM sakila.actor;

# :::::::::::::::::::::::::
# :::::  CHAR LENGHT  :::::
# :::::::::::::::::::::::::

SELECT first_name, CHAR_LENGTH(first_name) FROM sakila.actor;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Exercicio 16                                                   :::::
# :::::  Tamanho do first name ordenado por tamanho do first_name DESC  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT first_name, CHAR_LENGTH(first_name) AS "Tamanho do nome" FROM sakila.actor
	ORDER BY CHAR_LENGTH(first_name) DESC;
    
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Qual o nome (title) do filme com o maior número de caracteres  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT title, CHAR_LENGTH(title) AS "Tamanho do nome" FROM film
	ORDER BY CHAR_LENGTH(title) DESC LIMIT 1;
    
# ::::::::::::::::::::::::::
# :::::  Exercicio 17  :::::
# ::::::::::::::::::::::::::

SELECT CONCAT(first_name, " ", last_name) AS "Nome Completo" FROM actor;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  CONCAT_WS                                               :::::
# :::::  Apresentar o id e o nome completo do autor numa coluna  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT CONCAT(actor_id, " ", first_name, " ", last_name) FROM actor;
SELECT CONCAT_WS(" ", actor_id, first_name, last_name) FROM actor;

# ::::::::::::::::::::
# :::::  FORMAT  :::::
# ::::::::::::::::::::

SELECT amount, FORMAT(amount, 0) FROM payment;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  INSTR                                                             :::::
# :::::  Devolve a posição de um carácter ou de um conjunto de caracteres  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT first_name, INSTR(first_name, "a") FROM actor;

# :::::::::::::::::::
# :::::  LCASE  :::::
# :::::::::::::::::::

SELECT first_name, LCASE(first_name) FROM actor;

# ::::::::::::::::::
# :::::  LEFT  :::::
# ::::::::::::::::::

SELECT first_name, LEFT(first_name, 3) FROM actor;

# ::::::::::::::::::::::::::
# :::::  Exercicio 18  :::::
# ::::::::::::::::::::::::::

SELECT address_id, LEFT(last_update, 10) FROM address 
	WHERE address_id > 150;
    
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  RIGHT                                            :::::
# :::::  Apresentar o address_id e a hora do last_update  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT address_id, RIGHT(last_update, 8) FROM address;

# ::::::::::::::::::::
# :::::  SUBSTR  :::::
# ::::::::::::::::::::

SELECT first_name, SUBSTR(first_name, 3, 2) FROM actor;

# :::::::::::::::::::
# :::::  UCASE  :::::
# :::::::::::::::::::

SELECT country_id, country, UCASE(country) FROM country;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Apresentar o mês de last_update da tabela actor  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT last_update, SUBSTR(last_update, 6, 2) AS "Mês" FROM actor;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Apresentar o número de porta do campo address  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT address, LEFT(address,INSTR(address, " ")-1) AS "Número da porta" FROM address;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o first_name da tabela actor com o primeira letra em maiuscula  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT first_name, CONCAT(LEFT(UCASE(first_name), 1), SUBSTR(LCASE(first_name), 2, CHAR_LENGTH(first_name)-1))
	AS "Nome com primeira letra maiuscula" FROM actor;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Na tabela customer separar o utilizador e o dominio em 2 colunas  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

-- opção1
SELECT email, LEFT(email,INSTR(email, "@")-1), SUBSTR(email, INSTR(email, "@")+1) FROM customer;

-- opção2
SELECT email, LEFT(email, INSTR(email, "@")-1), RIGHT(email, CHAR_LENGTH(email) - INSTR(email, "@")) FROM customer;