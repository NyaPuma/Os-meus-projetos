# :::::::::::::::::::::::::
# :::::  Função CEIL  :::::
# :::::::::::::::::::::::::

SELECT amount, CEIL(amount) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Função FLOOR  :::::
# ::::::::::::::::::::::::::

SELECT amount, FLOOR(amount) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Função ROUND  :::::
# ::::::::::::::::::::::::::

SELECT amount, ROUND(amount,3) FROM payment;

# :::::::::::::::::::::::::
# ::::: Exercicio 31  :::::
# :::::::::::::::::::::::::

SELECT COUNT(*) FROM customer;
SELECT COUNT(first_name) FROM customer;

# ::::::::::::::::::::::::::
# :::::  Exercicio 21  :::::
# ::::::::::::::::::::::::::

SELECT title, MAX(length) FROM film;

# ::::::::::::::::::::::::::
# :::::  Exercicio 23  :::::
# ::::::::::::::::::::::::::

SELECT MIN(length) FROM film;

# ::::::::::::::::::::::::::
# :::::  Exercicio 24  :::::
# ::::::::::::::::::::::::::

SELECT SUM(amount) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Exercicio 25  :::::
# ::::::::::::::::::::::::::

-- Opção1
SELECT SUM(amount) FROM payment WHERE payment_date >= "2005-05-01" AND payment_date <= "2005-05-31";

-- Opção 2
SELECT SUM(amount) FROM payment WHERE payment_date BETWEEN "2005-05-01" AND "2005-05-31";

# ::::::::::::::::::::::::::
# :::::  Exercicio 26  :::::
# ::::::::::::::::::::::::::

SELECT AVG(amount) FROM payment;

-- ROUND 2 casas decimais
SELECT ROUND(AVG(amount),2) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Exercicio 25  :::::
# ::::::::::::::::::::::::::

SELECT AVG(amount) FROM payment WHERE payment_date BETWEEN "2005-01-01" AND "2005-03-31";

# ::::::::::::::::::::::::
# :::::  Função NOW  :::::
# ::::::::::::::::::::::::

SELECT NOW();

# ::::::::::::::::::::::::
# :::::  Função DAY  :::::
# ::::::::::::::::::::::::

SELECT payment_date, DAY(payment_date) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Função MONTH  :::::
# ::::::::::::::::::::::::::

SELECT payment_date, MONTH(payment_date) FROM payment;

# ::::::::::::::::::::::::::
# :::::  Função YEAR  :::::
# ::::::::::::::::::::::::::

SELECT payment_date, YEAR(payment_date) FROM payment;

# ::::::::::::::::::::::::::::
# :::::  Função QUARTER  :::::
# ::::::::::::::::::::::::::::

SELECT payment_date, QUARTER(payment_date) FROM payment;

# ::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Média das vendas no 2º Trimestre  :::::
# ::::::::::::::::::::::::::::::::::::::::::::::

SELECT AVG(amount) FROM payment WHERE QUARTER(payment_date) = 2 AND YEAR(payment_date) = 2005;

# ::::::::::::::::::::::
# :::::  Semestre  :::::
# ::::::::::::::::::::::

SELECT payment_date, MONTH(payment_date)/6, CEIL(MONTH(payment_date)/6) FROM payment;

# :::::::::::::::::::::
# :::::  ADDDATE  :::::
# :::::::::::::::::::::

SELECT rental_date, ADDDATE(rental_date,2) FROM rental;
SELECT rental_date, ADDDATE(rental_date, INTERVAL 2 MONTH) FROM rental;
SELECT rental_date, ADDDATE(rental_date, INTERVAL 1 YEAR) FROM rental;

# :::::::::::::::::::::
# :::::  ADDTIME  :::::
# :::::::::::::::::::::

SELECT rental_date, ADDTIME(rental_date, 20) FROM rental;
SELECT rental_date, ADDTIME(rental_date, '00:1:00') FROM rental;

# ::::::::::::::::::::::
# :::::  DATEDIFF  :::::
# ::::::::::::::::::::::

SELECT rental_date, DATEDIFF(NOW(), rental_date) FROM rental;

# :::::::::::::::::::::::::
# :::::  DATE_FORMAT  :::::
# :::::::::::::::::::::::::

SELECT rental_date, DATE_FORMAT(rental_date, '%Y') FROM rental;
SELECT rental_date, DATE_FORMAT(rental_date, '%d') FROM rental;
SELECT rental_date, DATE_FORMAT(rental_date, '%e') FROM rental;

# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar o rental_date por extenso, Exemplo: WEDNESDAY MAY 2005 :::::
# ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

-- Definir o formato para português
SET lc_time_names = 'pt_PT';

-- Opção 1 ( Com muitos passos extras)
SELECT CONCAT_WS(",",DATE_FORMAT(rental_date, '%W'),
	CONCAT_WS(" of ", DATE_FORMAT(rental_date, '%e'), DATE_FORMAT(rental_date, '%M'), DATE_FORMAT(rental_date, '%Y'))) FROM rental;
    
-- Opção 2 ( Mais simples )
SELECT rental_date, DATE_FORMAT(rental_date, '%W, %e %M of %Y') FROM rental;

# :::::::::::::::::::::::
# :::::  DAYOFWEEK  :::::
# :::::::::::::::::::::::

SELECT DAYOFWEEK(NOW());
SELECT rental_date, DAYOFWEEK(rental_date) FROM rental;

# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
# :::::  Listar quantos aluguers fazemos por dia da semana  :::::
# :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

SELECT DAYOFWEEK(rental_date) AS 'Dia da semana', COUNT(rental_date) AS 'Nº de aluguers' FROM rental GROUP BY DAYOFWEEK(rental_date);

# :::::::::::::::::::::::
# :::::  DAYOFYEAR  :::::
# :::::::::::::::::::::::

SELECT rental_date, DAYOFYEAR(rental_date) FROM rental;

# ::::::::::::::::::::::::
# :::::  WEEKOFYEAR  :::::
# ::::::::::::::::::::::::

SELECT WEEKOFYEAR(NOW());
SELECT rental_date, WEEKOFYEAR(rental_date) FROM rental;